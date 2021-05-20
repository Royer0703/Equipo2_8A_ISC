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
    public partial class Ventas : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        // int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

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
            string sql = "select SalesVentas.idVenta, SalesVentas.fecha,SalesVentas.cantPagada,SalesVentas.idProducto,Productos.nombre,SalesVentas.subtotal,SalesVentas.iva,SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo  from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Productos ON Productos.idProducto = SalesVentas.idProducto";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesVentas");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;

        }

           

        public void Cargar_nombre_Productos()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Productos";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idProducto.Items.Add(dr["nombre"].ToString());
                Cb_idProducto.DisplayMember = (dr["nombre"].ToString());
                Cb_idProducto.ValueMember = (dr["nombre"].ToString());
            }

        }

        public void Cargar_Datos_clienteNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from SalesClientes";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idCliente.Items.Add(dr["nombre"].ToString());
                Cb_idCliente.DisplayMember = (dr["nombre"].ToString());
                Cb_idCliente.ValueMember = (dr["nombre"].ToString());
            }

        }

        public void Cargar_Datos_SucursalNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Sucursales";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idSucursal.Items.Add(dr["nombre"].ToString());
                Cb_idSucursal.DisplayMember = (dr["nombre"].ToString());
                Cb_idSucursal.ValueMember = (dr["nombre"].ToString());
            }

        }
        public void Cargar_Datos_EmpleadoNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Empleados";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idEmpleado.Items.Add(dr["nombre"].ToString());
                Cb_idEmpleado.DisplayMember = (dr["nombre"].ToString());
                Cb_idEmpleado.ValueMember = (dr["nombre"].ToString());
            }

        }






        public Ventas()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            
            loadData();
            Cargar_nombre_Productos();
            Cargar_Datos_clienteNombre();
            Cargar_Datos_SucursalNombre();
            Cargar_Datos_EmpleadoNombre();
        }

        

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void Cb_idProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select Productos.idProducto, PresentacionesProducto.precioVenta from Productos JOIN PresentacionesProducto ON PresentacionesProducto.idProducto = Productos.idProducto where Productos.nombre ='" + Cb_idProducto.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txt_idProducto.Text = dr[0].ToString();
                txt_precioVenta.Text = dr[1].ToString();

                if (string.IsNullOrEmpty(txt_precioVenta.Text))
                {
                    txt_subtotal.Text = "";
                    txt_iva.Text = "";
                    txt_total.Text = "";

                }
                else
                {
                    string id = this.txt_cantPagada.Text;
                    int Cantida = Int32.Parse(id);//textbox de cantidad

                    string ids = this.txt_precioVenta.Text;
                    int Precio = Int32.Parse(ids);//textbox de Precio


                    int subTotal = (Precio * Cantida);//calculo de subtotal

                    int Iva = (int)(subTotal * 0.16);//calculo de IVA

                    int Total = (subTotal + Iva);//calculo de Total

                    txt_subtotal.Text = subTotal.ToString();
                    txt_iva.Text = Iva.ToString();
                    txt_total.Text = Total.ToString();


                }







            }

            con.Close();
        }

        private void Cb_idCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idCliente from SalesClientes where nombre ='" + Cb_idCliente.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idCliente.Text = dr[0].ToString();
            }

            con.Close();
        }

        private void Cb_idSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idSucursal from Sucursales where nombre ='" + Cb_idSucursal.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idSucursal.Text = dr[0].ToString();
            }

            con.Close();
        }

        private void Cb_idEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idEmpleado from Empleados where nombre ='" + Cb_idEmpleado.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idEmpleado.Text = dr[0].ToString();
            }

            con.Close();
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
                string sql = "select SalesVentas.idVenta, SalesVentas.fecha,SalesVentas.cantPagada,SalesVentas.idProducto,Productos.nombre,SalesVentas.subtotal,SalesVentas.iva,SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Productos ON Productos.idProducto = SalesVentas.idProducto";

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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesVentas.idVenta, SalesVentas.fecha,SalesVentas.cantPagada,SalesVentas.idProducto,Productos.nombre,SalesVentas.subtotal,SalesVentas.iva,SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo  from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Productos ON Productos.idProducto = SalesVentas.idProducto where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesVentas");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_cantPagada.Text) || string.IsNullOrEmpty(txt_comentarios.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_idProducto.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre de Producto !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idSucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre de Sucursal !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Nombre de Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_tipo.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el tipo de venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || Cb_idProducto.SelectedIndex > 0 || Cb_idProducto.SelectedIndex == 0 || Cb_idSucursal.SelectedIndex > 0 || Cb_idSucursal.SelectedIndex == 0 || Cb_idEmpleado.SelectedIndex > 0 || Cb_idEmpleado.SelectedIndex == 0 || Cb_tipo.SelectedIndex > 0 || Cb_tipo.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string tipo = Cb_tipo.SelectedItem.ToString();

                cn.InsertarSalesVentasDT(txt_fecha.Text, txt_cantPagada.Text, txt_idProducto.Text, txt_subtotal.Text, txt_iva.Text, txt_total.Text, txt_comentarios.Text, Estatus, txt_idCliente.Text, txt_idSucursal.Text, txt_idEmpleado.Text, tipo);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                //txt_idVenta.Text = " ";
                txt_cantPagada.Text = " ";
                txt_idCliente.Text = " ";
                txt_idEmpleado.Text = " ";
                txt_idProducto.Text = " ";
                txt_fecha.Text = " ";
                txt_idSucursal.Text = " ";
                txt_iva.Text = " ";
                txt_subtotal.Text = " ";
                txt_total.Text = " ";
                txt_comentarios.Text = " ";
                Cb_idProducto.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                Cb_idCliente.SelectedIndex = -1;
                Cb_idSucursal.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                Cb_tipo.SelectedIndex = -1;
                txt_precioVenta.Text = " ";

                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Guardar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_cantPagada.Text) || string.IsNullOrEmpty(txt_comentarios.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_idProducto.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre de Producto !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idSucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre de Sucursal !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Nombre de Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_tipo.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el tipo de venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || Cb_idProducto.SelectedIndex > 0 || Cb_idProducto.SelectedIndex == 0 || Cb_idSucursal.SelectedIndex > 0 || Cb_idSucursal.SelectedIndex == 0 || Cb_idEmpleado.SelectedIndex > 0 || Cb_idEmpleado.SelectedIndex == 0 || Cb_tipo.SelectedIndex > 0 || Cb_tipo.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string tipo = Cb_tipo.SelectedItem.ToString();

                cn.ModificarSalesVentasDT(txt_idVenta.Text, txt_fecha.Text, txt_cantPagada.Text, txt_idProducto.Text, txt_subtotal.Text, txt_iva.Text, txt_total.Text, txt_comentarios.Text, Estatus, txt_idCliente.Text, txt_idSucursal.Text, txt_idEmpleado.Text, tipo);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                txt_idVenta.Text = " ";
                txt_cantPagada.Text = " ";
                txt_idCliente.Text = " ";
                txt_idEmpleado.Text = " ";
                txt_idProducto.Text = " ";
                txt_fecha.Text = " ";
                txt_idSucursal.Text = " ";
                txt_iva.Text = " ";
                txt_subtotal.Text = " ";
                txt_total.Text = " ";
                txt_comentarios.Text = " ";
                Cb_idProducto.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                Cb_idCliente.SelectedIndex = -1;
                Cb_idSucursal.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                Cb_tipo.SelectedIndex = -1;
                txt_precioVenta.Text = " ";

                MessageBox.Show("Actualizados correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Editar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_cantPagada.Text) || string.IsNullOrEmpty(txt_comentarios.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_idProducto.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre de Producto !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idSucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre de Sucursal !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Nombre de Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_tipo.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el tipo de venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || Cb_idProducto.SelectedIndex > 0 || Cb_idProducto.SelectedIndex == 0 || Cb_idSucursal.SelectedIndex > 0 || Cb_idSucursal.SelectedIndex == 0 || Cb_idEmpleado.SelectedIndex > 0 || Cb_idEmpleado.SelectedIndex == 0 || Cb_tipo.SelectedIndex > 0 || Cb_tipo.SelectedIndex == 0)
            {
                //string Estatus = Cb_Estatus.SelectedItem.ToString();
                string tipo = Cb_tipo.SelectedItem.ToString();
                Cb_Estatus.Text = "I";

                cn.ModificarSalesVentasDT(txt_idVenta.Text, txt_fecha.Text, txt_cantPagada.Text, txt_idProducto.Text, txt_subtotal.Text, txt_iva.Text, txt_total.Text, txt_comentarios.Text, Cb_Estatus.Text, txt_idCliente.Text, txt_idSucursal.Text, txt_idEmpleado.Text, tipo);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                txt_idVenta.Text = " ";
                txt_cantPagada.Text = " ";
                txt_idCliente.Text = " ";
                txt_idEmpleado.Text = " ";
                txt_idProducto.Text = " ";
                txt_fecha.Text = " ";
                txt_idSucursal.Text = " ";
                txt_iva.Text = " ";
                txt_subtotal.Text = " ";
                txt_total.Text = " ";
                txt_comentarios.Text = " ";
                Cb_idProducto.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                Cb_idCliente.SelectedIndex = -1;
                Cb_idSucursal.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                Cb_tipo.SelectedIndex = -1;
                txt_precioVenta.Text = " ";

                MessageBox.Show("Eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Eliminar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idVenta.Text = " ";
            txt_cantPagada.Text = " ";
            txt_idCliente.Text = " ";
            txt_idEmpleado.Text = " ";
            txt_idProducto.Text = " ";
            txt_fecha.Text = " ";
            txt_idSucursal.Text = " ";
            txt_iva.Text = " ";
            txt_subtotal.Text = " ";
            txt_total.Text = " ";
            txt_comentarios.Text = " ";
            Cb_idProducto.SelectedIndex = -1;
            Cb_Estatus.SelectedIndex = -1;
            Cb_idCliente.SelectedIndex = -1;
            Cb_idSucursal.SelectedIndex = -1;
            Cb_idEmpleado.SelectedIndex = -1;
            Cb_tipo.SelectedIndex = -1;
            txt_precioVenta.Text = " ";

            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();

        }

        private void txt_comentarios_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_precioVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idVenta.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fecha.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_cantPagada.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Cb_idProducto.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_subtotal.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_iva.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_total.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_comentarios.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            Cb_idCliente.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            Cb_idSucursal.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            Cb_idEmpleado.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            Cb_tipo.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();


        }

        private void txt_cantPagada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_comentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }

            if (string.IsNullOrEmpty(txt_precioVenta.Text))
            {
                txt_subtotal.Text = "";
                txt_iva.Text = "";
                txt_total.Text = "";
                Cb_idProducto.SelectedIndex = -1;

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
    }
}

