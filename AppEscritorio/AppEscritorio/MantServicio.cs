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
    public partial class MantServicio : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=PORTAFOLIO-PC\SQLEXPRESS;Initial Catalog=Portafolio;Integrated Security=True");  
        SqlCommand cmd;  
        SqlDataAdapter adapt;  
        //ID variable used in Updating and Deleting Record  
        
        int ID = 0;

        public MantServicio()  
        {  
            InitializeComponent();  
            DisplayData();  
        }   
        //Display Data in DataGridView  
        private void DisplayData()  
        {  
            con.Open();  
            DataTable dt=new DataTable();  
            adapt=new SqlDataAdapter("select * from TipoServicio",con);  
            adapt.Fill(dt);  
            dataGridView1.DataSource = dt;  
            con.Close();  
        }  
        //Clear Data  
        private void ClearData()  
        {  
            txtNombre.Text = "";  
            txtDescripcion.Text = "";  
            ID = 0;  
        }  
        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)  
        {  
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());  
            txtNombre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();  
            txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();  
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
             if (txtNombre.Text != "" && txtDescripcion.Text != "")  
            {  
                cmd = new SqlCommand("insert into TipoServicio(Nombre,Descripcion) values(@nombre,@descripcion)", con);  
                con.Open();  
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);  
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);  
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDescripcion.Text != "")  
            {
                cmd = new SqlCommand("update TipoServicio set Nombre=@nombre,Descripcion=@descripcion where ID=@id", con);  
                con.Open();  
                cmd.Parameters.AddWithValue("@id", ID);  
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);  
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);  
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete TipoServicio where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Borrado Correctamente!");
                DisplayData();
                ClearData();
            }
            else
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
