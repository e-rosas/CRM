using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }

        private void BTAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Servidor = TBDireccion.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Configuracion exitosa!","Configuracion",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {

        }
    }
}
