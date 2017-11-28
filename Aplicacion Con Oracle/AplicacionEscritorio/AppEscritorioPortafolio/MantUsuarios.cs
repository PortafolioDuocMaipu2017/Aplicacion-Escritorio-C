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
    public partial class MantUsuarios : Form
    {
        OracleDataAdapter da = new OracleDataAdapter();

        public MantUsuarios()
        {
            InitializeComponent();
            DisplayData();
        }
        ///string ConString = "Data Source=XE;User Id=system;Password=12345;";
        OracleConnection con = new OracleConnection(@"Data Source=XE;User Id=system;Password=12345;");

        OracleCommand cmd;
        OracleDataAdapter adapt;

        int ID = 0;
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();

            adapt = new OracleDataAdapter("select * from Usuario", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        //Clear Data  
        private void ClearData()
        {
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtEstado.Text = "";
            ID = 0;
            btnCrear.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtUsuario.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPass.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEstado.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtUsuario.Enabled = false;
            btnCrear.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }
        
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text != "" && txtPass.Text != "")
                {
                    if (txtEstado.Text == "1" || txtEstado.Text == "0")
                    {
                        string codigo = "insert into Usuario (loginUsuario, pw, estado) values(:nombre,:pw,:estado) ";
                        cmd = new OracleCommand(codigo, con);
                        MessageBox.Show(codigo);
                        con.Open();
                        cmd.Parameters.Add(":nombre", txtUsuario.Text);
                        cmd.Parameters.Add(":rol", txtPass.Text);
                        cmd.Parameters.Add(":estado", Convert.ToInt32(txtEstado.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos Actualizados");
                        con.Close();
                        DisplayData();
                        ClearData();
                    }else
                    {
                        con.Close();
                        MessageBox.Show("El estado tiene que ser 1 o 0");
                    }
                }
                else
                {
                    con.Close();
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
                
                if (txtUsuario.Text != "" && txtPass.Text != "")
                {
                    if (txtEstado.Text == "1" || txtEstado.Text =="0")
                    {


                        string update = "update Usuario set loginUsuario = :nombre, pw =:pass, estado=:estado where loginUsuario = :id";
                        cmd = new OracleCommand(update, con);

                        con.Open();
                        cmd.Parameters.Add(":nombre", txtUsuario.Text);
                        cmd.Parameters.Add(":pass", txtPass.Text);
                        cmd.Parameters.Add(":estado", Convert.ToInt32(txtEstado.Text));
                        cmd.Parameters.Add(":id", txtUsuario.Text);
                        MessageBox.Show(ID + txtUsuario.Text + update);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos Actualizados");
                        con.Close();
                        DisplayData();
                        ClearData();
                        btnCrear.Enabled = true;
                    }else
                    {
                        con.Close();
                        MessageBox.Show("El estado tiene que ser 1 o 0");
                    }
                }
                else
                {
                    con.Close();
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
                if (txtUsuario.Text != "")
                {
                    string codigo = "delete Usuario where loginUsuario=:id";
                    cmd = new OracleCommand(codigo, con);
                    MessageBox.Show(codigo);
                    con.Open();
                    cmd.Parameters.Add(":id", txtUsuario.Text);
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
