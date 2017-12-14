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
    public partial class MantDestinos : Form
    {
        OracleDataAdapter da = new OracleDataAdapter();

        public MantDestinos()
        {
            InitializeComponent();
            DisplayData();
        }
        ///string ConString = "Data Source=XE;User Id=system;Password=12345;";
        OracleConnection con = new OracleConnection(@"Data Source=XE;User Id=PORTAFOLIO2;Password=12345;");

        OracleCommand cmd;
        OracleCommand cmd2;
        OracleDataAdapter adapt;
        OracleDataAdapter adapt2;
        int ID = 0;
        private void DisplayData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new OracleDataAdapter("select * from Destino", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                
                //Try3

                con.Open();
                DataTable dt3 = new DataTable();
                adapt = new OracleDataAdapter("select * from Ciudad", con);
                adapt.Fill(dt3);
                cbCiudad.DataSource = dt3;
                cbCiudad.DisplayMember = "ciudad"; //campo que queres mostrar
                cbCiudad.ValueMember = "idCiudad"; //valor que capturas
                con.Close();

            }
            catch (Exception xd)
            {
                con.Close();
                MessageBox.Show(xd.ToString());
            }
           

        }
        //Clear Data  
        private void ClearData()
        {
            txtDireccion.Text = "";
            ID = 0;
            btnCrear.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtDireccion.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbCiudad.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtValor.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            btnCrear.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDireccion.Text != "")
                {
                    string codigo = "insert into Destino (iddestino, nombredestino, ciudad_idciudad, valorDestino) values(1, :direccion,:ciudad,:valor) ";
                    cmd = new OracleCommand(codigo, con);
                    MessageBox.Show(codigo);
                    con.Open();
                    
                    cmd.Parameters.Add(":direccion", txtDireccion.Text);
                    cmd.Parameters.Add(":ciudad", cbCiudad.SelectedValue);
                    cmd.Parameters.Add(":valor", Convert.ToInt32(txtValor.Text));
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
                con.Close();
                MessageBox.Show(esse.ToString());
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDireccion.Text != "")
                {
                    string update = "update Destino set nombredestino =: direccion, ciudad_idciudad =:ciudad, valorDestino =:valor where idDestino = :id";
                    cmd = new OracleCommand(update, con);

                    con.Open();
                    cmd.Parameters.Add(":direccion", txtDireccion.Text);
                    cmd.Parameters.Add(":ciudad", cbCiudad.SelectedValue);
                    cmd.Parameters.Add(":valor", Convert.ToInt32(txtValor.Text));
                    cmd.Parameters.Add(":id", ID);
                    MessageBox.Show(ID + txtDireccion.Text + update);
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
                    string codigo = "delete Destino where idDestino=:id";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantPais pais = new MantPais();
            pais.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MantCiudad ciuda = new MantCiudad();
            ciuda.Show();
        }

        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            MantCiudad ciuda = new MantCiudad();
            ciuda.Show();
        }
    }
}
