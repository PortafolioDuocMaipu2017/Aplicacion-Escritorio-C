using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppEscritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=PORTAFOLIO-PC\SQLEXPRESS;Initial Catalog=Portafolio;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from Login where Usuario='"+textBox1.Text+"' and Contraseña='"+textBox2.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Menu menu = new Menu();
                menu.Show();               

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta");
            }

            
        }
    }
}
