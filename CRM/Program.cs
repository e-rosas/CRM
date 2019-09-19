using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.Servidor == "NOCONFIGURADO")
            {
                //primera vez que se ejecuta el programa
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas"));
                Application.Run(new FormConfiguracion());         
            }
            else
            {
                Application.Run(new FormCliente());
            }
            
        }
    }
}
