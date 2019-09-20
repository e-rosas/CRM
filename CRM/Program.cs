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

            //primera vez que se ejecuta el programa
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas"));
            FormConfiguracion config = new FormConfiguracion();
            config.ShowDialog();
            if(config.DialogResult == DialogResult.OK)
            {
                Application.Run(new FormCliente());
            }
            else if(config.DialogResult == DialogResult.Yes)
            {
                Application.Run(new FormServidor());
            }
            

          
            
        }
    }
}
