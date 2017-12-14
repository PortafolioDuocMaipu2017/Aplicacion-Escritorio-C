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
    public partial class MantRol : Form
    {

        OracleDataAdapter da = new OracleDataAdapter();

        public MantRol()
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

            adapt = new OracleDataAdapter("select * from Rol", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            //Try3

            con.Open();
            DataTable dt3 = new DataTable();
            adapt = new OracleDataAdapter("select * from Usuario", con);
            adapt.Fill(dt3);
            cbUsuario.DataSource = dt3;
            cbUsuario.DisplayMember = "nombreusuario"; //campo que queres mostrar
            cbUsuario.ValueMember = "nombreusuario"; //valor que capturas
            con.Close();
        }
        //Clear Data  
        private void ClearData()
        {

            txtRol.Text = "";
            ID = 0;
            btnCrear.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            cbUsuario.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRol.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            btnCrear.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }
        
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRol.Text != "")
                {
                    if (txtRol.Text == "administrador" || txtRol.Text == "ejecutivo" || txtRol.Text == "apoderado")
                    {
                        string codigo = "insert into Rol (idrol, nombrerol, usuario_nombreusuario) values(1, :rol ,:nombre) ";
                        cmd = new OracleCommand(codigo, con);
                        MessageBox.Show(codigo);
                        con.Open();
                        cmd.Parameters.Add(":rol", txtRol.Text);
                        cmd.Parameters.Add(":nombre", cbUsuario.SelectedValue);                        
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos Actualizados");
                        con.Close();
                        DisplayData();
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("El rol debe ser 'administrador', 'ejecutivo' o 'apoderado'");
                    }
                    
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
                if (txtRol.Text != "")
                {
                    if (txtRol.Text == "administrador" || txtRol.Text == "ejecutivo" || txtRol.Text == "apoderado")
                    {
                        string update = "update Rol set usuario_nombreusuario = :nombre, nombreRol =:rol where idrol = :id";
                        cmd = new OracleCommand(update, con);

                        con.Open();
                        cmd.Parameters.Add(":nombre", cbUsuario.SelectedValue);
                        cmd.Parameters.Add(":nombre", txtRol.Text);
                        cmd.Parameters.Add(":id", ID);
                        MessageBox.Show(ID + txtRol.Text + update);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Datos Actualizados");
                        con.Close();
                        DisplayData();
                        ClearData();
                        btnCrear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El rol debe ser 'administrador', 'ejecutivo' o 'apoderado'");
                    }
                        
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
                    string codigo = "delete Rol where idrol=:id";
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
