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
    public partial class FormServidor : Form
    {
        private Conexion conexion = new Conexion();
        public FormServidor()
        {
            InitializeComponent();
            conexion.conexionString = "Data Source="+Properties.Settings.Default.Servidor+"; Initial Catalog=Transacciones; User id=AdminTransaccion; Password=root";
        }

        private void FormServidor_Load(object sender, EventArgs e)
        {
            DGVTransacciones.DataSource = conexion.VerTransacciones("%"+""+"%");
        }

        private void BtnBucar_Click(object sender, EventArgs e)
        {
            DGVTransacciones.DataSource = conexion.VerTransacciones("%" + TBBusqueda.Text + "%");
        }

        private void BTActualizar_Click(object sender, EventArgs e)
        {
            DGVTransacciones.DataSource = conexion.VerTransacciones("%" + "" + "%");
            
        }

        private void BTAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Servidor = TBDireccion.Text;
            conexion.conexionString = "Data Source=" + Properties.Settings.Default.Servidor + "; Initial Catalog=Transacciones; User id=AdminTransaccion; Password=root";
            Properties.Settings.Default.Save();
            MessageBox.Show("Configuracion exitosa!", "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
