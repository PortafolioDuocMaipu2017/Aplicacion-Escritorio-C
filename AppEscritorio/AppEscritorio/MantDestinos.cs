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
    public partial class MantDestinos : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=PORTAFOLIO-PC\SQLEXPRESS;Initial Catalog=Portafolio;Integrated Security=True");  
        SqlCommand cmd;
        SqlDataAdapter adapt;

        int ID = 0;
        public MantDestinos()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from TipoDestino", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txtNombre.Text = "";
            ID = 0;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtNombre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                cmd = new SqlCommand("insert into TipoDestino(nombre) values(@nombre)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Creado Correctamente");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Porfavor Revise los datos ingresados.");
            }  

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                cmd = new SqlCommand("update TipoDestino set nombre=@nombre where id=@Id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos Actualizados");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione los datos");
            } 
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("delete TipoDestino where id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Borrado Correctamente!");
                DisplayData();
                ClearData();
            }
            catch
            {
                MessageBox.Show("Porfavor Seleccione el dato a borrar");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
