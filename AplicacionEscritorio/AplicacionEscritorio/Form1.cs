using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace AplicacionEscritorio
{
    public partial class Form1 : Form
    {
        OracleConnection ccn = new OracleConnection("DATA SOURCE=XE;PASSWORD=portafolio;USER ID=PORTAFOLIO");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ccn.Open();
                MessageBox.Show("Conecta3");
            }
            catch (Exception i)
            {
                MessageBox.Show("Error"+ i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
