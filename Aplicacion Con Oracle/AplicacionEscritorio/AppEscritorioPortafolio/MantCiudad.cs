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
    public partial class MantCiudad : Form
    {
        OracleDataAdapter da = new OracleDataAdapter();

        public MantCiudad()
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
            adapt = new OracleDataAdapter("select * from Ciudad", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            //Mostrar ComboBox
            con.Open();
            DataTable dt2 = new DataTable();
            adapt = new OracleDataAdapter("select * from Pais", con);
            adapt.Fill(dt2);

            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "nombrePais"; //campo que queres mostrar
            comboBox1.ValueMember = "idpais"; //valor que capturas
            con.Close();

        }
        //Clear Data  
        private void ClearData()
        {
            txtCiudad.Text = "";
            ID = 0;
            btnCrear.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        
        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCiudad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            
            btnCrear.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }
        
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCiudad.Text != "")
                {
                    string codigo = "insert into Ciudad (pais_idpais, ciudad) values(:pais,:ciudad) ";
                    cmd = new OracleCommand(codigo, con);
                    MessageBox.Show(codigo);
                    con.Open();
                    cmd.Parameters.Add(":pais", comboBox1.SelectedValue);
                    cmd.Parameters.Add(":ciudad", txtCiudad.Text);
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
                if (txtCiudad.Text != "")
                {
                    string update = "update Ciudad set pais_idpais = :pais, ciudad =:ciudad where idciudad = :id";
                    cmd = new OracleCommand(update, con);

                    con.Open();
                    cmd.Parameters.Add(":pais", comboBox1.SelectedValue);
                    cmd.Parameters.Add(":ciudad", txtCiudad.Text);
                    cmd.Parameters.Add(":id", ID);
                    MessageBox.Show(ID + txtCiudad.Text + update);
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
                    string codigo = "delete Ciudad where idciudad=:id";
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
    }
}
