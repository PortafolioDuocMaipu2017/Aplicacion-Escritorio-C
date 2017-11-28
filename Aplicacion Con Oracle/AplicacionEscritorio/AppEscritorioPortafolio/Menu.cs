using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorioPortafolio
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sesion Cerrada Correctamente");
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantActividades act = new MantActividades();
            act.Show();
        }

        private void btnRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantRol rol = new MantRol();
            rol.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantUsuarios usu = new MantUsuarios();
            usu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantTipoServicio tipo = new MantTipoServicio();
            tipo.Show();
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantPais pais = new MantPais();
            pais.Show();
        }

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantCiudad ciudad = new MantCiudad();
            ciudad.Show();
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantDestinos destino = new MantDestinos();
            destino.Show();
        }
    }
}
