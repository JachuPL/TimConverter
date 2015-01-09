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

        public void ProcessArgument(string arg)
        {
            if (arg[0] == '-')
            {
                ProcessOption(arg.Substring(1, arg.Length-1));
            }
        }

        void ProcessOption(string arg)
        {
            
        }
    }
}
