using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePresto
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                switch (args[1])
                {
                    case "scan":
                        string scandir = (args.Length > 2) ? args[2] : string.Empty;
                        Application.Run(new ImageScan(scandir));
                        break;
                    default:
                        throw new ArgumentException("Error in Command line");
                }
            }
            else
            {
                Application.Run(new ImageView());
            }
        }
    }
}
