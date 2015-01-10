using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TimConverter
{
    internal class XMLManager
    {
        #region Singleton Management
        private static XMLManager _instance = null;
        private static object chekLock = new object();

        private XMLManager()
        {

        }
        public static XMLManager Instance
        {
            get
            {
                lock (chekLock)
                {
                    if (_instance == null)
                        _instance = new XMLManager();
                    return _instance;
                }
            }
        }
        #endregion

        public List<string> LoadFiles(string[] files)
        {
            List<string> temp = new List<string>();
            try
            {
                int iter = 1, fileiter = 1;
                foreach (string file in files)
                {
                    if (Manager.Instance.GetVerbose)
                        Console.WriteLine("Processing file {0}/{1}\nFile name: {2}", fileiter++, files.Length, file);
                    XmlDocument xml = new XmlDocument();
                    xml.Load(file);
                    XmlElement filelist = xml.DocumentElement;
                    foreach (XmlNode item in filelist.ChildNodes)
                    {
                        if (@item.Name != "File")
                        {
                            foreach (XmlNode node in item.ChildNodes)
                            {
                                if (Manager.Instance.GetVerbose)
                                    Console.WriteLine("{0}.\t{1}", iter++, @node.Attributes["ArchivedPath"].InnerText);
                                temp.Add(@node.Attributes["ArchivedPath"].InnerText + ",");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if(JachuPL)
                JachuPL.LogTracer.LOG.Instance.WriteLog(ex);
                Console.WriteLine("An error occured during load: you can find details in log.txt");
#else
                Console.WriteLine("An error occured during load:\n{0}\nStackTrace: {1}", ex.Message, ex.StackTrace);
#endif
            }
            return temp;
        }
    }
}
