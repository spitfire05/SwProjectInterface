using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SwProjectInterface
{
    /// <summary>
    /// A stub of CSV exporter
    /// </summary>
    class CSVExporter
    {
        private Project project;

        public CSVExporter(Project Project)
        {
            project = Project;
        }

        public void Export(string path)
        {
            FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            foreach (SWFile file in project.files.OrderBy<SWFile, int>(x => x.number).ToList<SWFile>())
            {
                sw.WriteLine(String.Format("{1}{0}{2}", ";", file.prefix + SWFile.fourDigit(file.number) + file.suffix, file.name));
            }
            sw.Close();
            fs.Close();
        }
    }
}
