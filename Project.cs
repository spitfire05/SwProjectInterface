using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace SwProjectInterface
{   
    public class Project
    {
        public List<int> numbers;
        public List<string> filenames;
        public List<SWFile> files;
        public string file, partPrefix, partSuffix, assyPrefix, assySuffix;
        public string workDir;

        public bool openedOK
        {
            get { return _openedOK; }
        }

        private bool _openedOK = false;
        
        public void createNew(string path)
        {
            createNew();
            file = path;
        }

        public void createNew()
        {
            numbers = new List<int>();
            filenames = new List<string>();
            files = new List<SWFile>();
            this.file = "";
            _openedOK = true;
        }

        public void save()
        {
            XmlTextWriter textWriter = new XmlTextWriter(file, null);
            textWriter.Formatting = Formatting.Indented;
            textWriter.Indentation = 4;
            // Opens the document
            textWriter.WriteStartDocument();

            // root node open
            textWriter.WriteStartElement("swpiProject");

            // version string
            textWriter.WriteStartElement("version");
            textWriter.WriteString(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            textWriter.WriteEndElement();

            // Input workdir
            textWriter.WriteStartElement("workDir");
            textWriter.WriteString(workDir);
            textWriter.WriteEndElement();

            // Prefixes, suffixes
            textWriter.WriteStartElement("partPrefix");
            textWriter.WriteString(partPrefix);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("partSuffix");
            textWriter.WriteString(partSuffix);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("assyPrefix");
            textWriter.WriteString(assyPrefix);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("assySuffix");
            textWriter.WriteString(assySuffix);
            textWriter.WriteEndElement();

            // Input content
            textWriter.WriteStartElement("files");
            foreach (SWFile x in this.files)
            {
                textWriter.WriteStartElement("file");

                textWriter.WriteStartElement("path");
                textWriter.WriteString(Path.GetFileName(x.file));
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("number");
                textWriter.WriteString(x.number.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("prefix");
                textWriter.WriteString(x.prefix);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("suffix");
                textWriter.WriteString(x.suffix);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("name");
                textWriter.WriteString(x.name);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("type");
                textWriter.WriteString(((int)x.docType).ToString());
                textWriter.WriteEndElement();

                textWriter.WriteEndElement();

            }
            textWriter.WriteEndElement();

            // root node close
            textWriter.WriteEndElement();

            // Ends the document.
            textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
        }

        public void open(string path)
        {
            numbers = new List<int>();
            filenames = new List<string>();
            files = new List<SWFile>();
            file = path;
            if (!File.Exists(path))
            {
                throw new ProjectReadException("Can\'t find file " + path);
            }
            XmlDocument d = new XmlDocument();
            try
            {
                d.Load(file);
            }
            catch (XmlException exc)
            {
                throw new ProjectReadException(exc.Message);
            }
            XmlNode root = d.DocumentElement;
            if (root.Name != "swpiProject")
            {
                throw new ProjectReadException("Root node missing.");
            }
            workDir = readSingleNode(d, "descendant::workDir");
            partPrefix = readSingleNode(d, "descendant::partPrefix");
            partSuffix = readSingleNode(d, "descendant::partSuffix");
            assyPrefix = readSingleNode(d, "descendant::assyPrefix");
            assySuffix = readSingleNode(d, "descendant::assySuffix");

            // Read elements...
            foreach (XmlNode fileNode in d.SelectNodes("descendant::files/file"))
                // no need to throw exceptions here, it is ok for "files" node not to exist
            {
                SWFile f = null;
                string t = readSingleNode(fileNode, "descendant::type");
                SWFileType tp = getSWFileTypeFromString(t);
                if (tp == SWFileType.PART)
                {
                    f = new SWPart()
                    {
                        project = this,
                        name = readSingleNode(fileNode, "descendant::name"),
                        prefix = readSingleNode(fileNode, "descendant::prefix"),
                        suffix = readSingleNode(fileNode, "descendant::suffix"),
                        file = readSingleNode(fileNode, "descendant::path"),
                    };
                }
                else if (tp == SWFileType.ASSEMBLY)
                {
                    f = new SWAssy()
                    {
                        project = this,
                        name = readSingleNode(fileNode, "descendant::name"),
                        prefix = readSingleNode(fileNode, "descendant::prefix"),
                        suffix = readSingleNode(fileNode, "descendant::suffix"),
                        file = readSingleNode(fileNode, "descendant::path"),
                    };
                }
                else
                {
                    throw new ProjectReadException("Wrong file type: " + t);
                }
                try
                {
                    f.number = Convert.ToInt32(fileNode.SelectSingleNode("descendant::number").InnerText);
                }
                catch (FormatException)
                {
                    throw new ProjectReadException(String.Format("\"{0}\" can't be a number.", fileNode.SelectSingleNode("descendant::number").InnerText));
                }
                files.Add(f);
                numbers.Add(f.number);
                filenames.Add(f.prefix + SWFile.fourDigit(f.number) + f.suffix);
            }
            _openedOK = true;
        }

        private SWFileType getSWFileTypeFromString(string s)
        {
            try
            {
                int i = Convert.ToInt32(s);
                return (SWFileType)i;
            }
            catch (FormatException)
            {
                if (s == "PART")
                {
                    return SWFileType.PART;
                }
                else if (s == "ASSEMBLY")
                {
                    return SWFileType.ASSEMBLY;
                }
                else
                {
                    throw new ProjectReadException(String.Format("Wrong file type: {0}", s));
                }
            }
        }
        
        private string readSingleNode(XmlNode d, string xpath)
        {
            XmlNode n = d.SelectSingleNode(xpath);
            if (n != null)
            {
                return n.InnerText;
            }
            else
            {
                throw new ProjectReadException(String.Format("Can't read XML xpath {0}", xpath));
            }
        }

        public void removeMissingFiles()
        {
            List<SWFile> toRemove = new List<SWFile>();
            foreach (SWFile f in files)
            {
                if (f.getStatus().Type == SWFileStatusType.FILE_MISSING)
                {
                    filenames.Remove(f.file);
                    numbers.Remove(f.number);
                    toRemove.Add(f);
                }
            }
            foreach (SWFile f in toRemove)
            {
                files.Remove(f);
            }
        }

        public void searchForMissingAssemblyFiles(out int numFound)
        {
            numFound = 0;
            List<SWFile> toRemove = new List<SWFile>();
            List<SWFile> toAdd = new List<SWFile>();
            foreach (SWFile f in files)
            {
                if (f.docType == SWFileType.PART && f.getStatus().Type == SWFileStatusType.FILE_MISSING)
                {
                    string probableName = f.prefix + SWFile.fourDigit(f.number) + f.suffix + new SWAssy().extension;
                    if (File.Exists(Path.Combine(workDir, probableName)))
                    {
                        SWPart f_old = f as SWPart;
                        SWAssy f_new = (SWAssy)f_old;
                        f_new.file = probableName;
                        toRemove.Add(f);
                        toAdd.Add(f_new);
                        numFound += 1;
                    }
                }
            }
            foreach (SWFile f in toRemove)
            {
                f.removeFromProject();
            }
            foreach (SWFile f in toAdd)
            {
                f.addToProject();
            }
        }
    }

    public class ProjectReadException : Exception
    {
        public ProjectReadException(string message)
            : base(message)
        {
        }
    }
}
