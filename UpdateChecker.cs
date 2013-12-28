using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace SwProjectInterface
{
    class UpdateChecker
    {
        public static void start(string metaFileURL)
        {
            _UpdateChecker uc = new _UpdateChecker();
            uc.URL = metaFileURL;
            Thread t = new Thread(uc.start);
            t.Start();
        }
    }

    class _UpdateChecker
    {
        public string URL { get; set; }

        public void start()
        {
            XmlDocument x = new XmlDocument();
            try
            {
                x.Load(this.URL);
                XmlNode root = x.DocumentElement;
                if (root.Name != "swpi")
                {
                    throw new XmlException();
                }
                string version = x.SelectSingleNode("descendant::version").InnerText;
                string downloadURL = x.SelectSingleNode("descendant::URL").InnerText;
                if (version == null || downloadURL == null)
                {
                    throw new XmlException();
                }
                if (String.Compare(version, Assembly.GetExecutingAssembly().GetName().Version.ToString()) == 1)
                {
                    DialogResult r = MessageBox.Show("New version of SwProjectInterface is available to download. Would you like to download it?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (r == DialogResult.Yes)
                    {
                        Process.Start(downloadURL);
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }
    }
}
