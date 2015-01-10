using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimConverter
{
    internal class Arg
    {
        #region Singleton Management
        private static Arg _instance = null;
        private static object chekLock = new object();

        private Arg() { }
        public static Arg Instance
        {
            get
            {
                lock (chekLock)
                {
                    if (_instance == null)
                        _instance = new Arg();
                    return _instance;
                }
            }
        }
        #endregion

        /// <summary>
        /// Method which processes a single argument given to a program
        /// </summary>
        /// <param name="args">parameter brought to an app</param>
        public void ProcessArgumentList(string[] args)
        {
            try
            {
                for (int i = 0; i < args.Length; i++)
                    if (args[i][0] == '-')
                    {
                        switch (args[i])
                        {
                            case "-f":
                                {
                                    if (i + 1 < args.Length)
                                    {
                                        i++;
                                        Manager.Instance.FilesToLoad = args[i].Split('|');
                                        if (Manager.Instance.FilesToLoad.Length == 0)
                                        {
                                            Console.WriteLine("Syntax error: no specified additional xml files!");
                                            Console.ReadKey();
                                            Environment.Exit(1);
                                        }
                                    }
                                    break;
                                }
                            case "-v": Manager.Instance.SetVerbose(true); break;
                            case "-o":
                                {
                                    if (i + 1 < args.Length)
                                    {
                                        i++;
                                        Manager.Instance.SetOutputFile(args[i]);
                                        Console.WriteLine("Output will be saved in {0}", args[i]);
                                    }
                                    break;
                                }
                            default: break;
                        }
                    }
            }
            catch (Exception ex)
            {
                JachuPL.LogTracer.LOG.Instance.WriteLog(ex);
                Console.WriteLine("An error occured while parsing arguments: you can find details in log.txt");
            }

        }
    }
}
