using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = string.Format("Tim Converter by JachuPL v{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

            if (args.Length == 0)
            {
                Manager.Instance.ShowNoSyntaxInfo();
                goto exit;
            }
            
            /// Argument parsing \\\
            Arg.Instance.ProcessArgumentList(args);
            Manager.Instance.Load();
            Manager.Instance.Save();
            Console.WriteLine("Press any key to exit...");
exit:
            Console.ReadKey();
        }
    }
}
