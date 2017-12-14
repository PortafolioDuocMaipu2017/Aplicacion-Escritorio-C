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
    public partial class MantTipoServicio : Form
    {
        OracleDataAdapter da = new OracleDataAdapter();

        public MantTipoServicio()
        {
            InitializeComponent();
            DisplayData();
        }
        ///string ConString = "Data Source=XE;User Id=system;Password=12345;";
        OracleConnection con = new OracleConnection(@"Data Source=XE;User Id=PORTAFOLIO2;Password=12345;");

        OracleCommand cmd;
        OracleDataAdapter adapt;

        int ID = 0;
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();

            adapt = new OracleDataAdapter("select * from TipoServicio", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        //Clear Data  
        private void ClearData()
        {
            txtDescripcion.Text = "";
            txtValor.Text = "";
            ID = 0;
            btnCrear.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtValor.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnCrear.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }
        
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text != "")
                {
                    string codigo = "insert into TipoServicio (idtiposervicio, descripcionservicio, valorservicio) values(1,:descripcion, :valor) ";
                    cmd = new OracleCommand(codigo, con);
                    MessageBox.Show(codigo);
                    con.Open();
                    cmd.Parameters.Add(":descripcion", txtDescripcion.Text);
                    cmd.Parameters.Add(":valor", Convert.ToDecimal(txtValor.Text));
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
                if (txtDescripcion.Text != "")
                {
                    string update = "update TipoServicio set descripcionServicio = :descripcion, valorServicio = :valor where idtiposervicio = :id";
                    cmd = new OracleCommand(update, con);

                    con.Open();
                    cmd.Parameters.Add(":descripcion", txtDescripcion.Text);
                    cmd.Parameters.Add(":valor", Convert.ToDecimal(txtValor.Text));
                    cmd.Parameters.Add(":id", ID);
                    MessageBox.Show(ID + txtDescripcion.Text + update);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos Actualizados");
                    con.Close();
                    DisplayData();
                    ClearData();
                    btnCrear.Enabled = true;
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
                    string codigo = "delete TipoServicio where idtiposervicio=:id";
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

        private void btncancelar_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
