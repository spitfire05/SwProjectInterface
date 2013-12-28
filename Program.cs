using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SwProjectInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UpdateChecker.start("http://swprojectinterface.sourceforge.net/update.xml");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
