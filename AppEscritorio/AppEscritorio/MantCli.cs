﻿using System;
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
    public partial class MantCli : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OL9C22K\JAVIER;Initial Catalog=Portafolio;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        int ID = 0;
        public MantCli()
        {
            InitializeComponent();
            DisplayData();
            

        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from cliente", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();  
        }

        private void ClearData()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtIdTipoCliente.Text = "";
            txtIdAgencia.Text = "";
            ID = 0;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtIdTipoCliente.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtIdAgencia.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtDescripcion.Text != "" && txtIdTipoCliente.Text !="" && txtIdAgencia.Text !="")
            {
                cmd = new SqlCommand("insert into cliente(id,descripcion,tipocliente_id,agencia_id) values(@id,@descripcion,@idTipoCliente,@idAgencia)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@idTipoCliente",Convert.ToInt32(txtIdTipoCliente.Text));
                cmd.Parameters.AddWithValue("@idAgencia",Convert.ToInt32(txtIdAgencia.Text));
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

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtDescripcion.Text != "" && txtIdTipoCliente.Text != "" && txtIdAgencia.Text != "")
            {
                cmd = new SqlCommand("update cliente set id=@id, descripcion=@descripcion, tipocliente_id=@idTipoCliente, agencia_id=@idAgencia where id=@Id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@idTipoCliente", Convert.ToInt32(txtIdTipoCliente.Text));
                cmd.Parameters.AddWithValue("@idAgencia", Convert.ToInt32(txtIdAgencia.Text));
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

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("delete cliente where id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
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
