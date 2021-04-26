using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using Entidad;//new 
using System.Data.SqlClient;//new 

namespace Vistas
{
    public partial class Parcelas : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;


        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_Parcelas(obje);
           
            dataGridView1.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) /TotalFilasAMostrar;
            comboBox2.Items.Clear();

            if (Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) % TotalFilasAMostrar > 0)
            {
                cantidad += 1;
            }

            textBox3.Text = cantidad.ToString();
            comboBox2.Items.Clear();

            for (int x =1; x <= cantidad; x++)
            {
                comboBox2.Items.Add(x.ToString());
            }

            comboBox2.SelectedIndex = VarPagIndice;
        }

        public Parcelas()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultaParcelasDT();
            dataGridView2.DataSource = cn.ConsultarClienteYDireClienteDT();
            dataGridView3.DataSource = cn.ConsultaCultivosDT();
        }
       







        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idParcelas.Text = " ";
            txt_Extension.Text = " ";
            txt_idCliente.Text = " ";
            txt_idCultivo.Text = " ";
            txt_idDireccion.Text = " ";
            Cb_Estatus.Text = " ";
            //dataGridView1.DataSource = cn.ConsultaParcelasDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultarClienteYDireClienteDT();
            dataGridView3.DataSource = cn.ConsultaCultivosDT();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.InsertarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                dataGridView2.DataSource = cn.ConsultarClienteYDireClienteDT();
                dataGridView3.DataSource = cn.ConsultaCultivosDT();

                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                Cb_Estatus.Text = " ";


                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }

        private void btnEditar_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.ModificarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                dataGridView2.DataSource = cn.ConsultarClienteYDireClienteDT();
                dataGridView3.DataSource = cn.ConsultaCultivosDT();

                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                Cb_Estatus.Text = " ";

                MessageBox.Show("Actualizados Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.ModificarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, Cb_Estatus.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                dataGridView2.DataSource = cn.ConsultarClienteYDireClienteDT();
                dataGridView3.DataSource = cn.ConsultaCultivosDT();

                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                Cb_Estatus.Text = " ";


                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }


        //modificar esto 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            txt_idParcelas.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Extension.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_idCliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_idCultivo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_idDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO TODOS LOS CAMPOS
        private void txt_idParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_Extension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idCultivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void Parcelas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eRPDataset.SalesParcelas' table. You can move, or remove it, as needed.
          



        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERP;" +
               // "integrated security = true";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("Select idParcela,extension,idCliente,idCultivo,idDireccion from SalesParcelas where " + this.comboBox1.Text+ " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesParcelas");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void Parcelas_MouseMove(object sender, MouseEventArgs e)
        {
            dataGridView2.DataSource = cn.ConsultarClienteYDireClienteDT();
            dataGridView3.DataSource = cn.ConsultaCultivosDT();
        }

        private void Parcelas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Parcelas_MouseClick(object sender, MouseEventArgs e)
        {
            //dataGridView1.DataSource = cn.ConsultaParcelasDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultarClienteYDireClienteDT();
            dataGridView3.DataSource = cn.ConsultaCultivosDT();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(comboBox2.Text);
            VarPagIndice = pagina - 1;
            VarPagInicio = (pagina - 1) * TotalFilasAMostrar + 1;
            VarPagFinal = pagina * TotalFilasAMostrar;
            Mostrar_datos();
        }
    }
}
