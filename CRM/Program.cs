using System;
using System.Collections.Generic;
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
                Application.Run(new FormConfiguracion());
            }
            else
            {
                Application.Run(new FormCliente());
            }
            
        }
    }
}
