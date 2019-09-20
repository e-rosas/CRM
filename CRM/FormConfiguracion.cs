using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        private void Button1_Click(object sender, EventArgs e)
        {

            GenerarBD(TBDireccion.Text);
        }
        private void GenerarBD(string servidor)
        {
            List<string> cmds = new List<string>();
            if (File.Exists(Application.StartupPath + "\\Script.sql"))
            {
                TextReader tr = new StreamReader(Application.StartupPath + "\\scriptrt.sql");
                string line = "";
                string cmd = "";
                while ((line = tr.ReadLine()) != null)
                {
                    if ((line.Trim().ToUpper() == "GO"))
                    {
                        cmds.Add(cmd);
                        cmd = "";
                    }
                    else
                    {
                        cmd += line + "\r\n";
                    }
                }
                if (cmd.Length > 0)
                {
                    cmds.Add(cmd);
                    cmd = "";
                }
                tr.Close();
            }
            if (cmds.Count > 0)
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = new SqlConnection(@"Data Source=" + servidor + ";Initial Catalog=MASTER;Integrated Security=True;");
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection.Open();
                for (int i = 0; i < cmds.Count; i++)
                {
                    comando.CommandText = cmds[i];
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
