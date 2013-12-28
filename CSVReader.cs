using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SwProjectInterface
{
    /// <summary>
    /// A very simple CSV reader.
    /// </summary>
    class CSVReader
    {
        /// <summary>
        /// Gets data matrix read from the file.
        /// </summary>
        public List<List<string>> Matrix
        {
            get { return matrix; }
        }

        private string fieldDelimiter;
        //private string textDelimiter;
        private List<List<string>> matrix;

        // constructor
        public CSVReader(string fieldDelimiter)
        {
            this.fieldDelimiter = fieldDelimiter;
            //this.textDelimiter = textDelimiter;
        }

        /// <summary>
        /// Reads data from file.
        /// </summary>
        /// <param name="path">Path to file (not validated!)</param>
        /// <param name="numLinesToOmit">Number of lines to omit at begining.</param>
        public void readFile(string path, int numLinesToOmit)
        {
            FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader r = new StreamReader((Stream)fs, Encoding.Default);
            matrix = new List<List<string>>();
            while (numLinesToOmit > 0)
            {
                numLinesToOmit -= 1;
                r.ReadLine();
            }
            while (!r.EndOfStream)
            {
                List<string> line = new List<string>();
                foreach(string s in r.ReadLine().Trim().Split(new string [] { fieldDelimiter }, StringSplitOptions.None))
                {
                    line.Add(s);
                }
                matrix.Add(line);
            }
            r.Close();
            fs.Close();
        }
    }
}
