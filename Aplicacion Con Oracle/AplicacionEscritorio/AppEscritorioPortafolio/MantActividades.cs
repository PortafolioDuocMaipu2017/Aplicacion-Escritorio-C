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
using System.Configuration;
using System.Data.OleDb;

namespace AppEscritorioPortafolio
{
    public partial class MantActividades : Form
    {
        OracleDataAdapter da = new OracleDataAdapter();

        public MantActividades()
        {
            InitializeComponent();
            DisplayData();
        }
        ///string ConString = "Data Source=XE;User Id=system;Password=12345;";
        OracleConnection con = new OracleConnection(@"Data Source=XE;User Id=system;Password=12345;");
        
        OracleCommand cmd;
        OracleDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  

        int ID = 0;
        //Display Data in DataGridView  
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();

            adapt = new OracleDataAdapter("select * from Tipo_Actividad", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data  
        private void ClearData()
        {
            txtNombre.Text = "";
            ID = 0;
        }
        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtNombre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        
        private void btnCrear_Click(object sender, EventArgs e)
        {          
            try
            {
                if (txtNombre.Text != "")
                {
                    string codigo = "insert into Tipo_Actividad (nombreTipoActividad) values(:nombre) ";
                    cmd = new OracleCommand(codigo, con);
                    MessageBox.Show(codigo);
                    con.Open();
                    cmd.Parameters.Add(":nombre", txtNombre.Text);
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
            catch (Exception esse)
            {

                MessageBox.Show(esse.ToString());
            }
        }

        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "")
                {
                    string update = "update Tipo_Actividad set nombreTipoActividad = :nombre where codigoTipoActividad = :id";
                    cmd = new OracleCommand(update, con);
                    
                    con.Open();
                    cmd.Parameters.Add(":nombre", txtNombre.Text);
                    cmd.Parameters.Add(":id", ID);                    
                    MessageBox.Show(ID + txtNombre.Text + update);
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
            catch (Exception esse)
            {

                MessageBox.Show(esse.ToString());
                con.Close();
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID != 0)
                {
                    string codigo = "delete Tipo_Actividad where codigoTipoActividad=:id";
                    cmd = new OracleCommand(codigo, con);
                    MessageBox.Show(codigo);
                    con.Open();
                    cmd.Parameters.Add(":id", ID);
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
            catch (Exception essse)
            {
                MessageBox.Show(essse.ToString());
                con.Close();
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
