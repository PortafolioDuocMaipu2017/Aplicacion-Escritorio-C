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

namespace AppEscritorioPortafolio
{
    public partial class Form1 : Form
    {
        public Form1()
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
                

                string ConString = "Data Source=XE;User Id=PORTAFOLIO2;Password=12345;";
                using (OracleConnection con = new OracleConnection(ConString))
                {

                    OracleCommand cmd = new OracleCommand("Select Usuario.NOMBREUSUARIO, Usuario.PW, Usuario.ESTADO, Rol.NOMBREROL from Usuario INNER JOIN Rol ON Usuario.NOMBREUSUARIO = Rol.USUARIO_NOMBREUSUARIO where Usuario.NOMBREUSUARIO =:user_name and Usuario.PW =:pw ", con);
                    cmd.Parameters.Add(new OracleParameter(":user_name", textBox1.Text.Trim()));
                    cmd.Parameters.Add(new OracleParameter(":pswd", textBox2.Text.Trim()));
                    
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    String wea = "0";
                    String wea2 = "";
                    try
                    {
                        wea = ds.Tables[0].Rows[0]["ESTADO"].ToString();
                        wea2 = ds.Tables[0].Rows[0]["NOMBREROL"].ToString();
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show("No Usuario Registrado O  Nombre/Password Erronea");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                                    

                    int i = ds.Tables[0].Rows.Count;
                    if (i == 1 && wea == "1" && wea2 == "administrador")
                    {
                        MessageBox.Show("Sesion Iniciada Correctamente");
                        this.Hide();
                        Menu menu = new Menu();
                        menu.Show();
                        
                    }
                    if (i == 1 && wea != "1" && wea2 != "administrador")
                    {
                        MessageBox.Show("El usuario no es Administrador, es " + wea2);
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    if (i == 1 && wea != "1")
                    {
                        
                        
                            MessageBox.Show("El usuario no esta Habilitado");
                            textBox1.Text = "";
                            textBox2.Text = "";
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
