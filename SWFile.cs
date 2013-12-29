using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SwProjectInterface
{
    abstract public class SWFile
    {
        public const int RET_OK = 0;
        public const int RET_NAME_EXISTS = 1;
        public const int RET_DUPLICATE_NUMBER = 2;
        public const int RET_FILE_EXISTS = 3;
        public const int RET_FILE_MISSING = 4;

        public Project project;
        public string prefix, suffix, template, file, name;
        public int number;

        public SWFileStatus lastShownStatus { get; set; }
        abstract public SWFileType docType { get; }

        private bool updatePending = false;

        abstract public string extension { get; }
        abstract public string typeString { get; }

        protected SldWorks swApp;

        /// <summary>
        /// Extracts [prefix, number, suffix] from given filename.
        /// </summary>
        /// <param name="filename">Name of the file to extract params from</param>
        /// <returns>string array [prefix, number, suffix]</returns>
        public static string[] getFileParams(string filename)
        {
            string[] r = new string[3];

            // prefix
            Regex prefixRegex = new Regex(@"([a-zA-Z0-9]*)[0-9]{4}[a-zA-Z0-9]*.*");
            r[0] = prefixRegex.Match(filename).Groups[1].Value;

            // number
            Regex numberRegex = new Regex(@"[a-zA-Z0-9]*([0-9]{4})[a-zA-Z0-9]*.*");
            r[1] = numberRegex.Match(filename).Groups[1].Value;

            // suffix
            Regex suffixRegex = new Regex(@"[a-zA-Z0-9]*[0-9]{4}([a-zA-Z0-9]*).*");
            r[2] = suffixRegex.Match(filename).Groups[1].Value;

            return r;
        }

        /// <summary>
        /// Converts int into 4-character string, prefixed with zeros if needed
        /// </summary>
        /// <param name="n">Number to convert</param>
        /// <returns></returns>
        public static string fourDigit(int n)
        {
            if (n < 0 || n > 9999)
            {
                throw new ArgumentException();
            }

            if (n < 10)
            {
                return "000" + n.ToString();
            }
            if (n < 100)
            {
                return "00" + n.ToString();
            }
            if (n < 1000)
            {
                return "0" + n.ToString();
            }
            return n.ToString();
        }

        private TForm getForm<TForm>()
            where TForm : Form
        {
            return (TForm)Application.OpenForms.OfType<TForm>().FirstOrDefault();
        }

        public void updateDBForm()
        {
            Form1 form = getForm<Form1>();
            if (!form.dbForm.Visible)
            {
                form.prep_DBForm();
            }
            form.dbForm.scheduleFileUpdate(this);
        }

        public int setName(string newValue)
        {
            if (!File.Exists(Path.Combine(project.workDir, file)))
            {
                return RET_FILE_MISSING;
            }
            this.name = newValue;
            swApp = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            swApp.Visible = true;
            swApp.OnIdleNotify += new DSldWorksEvents_OnIdleNotifyEventHandler(_setName);
            updatePending = true;
            return RET_OK;
        }

        protected int _setName()
        {
            ModelDoc2 swDoc;
            int errors = 0;
            int warnings = 0;
            swDoc = (ModelDoc2)swApp.OpenDocSilent(Path.Combine(project.workDir, file), (int)docType, ref errors);
            CustomPropertyManager swCustProp = swDoc.Extension.get_CustomPropertyManager("");
            swCustProp.Set(Settings.Default.propertyName, this.name);
            updatePending = false;
            swDoc.Extension.SaveAs(Path.Combine(project.workDir, file), (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
            swApp.OnIdleNotify -= new DSldWorksEvents_OnIdleNotifyEventHandler(_setName);
            this.updateDBForm();
            return 0;
        }
        
        public int getNameFromFile()
        {
            if (!File.Exists(Path.Combine(project.workDir, file)))
            {
                return RET_FILE_MISSING;
            }
            swApp = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            swApp.Visible = true;
            swApp.OnIdleNotify += new DSldWorksEvents_OnIdleNotifyEventHandler(_getNameFromFile);
            updatePending = true;
            return RET_OK;
        }

        protected int _getNameFromFile()
        {
            ModelDoc2 swDoc;
            int errors = 0;
            swDoc = (ModelDoc2)swApp.OpenDocSilent(Path.Combine(project.workDir, file), (int)docType, ref errors);
            CustomPropertyManager swCustProp = swDoc.Extension.get_CustomPropertyManager("");
            string o, ro;
            swCustProp.Get4(Settings.Default.propertyName, false, out o, out ro);
            name = ro;
            updatePending = false;
            swApp.OnIdleNotify -= new DSldWorksEvents_OnIdleNotifyEventHandler(_getNameFromFile);
            updateDBForm();
            return 0;
        }
        
        public int open()
        {
            if (!File.Exists(Path.Combine(project.workDir, file)))
            {
                return RET_FILE_MISSING;
            }
            swApp = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            swApp.Visible = true;
            swApp.OnIdleNotify += new DSldWorksEvents_OnIdleNotifyEventHandler(_open);
            return RET_OK;
        }

        protected int _open()
        {
            ModelDoc2 swDoc;
            int errors = 0;
            int warnings = 0;
            swDoc = (ModelDoc2)swApp.OpenDoc6(Path.Combine(project.workDir, file), (int)docType, 0, "", ref errors, ref warnings);
            swApp.OnIdleNotify -= new DSldWorksEvents_OnIdleNotifyEventHandler(_open);
            updateDBForm();
            return 0;
        }
        
        public void save()
        {
            swApp = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            swApp.Visible = true;
            swApp.OnIdleNotify += new DSldWorksEvents_OnIdleNotifyEventHandler(_save);
        }

        protected int _save()
        {
            ModelDoc2 swDoc;
            int errors = 0;
            int warnings = 0;
            swDoc = ((ModelDoc2)(swApp.NewDocument(template, 0, 0, 0)));
            CustomPropertyManager swCustProp = swDoc.Extension.get_CustomPropertyManager("");
            swCustProp.Set(Settings.Default.propertyName, name);
            swDoc.Extension.SaveAs(Path.Combine(project.workDir, file), (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
            swApp.OnIdleNotify -= new DSldWorksEvents_OnIdleNotifyEventHandler(_save);
            updateDBForm();
            return 0;
        }

        public void save_Uprofile()
        {
            swApp = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            swApp.Visible = true;
            swApp.OnIdleNotify += new DSldWorksEvents_OnIdleNotifyEventHandler(_save_Uprofile);
        }

        protected int _save_Uprofile()
        {
            ModelDoc2 swDoc;
            int errors = 0;
            int warnings = 0;
            swDoc = ((ModelDoc2)(swApp.NewDocument(template, 0, 0, 0)));
            CustomPropertyManager swCustProp = swDoc.Extension.get_CustomPropertyManager("");
            swCustProp.Set(Settings.Default.propertyName, name);

            // Create sketch
            swDoc.SketchManager.InsertSketch(true);
            // Draw the lines
            SketchSegment line1, line2, line3;
            line1 = (SketchSegment)(swDoc.SketchManager.CreateLine(-0.05, 0.0, 0.0, 0.05, 0.0, 0.0)); // horizontal
            line2 = (SketchSegment)(swDoc.SketchManager.CreateLine(-0.05, 0.0, 0.0, -0.05, 0.05, 0.0)); // left
            line3 = (SketchSegment)(swDoc.SketchManager.CreateLine(0.05, 0.0, 0.0, 0.05, 0.05, 0.0)); // right
            // left and right line same length
            line2.Select4(false, null);
            line3.Select4(true, null);
            swDoc.SketchAddConstraints("sgSAMELENGTH");
            // line 1 center on datum origin
            swDoc.Extension.SelectByID2("", swSelectType_e.swSelDATUMPOINTS.ToString(), 0.0, 0.0, 0.0, false, 0, null, 0);
            line1.Select4(true, null);
            swDoc.SketchAddConstraints("sgATMIDDLE");
            // Add dimensions
            line1.Select4(false, null);
            swDoc.AddDimension2(0.0, -0.05, 0.0);
            line2.Select4(false, null);
            swDoc.AddDimension2(-0.06, 0.025, 0.0);
            // Exit sketch
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);

            swDoc.Extension.SaveAs(Path.Combine(project.workDir, file), (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
            swApp.OnIdleNotify -= new DSldWorksEvents_OnIdleNotifyEventHandler(_save_Uprofile);
            updateDBForm();
            return 0;
        }

        public int create()
        {
            file = prefix + fourDigit(number) + suffix;
            if (project.filenames.Contains(file))
            {
                return RET_NAME_EXISTS;
            }
            file += extension;
            if (project.numbers.Contains(number))
            {
                return RET_DUPLICATE_NUMBER;
            }
            if (File.Exists(Path.Combine(project.workDir, file)))
            {
                return RET_FILE_EXISTS;
            }
            return RET_OK;
        }

        public void addToProject()
        {
            project.filenames.Add(prefix + fourDigit(number) + suffix);
            project.numbers.Add(number);
            project.files.Add(this);
        }

        public void removeFromProject()
        {
            project.filenames.Remove(prefix + fourDigit(number) + suffix);
            project.numbers.Remove(number);
            project.files.Remove(this);
        }

        public void removeFromDisk()
        {
            FileSystem.DeleteFile(Path.Combine(project.workDir, file), UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }

        public SWFileStatus getStatus()
        {
            SWFileStatus s;
            if (!File.Exists(Path.Combine(project.workDir, file)))
            {
                s = new SWFileStatus("FILE MISSING", Color.Red, SWFileStatusType.FILE_MISSING);
            }
            else if (updatePending)
            {
                s = new SWFileStatus("READING DATA", Color.Blue, SWFileStatusType.READING_DATA);
            }
            else
            {
                s = new SWFileStatus("OK", Color.Green, SWFileStatusType.OK);
            }
            return s;
        }
    }

    public class SWPart : SWFile
    {
        #region conversions

        static public explicit operator SWPart(SWAssy f)
        {
            SWPart nf = new SWPart()
            {
                // public members
                project = f.project,
                prefix = f.prefix,
                suffix = f.suffix,
                template = f.template,
                file = f.file,
                name = f.name,
                number = f.number,
                lastShownStatus = f.lastShownStatus,
            };
            return nf;
        }

        #endregion

        public override string extension
        {
            get { return ".sldprt"; }
        }

        public override string typeString
        {
            get { return "PART"; }
        }

        public override SWFileType docType
        {
            get { return SWFileType.PART; }
        }
    }

    public class SWAssy : SWFile
    {
        #region conversions

        static public explicit operator SWAssy(SWPart f)
        {
            SWAssy nf = new SWAssy()
            {
                // public members
                project = f.project,
                prefix = f.prefix,
                suffix = f.suffix,
                template = f.template,
                file = f.file,
                name = f.name,
                number = f.number,
                lastShownStatus = f.lastShownStatus,
            };
            return nf;
        }

        #endregion

        public override string extension
        {
            get { return ".sldasm"; }
        }

        public override string typeString
        {
            get { return "ASSEMBLY"; }
        }

        public override SWFileType docType
        {
            get { return SWFileType.ASSEMBLY; }
        }
    }

    public class SWFileStatus
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        public SWFileStatusType Type { get; set; }

        public SWFileStatus(string text, Color color, SWFileStatusType type)
        {
            Text = text;
            Color = color;
            Type = type;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public enum SWFileStatusType
    {
        OK = 0,
        READING_DATA = 1,
        FILE_MISSING = 2,
    }

    /// <summary>
    /// Represents file types compatible with SolidWorks API
    /// </summary>
    public enum SWFileType
    {
        PART = 1,
        ASSEMBLY = 2,
    }
}
