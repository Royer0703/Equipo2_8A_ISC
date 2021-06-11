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
    public partial class ventasFinal : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad

        DataSet dsTabla;

        int VarPagInicio = 1;
        // int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        int LimiteCredito;
        int totalCompraCliente;

        //fecha del dia de hoy 
        DateTime fecha = DateTime.Today;

        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_SalesVentas(obje);

            //dataGridView1.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) / TotalFilasAMostrar;
            //comboBox2.Items.Clear();

            if (Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) % TotalFilasAMostrar > 0)
            {
                cantidad += 1;
            }

            textBox3.Text = cantidad.ToString();

        }

        private void loadData()
        {
            //Variable de Cantiada a mostrar
            // int numMostra = (int.Parse(txt_DatosaMostar.Text));


            SqlCommand cmd;
            string sql = "select SalesVentas.idVenta,SalesVentas.fecha,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal";
               
            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 100, "SalesVentas");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;

        }

        public void Cargar_Datos_clienteNombre()
        {
            
        }

        public void Cargar_Datos_SucursalNombre()
        {
            

        }
        public void Cargar_Datos_EmpleadoNombre()
        {
           

        }


        

       



        public ventasFinal()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;

            loadData();
           
            LimiteCredito = 0;
            totalCompraCliente = 0;
           // txt_fecha.Text = fecha.ToShortDateString().ToString();
            

        }

        private void txt_DatosaMostar_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                ds.Clear();
                loadData();
            }
            else
            {
                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);
                ds.Clear();

                SqlCommand cmd;
                string sql = "select SalesVentas.idVenta,SalesVentas.fecha,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal";
                   
                    
                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesVentas");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;

            }
        }

        private void btn_adelante_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                int num = (int.Parse(txtCantidadTotal.Text));
                start = start + 2;
                btn_atras.Enabled = true;
                if (start > num)
                {
                    start = 0;
                }

                ds.Clear();
                adapter.Fill(ds, start, 2, "SalesVentas");
            }
            else
            {

                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);

                int num = (int.Parse(txtCantidadTotal.Text));
                start = start + numMostar;
                btn_atras.Enabled = true;
                if (start > num)
                {
                    start = 0;
                }

                ds.Clear();
                adapter.Fill(ds, start, numMostar, "SalesVentas");
            }
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                start = start - 2;
                if (start < 0)
                {
                    start = 0;
                    btn_atras.Enabled = false;
                }
                ds.Clear();
                adapter.Fill(ds, start, 2, "SalesVentas");
            }
            else
            {
                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);
                start = start - numMostar;
                if (start < 0)
                {
                    start = 0;
                    btn_atras.Enabled = false;
                }
                ds.Clear();
                adapter.Fill(ds, start, numMostar, "SalesVentas");
            }
        }

        private void txt_DatosaMostar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ds.Clear();
                loadData();
            }
            else
            {
                // string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERP;" +
                // "integrated security = true";
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
                con.Open();

                // SqlDataAdapter datos = new SqlDataAdapter("select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas  JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo where " + this.comboBox1.Text+ " like '%" + this.textBox1.Text + "%'", con);

                SqlDataAdapter datos = new SqlDataAdapter("select SalesVentas.idVenta,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesVentas");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SalesDetalleVentayVenta vf = new SalesDetalleVentayVenta();
            vf.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)//-GUARDAR EL IDVENTA
        {
            
        }

        private void Cb_idCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Cb_idSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Cb_idEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ventasFinal_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void ventasFinal_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void ventasFinal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void txtCantidadTotal_MouseHover(object sender, EventArgs e)
        {
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void txtCantidadTotal_MouseClick(object sender, MouseEventArgs e)
        {
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }
    }
}
