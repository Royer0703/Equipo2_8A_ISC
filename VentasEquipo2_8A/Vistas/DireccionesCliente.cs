using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;//new 
using System.Data.SqlClient;//new 

namespace Vistas
{
    public partial class DireccionesCliente : Form
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
            dsTabla = cn.N_listar_SalesDireccionesCliente(obje);

            dataGridViewDireccionesC.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) / TotalFilasAMostrar;
            comboBox2.Items.Clear();

            if (Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) % TotalFilasAMostrar > 0)
            {
                cantidad += 1;
            }

            textBox3.Text = cantidad.ToString();
            comboBox2.Items.Clear();

            for (int x = 1; x <= cantidad; x++)
            {
                comboBox2.Items.Add(x.ToString());
            }

            comboBox2.SelectedIndex = VarPagIndice;
        }
        public DireccionesCliente()
        {
            InitializeComponent();
            //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultaCliente();
            dataGridView1.DataSource = cn.ConsultaCiudadesDT();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            txtcp.Text = "";
            Cb_Estatus.Text = "";
            txtiddireccion.Text = "";
            txtnumero.Text = "";
            txtcolonia.Text = "";
            txtcalle.Text = "";
            txtidcliente.Text = "";
            txtidciudad.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtiddireccion.Text) || string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(txtidcliente.Text) || string.IsNullOrEmpty(txtidciudad.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";

                cn.modificarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, Cb_Estatus.Text, txtidcliente.Text, txtidciudad.Text);
                //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                MessageBox.Show("Direccion del Cliente eliminada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtcp.Text = "";
                Cb_Estatus.Text = "";
                txtiddireccion.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcalle.Text = "";
                txtidcliente.Text = "";
                txtidciudad.Text = "";

            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtiddireccion.Text) || string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(txtidcliente.Text) || string.IsNullOrEmpty(txtidciudad.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.modificarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, Estatus, txtidcliente.Text, txtidciudad.Text);
                //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                MessageBox.Show("Direccion del Cliente modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtcp.Text = "";
                Cb_Estatus.Text = "";
                txtiddireccion.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcalle.Text = "";
                txtidcliente.Text = "";
                txtidciudad.Text = "";

            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtiddireccion.Text) || string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) ||  string.IsNullOrEmpty(txtidcliente.Text) || string.IsNullOrEmpty(txtidciudad.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.insertarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, Estatus, txtidcliente.Text, txtidciudad.Text);
                //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                MessageBox.Show("Direccion del Cliente agregada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtcp.Text = "";
                Cb_Estatus.Text = "";
                txtiddireccion.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcalle.Text = "";
                txtidcliente.Text = "";
                txtidciudad.Text = "";
            }
            else
            {


                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

         
        }

        private void dataGridViewDireccionesC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtiddireccion.Text = dataGridViewDireccionesC.CurrentRow.Cells[0].Value.ToString();
            txtcalle.Text = dataGridViewDireccionesC.CurrentRow.Cells[1].Value.ToString();
            txtnumero.Text = dataGridViewDireccionesC.CurrentRow.Cells[2].Value.ToString();
            txtcolonia.Text = dataGridViewDireccionesC.CurrentRow.Cells[3].Value.ToString();
            txtcp.Text = dataGridViewDireccionesC.CurrentRow.Cells[4].Value.ToString();
            Cb_Estatus.Text = dataGridViewDireccionesC.CurrentRow.Cells[5].Value.ToString();
            txtidcliente.Text = dataGridViewDireccionesC.CurrentRow.Cells[6].Value.ToString();
            txtidciudad.Text = dataGridViewDireccionesC.CurrentRow.Cells[7].Value.ToString();

        }

        private void txtiddireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtidcliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtidciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtiddireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtcp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtidcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtidciudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtcalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtcolonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("Select idDireccion,calle,numero,colonia,codigoPostal,tipo,idCliente,idCiudad from SalesDireccionesCliente where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesDireccionesCliente");
            this.dataGridViewDireccionesC.DataSource = ds.Tables[0];
        }

        private void DireccionesCliente_MouseMove(object sender, MouseEventArgs e)
        {
            
            dataGridView2.DataSource = cn.ConsultaCliente();
            dataGridView1.DataSource = cn.ConsultaCiudadesDT();
        }

        private void DireccionesCliente_MouseClick(object sender, MouseEventArgs e)
        {
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultaCliente();
            dataGridView1.DataSource = cn.ConsultaCiudadesDT();
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
