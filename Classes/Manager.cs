using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimConverter
{
    internal class Manager
    {
        #region Singleton Management
        private static Manager _instance = null;
        private static object chekLock = new object();

        private Manager()
        {

        }
        public static Manager Instance
        {
            get
            {
                lock (chekLock)
                {
                    if (_instance == null)
                        _instance = new Manager();
                    return _instance;
                }
            }
        }
        #endregion
        #region private variables
        string[] filesToLoad;
        bool bVerbose = false;
        string specialOutFile = "exlist.txt";
        List<string> lPackedFilesList = new List<string>();
        #endregion
        #region Properties
        public string[] FilesToLoad { get { return filesToLoad; } set { filesToLoad = value; } }

        public bool GetVerbose { get { return bVerbose; } }
        #endregion
        #region Methods

        public void SetVerbose(bool b) { bVerbose = b; }
        public void SetOutputFile(string filename) { specialOutFile = filename; }

        public void ShowNoSyntaxInfo()
        {
            Console.WriteLine("Oops, it looks like you forgot to pass any parameters to program.\nDon't worry, here's a list:");
            Console.WriteLine("Syntax: timconv.exe \"filename.xml\" option1 [arg1] option2 [arg2] and so on");
            Console.WriteLine("Options list:");
            Console.WriteLine("-o file.txt\t\tResult is saved to a [file.txt].");
            Console.WriteLine("-v\t\t\twrites log from conversion into a screen");
            Console.WriteLine("-f \"list|of|files\"\tconverts files separated by |");
        }

        public void Load()
        {
            try
            {
                lPackedFilesList = XMLManager.Instance.LoadFiles(filesToLoad);
            }
            catch(Exception ex)
            {
#if(JachuPL)
                JachuPL.LogTracer.LOG.Instance.WriteLog(ex);
                Console.WriteLine("An error occured during load: you can find details in log.txt");
#else
                Console.WriteLine("An error occured during load:\n{0}\nStackTrace: {1}", ex.Message, ex.StackTrace);
#endif
            }
        }

        public void Save()
        {
            try
            {
                string[] list = lPackedFilesList.ToArray();
                if (File.Exists(specialOutFile)) File.Delete(specialOutFile);
                File.AppendAllLines(specialOutFile, list, Encoding.Default);
                Console.WriteLine("Saved successfully into {0}!", specialOutFile);
            }
            catch(Exception ex)
            {
#if(JachuPL)
                JachuPL.LogTracer.LOG.Instance.WriteLog(ex);
                Console.WriteLine("An error occured during save: you can find details in log.txt");
#else
                Console.WriteLine("An error occured during save:\n{0}\nStackTrace: {1}", ex.Message, ex.StackTrace);
#endif
            }
        }
        #endregion
    }
}
