using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace AplicacionEscritorio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show(" Ingresa el Usuario y Contraseña .");
                    return;
                }
                string ConString = "Data Source=XE;User Id=system;Password=12345;";
                using (OracleConnection con = new OracleConnection(ConString))
                {

                    OracleCommand cmd = new OracleCommand("SELECT * FROM Usuario where loginUsuario=:user_name and pw=:pswd", con);
                    cmd.Parameters.Add(new OracleParameter(":user_name", textBox1.Text.Trim()));
                    cmd.Parameters.Add(new OracleParameter(":pswd", textBox2.Text.Trim()));

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    int i = ds.Rows.Count;
                    if (i == 1)
                    {
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Not Registered User or Invalid Name/Password");
                        textBox1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
