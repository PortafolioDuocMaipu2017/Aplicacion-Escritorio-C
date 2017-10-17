using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppEscritorio
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantAct ss = new MantAct();
            ss.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ha Cerrado Sesion.");
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void btn_TipoCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantCliente cli = new MantCliente();
            cli.Show();
        }

        private void btn_TipoContrato_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantContrato ventana = new MantContrato();
            ventana.Show();
        }

        private void btn_TipoServicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantServicio serv = new MantServicio();
            serv.Show();
        }

        private void btn_TipoRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantRol rol = new MantRol();
            rol.Show();
        }

        private void btn_Clientes_Click_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantCli cli = new MantCli();
            cli.Show();
        }

        private void btnDestinox_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantDestinos des = new MantDestinos();
            des.Show();
        }
    }
}
