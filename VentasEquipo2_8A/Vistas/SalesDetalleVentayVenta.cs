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
    public partial class SalesDetalleVentayVenta : Form
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
        SqlConnection con1 = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlConnection con2 = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        DateTime fecha = DateTime.Today;
        int Cantida;
        int subTotalFinalVenta;

        int LimiteCredito;
        int totalCompraCliente;

        int CantVenta;
        int exisSucursal1;

        int Precio;

        int idClienteOferta;
        int idCliente;

        int subtotal;

        int SubTotalParaDesc;
        int idPresentatacionVenta;
        int idPresentatacionOferta;
        int CantVentav;
        int CantminOferta;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_SalesVentaDetalle(obje);

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

            if (Cb_idVenta.SelectedIndex <= -1)
            {
                SqlCommand cmd;
                string sql = "select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto";//modificado

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, 2, "SalesVentaDetalle");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;
            }

        }

        public void Cargar_Datos_idVentas()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select idVenta from SalesVentas";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idVenta.Items.Add(dr["idVenta"].ToString());
                Cb_idVenta.DisplayMember = (dr["idVenta"].ToString());
                Cb_idVenta.ValueMember = (dr["idVenta"].ToString());
            }
            con.Close();

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
            con.Close();

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
            con.Close();

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
            con.Close();
        }



        public void Cargar_Datos_idProductos()
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
            con.Close();
        }










        public SalesDetalleVentayVenta()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            loadData();
            Mostrar_datos();
            Cargar_Datos_idVentas();
            Cargar_Datos_clienteNombre();
            Cargar_Datos_SucursalNombre();
            Cargar_Datos_EmpleadoNombre();
            Cargar_Datos_idProductos();
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            //ventadetalle btn
            btn_GuardarDetalleventa.Enabled = false;
            btn_EDITARDetalleventa.Enabled = false;
            btn_ELIMINARDetalleventa.Enabled = false;
            btn_NUEVODetalleventa.Enabled = false;


            txt_fecha.Text = fecha.ToShortDateString().ToString();
            Cantida = 0;
            subTotalFinalVenta = 0;

            LimiteCredito = 0;
            totalCompraCliente = 0;

            CantVenta = 0;
            exisSucursal1 = 0;

            Precio = 0;

            idClienteOferta = 0;
            idCliente = 0;
            subtotal = 0;


            SubTotalParaDesc = 0;
            idPresentatacionVenta = 0;
            idPresentatacionOferta = 0;
             CantVentav = 0;
            CantminOferta = 0;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Cb_idVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                ds.Clear();
                loadData();
            }
            else
            {

                SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto WHERE SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'", con);//modificado
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesVentaDetalle");
                this.dataGridView1.DataSource = ds.Tables[0];


                btnGuardar.Enabled = false;


            }
            
            con1.Open();
            string q = "SELECT SUM(subtotal) Total FROM SalesVentaDetalle where idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();
                txt_subTotalVenta.Text = dr[0].ToString();


            }

            if (string.IsNullOrEmpty(txt_subTotalVenta.Text))
            {
                txt_subTotalVenta.Text = "";
            }
            else
            {
                string Sub = this.txt_subTotalVenta.Text;
                subTotalFinalVenta = Int32.Parse(Sub);//textbox de Precio

                int subTotal = (subTotalFinalVenta);//calculo de subtotal

                int Iva = (int)(subTotal * 0.16);//calculo de IVA

                int Total = (subTotal + Iva);//calculo de Total

                txt_subTotalVenta.Text = subTotal.ToString();

                txt_ivaVenta.Text = Iva.ToString();
                txt_totalVenta.Text = Total.ToString();



                cn.ModificarSalesVentasDT(Cb_idVenta.Text, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text);//modifica 

            }

            con1.Close();


            con2.Open();
            string qxe = "select SalesVentas.idVenta,SalesVentas.fecha,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,existenciaSucursales.cantidad,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN existenciaSucursales ON existenciaSucursales.idSucursal = SalesVentas.idSucursal where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmdxe = new SqlCommand(qxe, con2);
            SqlDataReader drxe = cmdxe.ExecuteReader();
            while (drxe.Read())
            {

                txt_fecha.Text = drxe[1].ToString();//--
                Cb_idCliente.Text = drxe[9].ToString();//--
                txt_clienteVenta.Text = drxe[9].ToString();//--
                txt_CantPagada.Text = drxe[2].ToString();//--
                txt_Subtotal.Text = drxe[3].ToString();//--
                txt_iva.Text = drxe[4].ToString();//--
                txt_Total.Text = drxe[5].ToString();//--
                txt_comentarios.Text = drxe[6].ToString();//--
                Cb_idSucursal.Text = drxe[11].ToString();//--
                                                         // txt_ExistenciaSucursal.Text = drx[12].ToString();//--
                Cb_idEmpleado.Text = drxe[14].ToString();//--
                txt_Estatus.Text = drxe[7].ToString();//--
                txt_tipoVenta.Text = drxe[15].ToString();//--

                string idClient = this.txt_idCliente.Text;
                idCliente = Int32.Parse(idClient);//textbox de Precio




                String EstatusActual = "A";
                string estatusSalesVenta = txt_Estatus.Text;

                string Credito = txt_tipoVenta.Text;
                string CreditoAprobado = "CREDITO";

                if (estatusSalesVenta == EstatusActual)//si la Venta fue pagada validar 
                {
                    MessageBox.Show("La Venta ya fue Pagada no se puede agregar nada mas !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;

                    //
                    btn_GuardarDetalleventa.Enabled = false;
                    btn_EDITARDetalleventa.Enabled = false;
                    btn_ELIMINARDetalleventa.Enabled = false;
                    btn_NUEVODetalleventa.Enabled = false;
                    btnExcel.Enabled = true;


                }
                else if(estatusSalesVenta != EstatusActual)//no ha sido pagada
                {
                    btn_GuardarDetalleventa.Enabled = true;
                    btn_NUEVODetalleventa.Enabled = true;


                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;

                    if (Credito == CreditoAprobado)
                    {
                        MessageBox.Show("Credito ya fue Aprobado no puedes modificar la venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        btnGuardar.Enabled = false;
                        btnEditar.Enabled = false;
                        btnEliminar.Enabled = true;

                        //
                        btn_GuardarDetalleventa.Enabled = false;
                        btn_EDITARDetalleventa.Enabled = false;
                        btn_ELIMINARDetalleventa.Enabled = false;
                        btn_NUEVODetalleventa.Enabled = false;
                    }
                    else if (Credito != CreditoAprobado)
                    {
                        btn_GuardarDetalleventa.Enabled = true;
                        btn_NUEVODetalleventa.Enabled = true;


                        btnEditar.Enabled = true;
                        btnEliminar.Enabled = true;
                    }
                }
            }

            con2.Close();

            if (Cb_idVenta.SelectedIndex >= 0)//mostrar la tabla de ofertas
            {
             
                SqlDataAdapter datos = new SqlDataAdapter("Select SalesOfertasAsociacion.idAsosiacion,SalesMiembros.idCliente,SalesClientes.nombre,SalesOfertasAsociacion.idOferta,PresentacionesProducto.idProducto,Productos.nombre,PresentacionesProducto.idPresentacion,Empaques.nombre,Ofertas.nombre,Ofertas.canMinProductos,Ofertas.fechaInicio,Ofertas.fechaFin,Ofertas.porDescuento from SalesOfertasAsociacion JOIN SalesMiembros ON SalesMiembros.idAsosiacion = SalesOfertasAsociacion.idAsosiacion   JOIN SalesClientes ON SalesClientes.idCliente = SalesMiembros.idCliente JOIN Ofertas ON Ofertas.idOferta = SalesOfertasAsociacion.idOferta JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = Ofertas.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto where SalesMiembros.idCliente ='" + txt_idCliente.Text + "'", con);//modificado
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesOfertasAsociacion");
                this.dataGridView2.DataSource = ds.Tables[0];
            }




        }

        private void Cb_idCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            con1.Open();
            string qw = "select idCliente,limiteCredito from SalesClientes where nombre ='" + Cb_idCliente.SelectedItem + "'";
            SqlCommand cmdw = new SqlCommand(qw, con1);
            SqlDataReader drw = cmdw.ExecuteReader();
            while (drw.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idCliente.Text = drw[0].ToString();
                txt_limiteCeditoCliente.Text = drw[1].ToString();

                string ids = this.txt_limiteCeditoCliente.Text;
                LimiteCredito = Int32.Parse(ids);//textbox de Precio
            }

            con1.Close();


        }

        private void Cb_idSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            con1.Open();
            string q = "select idSucursal from Sucursales where nombre ='" + Cb_idSucursal.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idSucursal.Text = dr[0].ToString();
            }

            con1.Close();
        }

        private void Cb_idEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            con1.Open();
            string q = "select idEmpleado from Empleados where nombre ='" + Cb_idEmpleado.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idEmpleado.Text = dr[0].ToString();
            }

            con1.Close();
        }

        private void txt_iva_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idPresentacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idProducto.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Producto !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (exisSucursal1 < CantVenta)
            {
                MessageBox.Show("No hay suficiente Existencia en la Sucursal !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idPresentacion.SelectedIndex > -1 || Cb_idProducto.SelectedIndex > -1)///validar si la cant no rebas la  cantidadExistencia
            {
                string CantV = this.txt_cantidad.Text;
                int CantTextBox = Int32.Parse(CantV);//textbox de Cant

                string tabla = this.txt_cantidadActualTabla.Text;
                int cantventaDetalle = Int32.Parse(tabla);//textbox de cant de la tabla salesVentasDetalle


                string exci = this.txt_existenciaPresentacion.Text;
                int existenciaSucursal = Int32.Parse(exci);//textbox de cant de la tabla salesVentas

                if (txt_idExistenciaSucursal.Text == "1") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }
                if (txt_idExistenciaSucursal.Text == "2") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }
                if (txt_idExistenciaSucursal.Text == "3") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }
                if (txt_idExistenciaSucursal.Text == "4") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }
                if (txt_idExistenciaSucursal.Text == "5") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }
                if (txt_idExistenciaSucursal.Text == "6") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }
                if (txt_idExistenciaSucursal.Text == "7") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }
                if (txt_idExistenciaSucursal.Text == "8") // esta en suc 1 que tiene idpresentacion 1 y 2
                {
                    if (txt_cantidad.Text == txt_cantidadActualTabla.Text)
                    {
                        MessageBox.Show("Los datos se quedaron igual no hubo modificacion en Cantidad y Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (CantTextBox < cantventaDetalle) //si el txt es menor que el de la tabla 
                    {
                        int resta = (cantventaDetalle - CantTextBox);

                        int suma = (existenciaSucursal + resta);//suma los que se regresaron 

                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, suma.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                    }
                    if (CantTextBox > cantventaDetalle) //si el txt es mayor que el de la tabla 
                    {
                        int resta = (CantTextBox - cantventaDetalle);

                        int restaFinal = (existenciaSucursal - resta);//le quita los que agrego 
                        cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                        cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, restaFinal.ToString());//modifia la existencia de la suc
                        MessageBox.Show("Datos Modificados!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();
                    }
                }

                con.Open();
                string q = "SELECT SUM(subtotal) Total FROM SalesVentaDetalle where idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //string idCliente = (string)dr["idCliente"].ToString();
                    // txt_idCliente.Text = dr[0].ToString();
                    txt_subTotalVenta.Text = dr[0].ToString();
                    string Sub = this.txt_subTotalVenta.Text;
                    subTotalFinalVenta = Int32.Parse(Sub);//textbox de Precio

                }


                int subTotal = (subTotalFinalVenta);//calculo de subtotal

                int Iva = (int)(subTotal * 0.16);//calculo de IVA

                int Total = (subTotal + Iva);//calculo de Total

                txt_subTotalVenta.Text = subTotal.ToString();

                txt_ivaVenta.Text = Iva.ToString();
                txt_totalVenta.Text = Total.ToString();



                cn.ModificarSalesVentasDT(Cb_idVenta.Text, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text);//modifica 
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                con.Close();

                con.Open();
                string qx = "select SalesVentas.idVenta,SalesVentas.fecha,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,existenciaSucursales.cantidad,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN existenciaSucursales ON existenciaSucursales.idSucursal = SalesVentas.idSucursal where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmdx = new SqlCommand(qx, con);
                SqlDataReader drx = cmdx.ExecuteReader();
                while (drx.Read())
                {

                    txt_fecha.Text = drx[1].ToString();//--
                    Cb_idCliente.Text = drx[9].ToString();//--
                    txt_clienteVenta.Text = drx[9].ToString();//--
                    txt_CantPagada.Text = drx[2].ToString();//--
                    txt_Subtotal.Text = drx[3].ToString();//--
                    txt_iva.Text = drx[4].ToString();//--
                    txt_Total.Text = drx[5].ToString();//--
                    txt_comentarios.Text = drx[6].ToString();//--
                    Cb_idSucursal.Text = drx[11].ToString();//--
                                                            // txt_ExistenciaSucursal.Text = drx[12].ToString();//--
                    Cb_idEmpleado.Text = drx[14].ToString();//--
                    txt_Estatus.Text = drx[7].ToString();//--
                    txt_tipoVenta.Text = drx[15].ToString();//--




                }

                con.Close();


                con.Open();
                if (Cb_idVenta.SelectedIndex <= -1)
                {
                    ds.Clear();
                    loadData();
                }
                else
                {

                    SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto WHERE SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'", con);//modificado
                    DataSet ds = new DataSet();
                    datos.Fill(ds, "SalesVentaDetalle");
                    this.dataGridView1.DataSource = ds.Tables[0];


                    btn_GuardarDetalleventa.Enabled = true;
                    MessageBox.Show("Venta Actualizada!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                con.Close();


                txt_idventaDetalle.Text = " ";
                // txt_precioVenta.Text = " ";
                //  txt_cantidad.Text = " ";
                txt_subtotalventaDetalles.Text = " ";
                txt_idPresentacionVentadetalle.Text = " ";
                txt_idproducto.Text = "";
                // Cb_idVenta.SelectedIndex = -1;
                Cb_idProducto.SelectedIndex = -1;
                Cb_idPresentacion.SelectedIndex = -1;
                txt_idExistenciaSucursal.Text = "";

                btn_EDITARDetalleventa.Enabled = false;
                btn_ELIMINARDetalleventa.Enabled = false;
                btn_GuardarDetalleventa.Enabled = true;



            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_comentarios.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (Cb_idSucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre de Sucursal !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Nombre de Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idCliente.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idSucursal.SelectedIndex > 0 || Cb_idSucursal.SelectedIndex == 0 || Cb_idEmpleado.SelectedIndex > 0 || Cb_idEmpleado.SelectedIndex == 0)
            {
                string Estatus = "C";//CAPTURA
                string tipo = "CONTADO";
                string cantPagada = "0";
                string subTotal = "0";
                string iva = "0";
                string Total = "0";
                cn.InsertarSalesVentasDT(txt_fecha.Text, cantPagada, subTotal, iva, Total, txt_comentarios.Text, Estatus, txt_idCliente.Text, txt_idSucursal.Text, txt_idEmpleado.Text, tipo);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                //CIERRA LA VENTA UNA GUARADAD

                txt_idCliente.Text = " ";
                txt_idEmpleado.Text = " ";
                txt_fecha.Text = " ";
                txt_idSucursal.Text = " ";
                txt_comentarios.Text = " ";

                Cb_idCliente.SelectedIndex = -1;
                Cb_idSucursal.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                Cb_idVenta.Enabled = true;


                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Guardar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {


            txt_idEmpleado.Text = " ";
            txt_limiteCeditoCliente.Text = "";
            txt_idSucursal.Text = " ";
            txt_comentarios.Text = " ";
            txt_CantPagada.Text = "";
            txt_Subtotal.Text = "";
            txt_iva.Text = "";
            txt_Total.Text = "";
            txt_ExistenciaSucursal.Text = "";
            txt_Estatus.Text = "";
            txt_tipoVenta.Text = "";

            Cb_idCliente.SelectedIndex = -1;
            Cb_idSucursal.SelectedIndex = -1;
            Cb_idEmpleado.SelectedIndex = -1;
            Cb_idVenta.SelectedIndex = -1;

            Cb_idVenta.Enabled = false;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Cb_idProducto_SelectedIndexChanged(object sender, EventArgs e)//tiene el nombre de los productos
        {
            con1.Open();
            string q = "select Productos.idProducto,PresentacionesProducto.idProducto,PresentacionesProducto.idEmpaque,Empaques.nombre from Productos JOIN PresentacionesProducto ON PresentacionesProducto.idProducto = Productos.idProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where Productos.nombre = '" + Cb_idProducto.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idproducto.Text = dr[1].ToString();

            }

            con1.Close();

            con1.Open();
            string qz = "select Productos.idProducto,PresentacionesProducto.idProducto,PresentacionesProducto.idEmpaque,Empaques.nombre from Productos JOIN PresentacionesProducto ON PresentacionesProducto.idProducto = Productos.idProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where PresentacionesProducto.idProducto = '" + txt_idproducto.Text + "'";
            SqlCommand cmdz = new SqlCommand(qz, con1);
            SqlDataReader drz = cmdz.ExecuteReader();
            while (drz.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();



                Cb_idPresentacion.Items.Add(drz[3].ToString());
                Cb_idPresentacion.DisplayMember = (drz[3].ToString());
                Cb_idPresentacion.ValueMember = (drz[3].ToString());

            }
            con1.Close();

        }

        private void Cb_idProducto_MouseClick(object sender, MouseEventArgs e)
        {
            Cb_idPresentacion.Items.Clear();
        }

        private void Cb_idPresentacion_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Cb_idPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            con2.Open();
            Cantida = 0;
            string q = "select PresentacionesProducto.idPresentacion,PresentacionesProducto.precioVenta,PresentacionesProducto.idEmpaque,Empaques.nombre from PresentacionesProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque WHERE Empaques.nombre = '" + Cb_idPresentacion.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con2);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_idPresentacionVentadetalle.Text = dr[0].ToString();
                txt_precioVenta.Text = dr[1].ToString();


            }
            if (string.IsNullOrEmpty(txt_cantidad.Text))
            {
                MessageBox.Show("Falta Agregar la Cantidad !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_cantidad.Text = "";

            }
            else
            {


                string ids = this.txt_precioVenta.Text;
                int Precio = Int32.Parse(ids);//textbox de Precio

                string cant = this.txt_cantidad.Text;
                int Cantida = Int32.Parse(cant);//textbox de Precio

               int  subTotal = (Precio * Cantida);//calculo de subtotal

                txt_subtotalventaDetalles.Text = subTotal.ToString();

                string cant5 = this.txt_subtotalventaDetalles.Text;
                subtotal = Int32.Parse(cant5);

            }

            con2.Close();


            //if suc is 1 
            if (txt_idSucursal.Text == "1")
            {
                if (txt_idproducto.Text == "1")
                {
                    if (txt_idPresentacionVentadetalle.Text == "1")//solo hay 1 y 2
                    {
                        con.Open();

                        string qx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 1  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdx = new SqlCommand(qx, con);
                        SqlDataReader drx = cmdx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();


                        }

                        con.Close();
                    }//if idpresentacion es 1

                    if (txt_idPresentacionVentadetalle.Text == "2")//solo hay 1 y 2
                    {
                        con.Open();

                        string qxx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 1  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdxx = new SqlCommand(qxx, con);
                        SqlDataReader drx = cmdxx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();

                        }

                        con.Close();
                    }//if idpresentacion es 2

                }//if producto es 1 suc 1

                if (txt_idproducto.Text == "2")
                {
                    if (txt_idPresentacionVentadetalle.Text == "3")//solo hay 3 y 4
                    {
                        con2.Open();

                        string qx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 1  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdx = new SqlCommand(qx, con2);
                        SqlDataReader drx = cmdx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();

                        }

                        con2.Close();
                    }//if idpresentacion es 1

                    if (txt_idPresentacionVentadetalle.Text == "4")//solo hay 3 y 4
                    {
                        con.Open();

                        string qxx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 1  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdxx = new SqlCommand(qxx, con);
                        SqlDataReader drx = cmdxx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();

                        }

                        con.Close();
                    }//if idpresentacion es 2
                }//if producto es 2 suc 1
            }//cierre del if suc is 1

            //if suc is 2
            if (txt_idSucursal.Text == "2")
            {
                if (txt_idproducto.Text == "1")
                {
                    if (txt_idPresentacionVentadetalle.Text == "1")//solo hay 1 y 2
                    {
                        con.Open();

                        string qx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 2  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdx = new SqlCommand(qx, con);
                        SqlDataReader drx = cmdx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();

                        }

                        con.Close();
                    }//if idpresentacion es 1

                    if (txt_idPresentacionVentadetalle.Text == "2")//solo hay 1 y 2
                    {
                        con.Open();

                        string qxx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 2  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdxx = new SqlCommand(qxx, con);
                        SqlDataReader drx = cmdxx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();

                        }

                        con.Close();
                    }//if idpresentacion es 2

                }//if producto es 1 suc 2

                if (txt_idproducto.Text == "2")
                {
                    if (txt_idPresentacionVentadetalle.Text == "3")//solo hay 3 y 4
                    {
                        con.Open();

                        string qx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 2  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdx = new SqlCommand(qx, con);
                        SqlDataReader drx = cmdx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();

                        }

                        con.Close();
                    }//if idpresentacion es 1

                    if (txt_idPresentacionVentadetalle.Text == "4")//solo hay 3 y 4
                    {
                        con.Open();

                        string qxx = "select existenciaSucursales.idSucursal, existenciaSucursales.idPresentacion,existenciaSucursales.cantidad,existenciaSucursales.idExistenciaSuc from existenciaSucursales where existenciaSucursales.idSucursal = 2  and existenciaSucursales.idPresentacion = '" + txt_idPresentacionVentadetalle.Text + "'";
                        SqlCommand cmdxx = new SqlCommand(qxx, con);
                        SqlDataReader drx = cmdxx.ExecuteReader();
                        while (drx.Read())
                        {
                            //string idCliente = (string)dr["idCliente"].ToString();
                            // txt_idCliente.Text = dr[0].ToString();

                            txt_ExistenciaSucursal.Text = drx[2].ToString();
                            txt_existenciaPresentacion.Text = drx[2].ToString();
                            txt_idExistenciaSucursal.Text = drx[3].ToString();

                        }

                        con.Close();
                    }//if idpresentacion es 2
                }//if producto es 2 suc 2
            }//cierre del if suc is 2



        }

        private void btn_GuardarDetalleventa_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idPresentacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idProducto.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Producto !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (exisSucursal1 < CantVenta)
            {
                MessageBox.Show("No hay suficiente Existencia en la Sucursal !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }                                                                                                                 //si no son iguales se hace la venta normas sin descuento
            else if (Cb_idPresentacion.SelectedIndex > -1 || Cb_idProducto.SelectedIndex > -1 || exisSucursal1 > CantVenta)///validar si la cant no rebas la  cantidadExistencia
            {

                ///SALESVENTAS MODIFICADO LOS SUB,IVA,TOTAL
               // cn.ModificarSalesVentasDT(Cb_idVenta.Text, txt_fechaVenta.Text, txt_cantPagadaVenta.Text, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text, txt_comentarisVenta.Text, txt_estatusVenta.Text, txt_clienteVenta.Text, txt_sucursalVenta.Text, txt_empleadoVenta.Text, txt_tipoVenta.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                string Cant1 = this.txt_cantidad.Text;
                CantVenta = Int32.Parse(Cant1);//textbox de Cantida a venta

                string Exis = this.txt_ExistenciaSucursal.Text;
                exisSucursal1 = Int32.Parse(Exis);//textbox de existencia de sucursal 



                int NuevoExistencia = (exisSucursal1 - CantVenta);

                cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, NuevoExistencia.ToString());//modifia la existencia de la suc

                string Estatus = "A";
                string idVenta = Cb_idVenta.SelectedItem.ToString();
                ///////////////////////////////////////////////////////////////////////////////modifica la existencia de sucExistencia
                if (txt_idpreOferta.Text.Length > 0) {
                    if (idPresentatacionVenta == idPresentatacionOferta && CantVentav >= CantminOferta)//si entra a el de descuentos
                    {
                        cn.InsertarSalesVentasDetalleDT(txt_precioVenta.Text, txt_cantidad.Text, txt_subOferta.Text, idVenta, txt_idPresentacionVentadetalle.Text, Estatus);
                        //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                        //modificar EN salesVentas

                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                        txt_idventaDetalle.Text = " ";
                        // txt_precioVenta.Text = " ";
                        //  txt_cantidad.Text = " ";
                        txt_subtotalventaDetalles.Text = " ";
                        txt_subOferta.Text = "";
                        txt_idPresentacionVentadetalle.Text = " ";
                        txt_idproducto.Text = "";
                        // Cb_idVenta.SelectedIndex = -1;
                        Cb_idProducto.SelectedIndex = -1;
                        Cb_idPresentacion.SelectedIndex = -1;
                        txt_idExistenciaSucursal.Text = "";

                        ///tabla ofertas
                        txt_idpreOferta.Text = "";
                        txt_CantOferta.Text = "";
                        txt_fechaFinOferta.Text = "";
                        txt_descuentosOferta.Text = "";
                        Cb_idProducto.Enabled = true;
                        Cb_idPresentacion.Enabled = true;

                        //texbox
                        txt_cantidad.Text = "";
                        txt_existenciaPresentacion.Text = "";
                        txt_precioVenta.Text = "";
                        txt_subtotalventaDetalles.Text = "";

                        MessageBox.Show("Agregado correctamente Con descuento!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (idPresentatacionVenta == idPresentatacionOferta && CantVentav < CantminOferta)//si es el mismo producto pero no es mayor o a cantminOferta
                    {
                        cn.InsertarSalesVentasDetalleDT(txt_precioVenta.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, idVenta, txt_idPresentacionVentadetalle.Text, Estatus);
                        //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                        //modificar EN salesVentas

                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                        txt_idventaDetalle.Text = " ";
                        // txt_precioVenta.Text = " ";
                        //  txt_cantidad.Text = " ";
                        txt_subtotalventaDetalles.Text = " ";
                        txt_idPresentacionVentadetalle.Text = " ";
                        txt_idproducto.Text = "";
                        // Cb_idVenta.SelectedIndex = -1;
                        Cb_idProducto.SelectedIndex = -1;
                        Cb_idPresentacion.SelectedIndex = -1;
                        txt_idExistenciaSucursal.Text = "";


                        ///tabla ofertas
                        txt_idpreOferta.Text = "";
                        txt_CantOferta.Text = "";
                        txt_fechaFinOferta.Text = "";
                        txt_descuentosOferta.Text = "";

                        MessageBox.Show("Agregado correctamente sin descuento!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (idPresentatacionVenta != idPresentatacionOferta)//si elige otro atriculo que no tiene descuento
                    {
                        cn.InsertarSalesVentasDetalleDT(txt_precioVenta.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, idVenta, txt_idPresentacionVentadetalle.Text, Estatus);
                        //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                        //modificar EN salesVentas

                        ds.Clear();
                        loadData();
                        VarPagFinal = TotalFilasAMostrar;
                        Mostrar_datos();

                        txt_idventaDetalle.Text = " ";
                        // txt_precioVenta.Text = " ";
                        //  txt_cantidad.Text = " ";
                        txt_subtotalventaDetalles.Text = " ";
                        txt_idPresentacionVentadetalle.Text = " ";
                        txt_idproducto.Text = "";
                        // Cb_idVenta.SelectedIndex = -1;
                        Cb_idProducto.SelectedIndex = -1;
                        Cb_idPresentacion.SelectedIndex = -1;
                        txt_idExistenciaSucursal.Text = "";
                        ///tabla ofertas
                        txt_idpreOferta.Text = "";
                        txt_CantOferta.Text = "";
                        txt_fechaFinOferta.Text = "";
                        txt_descuentosOferta.Text = "";


                        MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (string.IsNullOrEmpty(txt_idpreOferta.Text) || string.IsNullOrEmpty(txt_CantOferta.Text))//venta normal donde el cliente no tiene ofertas
                {
                    cn.InsertarSalesVentasDetalleDT(txt_precioVenta.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, idVenta, txt_idPresentacionVentadetalle.Text, Estatus);
                    //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                    //modificar EN salesVentas

                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();

                    txt_idventaDetalle.Text = " ";
                    // txt_precioVenta.Text = " ";
                    //  txt_cantidad.Text = " ";
                    txt_subtotalventaDetalles.Text = " ";
                    txt_idPresentacionVentadetalle.Text = " ";
                    txt_idproducto.Text = "";
                    // Cb_idVenta.SelectedIndex = -1;
                    Cb_idProducto.SelectedIndex = -1;
                    Cb_idPresentacion.SelectedIndex = -1;
                    txt_idExistenciaSucursal.Text = "";

                    ///tabla ofertas
                    txt_idpreOferta.Text = "";
                    txt_CantOferta.Text = "";
                    txt_fechaFinOferta.Text = "";
                    txt_descuentosOferta.Text = "";

                    MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                


                con.Open();
                string q = "SELECT SUM(subtotal) Total FROM SalesVentaDetalle where idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //string idCliente = (string)dr["idCliente"].ToString();
                    // txt_idCliente.Text = dr[0].ToString();
                    txt_subTotalVenta.Text = dr[0].ToString();
                    string Sub = this.txt_subTotalVenta.Text;
                    subTotalFinalVenta = Int32.Parse(Sub);//textbox de Precio

                }


                int subTotal = (subTotalFinalVenta);//calculo de subtotal

                int Iva = (int)(subTotal * 0.16);//calculo de IVA

                int Total = (subTotal + Iva);//calculo de Total

                txt_subTotalVenta.Text = subTotal.ToString();

                txt_ivaVenta.Text = Iva.ToString();
                txt_totalVenta.Text = Total.ToString();



                cn.ModificarSalesVentasDT(Cb_idVenta.Text, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text);//modifica 
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                con.Close();

                con.Open();
                string qx = "select SalesVentas.idVenta,SalesVentas.fecha,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,existenciaSucursales.cantidad,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN existenciaSucursales ON existenciaSucursales.idSucursal = SalesVentas.idSucursal where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmdx = new SqlCommand(qx, con);
                SqlDataReader drx = cmdx.ExecuteReader();
                while (drx.Read())
                {

                    txt_fecha.Text = drx[1].ToString();//--
                    Cb_idCliente.Text = drx[9].ToString();//--
                    txt_clienteVenta.Text = drx[9].ToString();//--
                    txt_CantPagada.Text = drx[2].ToString();//--
                    txt_Subtotal.Text = drx[3].ToString();//--
                    txt_iva.Text = drx[4].ToString();//--
                    txt_Total.Text = drx[5].ToString();//--
                    txt_comentarios.Text = drx[6].ToString();//--
                    Cb_idSucursal.Text = drx[11].ToString();//--
                                                            // txt_ExistenciaSucursal.Text = drx[12].ToString();//--
                    Cb_idEmpleado.Text = drx[14].ToString();//--
                    txt_Estatus.Text = drx[7].ToString();//--
                    txt_tipoVenta.Text = drx[15].ToString();//--


                }

                con.Close();


                con.Open();
                if (Cb_idVenta.SelectedIndex <= -1)
                {
                    ds.Clear();
                    loadData();
                }
                else
                {

                    SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto WHERE SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'", con);//modificado
                    DataSet ds = new DataSet();
                    datos.Fill(ds, "SalesVentaDetalle");
                    this.dataGridView1.DataSource = ds.Tables[0];


                    btnGuardar.Enabled = false;


                }
                con.Close();




            }


        }

        private void btn_GuardarDetalleventa_MouseClick(object sender, MouseEventArgs e)
        {



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_GuardarDetalleventa.Enabled = false;
            btn_EDITARDetalleventa.Enabled = false;
            btn_ELIMINARDetalleventa.Enabled = true;
            btn_NUEVODetalleventa.Enabled = true;
            txt_cantidad.Enabled = false;
            Cb_idProducto.Enabled = false;
            Cb_idPresentacion.Enabled = false;


            txt_idventaDetalle.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_clienteVenta.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txt_cantidad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_cantidadActualTabla.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();//comprobar el edit
            Cb_idProducto.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            Cb_idPresentacion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_precioVenta.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_subtotalventaDetalles.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            con2.Open();


            Cantida = 0;
            string q = "select PresentacionesProducto.idPresentacion,PresentacionesProducto.precioVenta,PresentacionesProducto.idEmpaque,Empaques.nombre from PresentacionesProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque WHERE Empaques.nombre = '" + Cb_idPresentacion.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con2);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_idPresentacionVentadetalle.Text = dr[0].ToString();
                txt_precioVenta.Text = dr[1].ToString();


            }
            if (string.IsNullOrEmpty(txt_cantidad.Text)  && txt_subtotalventaDetalles.Text == "0")
            {
                

                int subTotal = (0 * 0);//calculo de subtotal

                txt_subtotalventaDetalles.Text = subTotal.ToString();
            }
            else if (string.IsNullOrEmpty(txt_precioVenta.Text))
            {
                string cant = this.txt_cantidad.Text;
                Cantida = Int32.Parse(cant);//textbox de Precio

                int subTotal = (0 * Cantida);//calculo de subtotal

                txt_subtotalventaDetalles.Text = subTotal.ToString();
            }
           else if (string.IsNullOrEmpty(txt_cantidad.Text))
            {
                string ids = this.txt_precioVenta.Text;
                Precio = Int32.Parse(ids);//textbox de Precio

                int subTotal = (Precio * 0);//calculo de subtotal

                txt_subtotalventaDetalles.Text = subTotal.ToString();
            }
            else if(txt_cantidad.Text.Length > 0 && txt_precioVenta.Text.Length > 0)
            {
                string ids = this.txt_precioVenta.Text;
                Precio = Int32.Parse(ids);//textbox de Precio

                string cant = this.txt_cantidad.Text;
                int Cantida = Int32.Parse(cant);//textbox de Precio

                int subTotal = (Precio * Cantida);//calculo de subtotal

                txt_subtotalventaDetalles.Text = subTotal.ToString();


            }

            con2.Close();
        }

        private void Cb_idVenta_MouseClick(object sender, MouseEventArgs e)
        {
            Cb_idVenta.Items.Clear();
            Cargar_Datos_idVentas();
        }

        private void btn_ELIMINARDetalleventa_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idPresentacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idProducto.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Producto !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idPresentacion.SelectedIndex > -1 || Cb_idProducto.SelectedIndex > -1)///validar si la cant no rebas la  cantidadExistencia
            {
                string subveta = this.txt_subtotalventaDetalles.Text;
                int SubtotalVentaDetalle = Int32.Parse(subveta);//textbox de Cant

                string CantV = this.txt_cantidad.Text;
                int CantTextBox = Int32.Parse(CantV);//textbox de Cant

                string tabla = this.txt_cantidadActualTabla.Text;
                int cantventaDetalle = Int32.Parse(tabla);//textbox de cant de la tabla salesVentasDetalle


                string exci = this.txt_existenciaPresentacion.Text;
                int existenciaSucursal = Int32.Parse(exci);//textbox de cant de la tabla salesVentas


                con.Open();
                string q = "SELECT SUM(subtotal) Total FROM SalesVentaDetalle where idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //string idCliente = (string)dr["idCliente"].ToString();
                    // txt_idCliente.Text = dr[0].ToString();
                    txt_subTotalVenta.Text = dr[0].ToString();
                    string Sub = this.txt_subTotalVenta.Text;
                    subTotalFinalVenta = Int32.Parse(Sub);//textbox de Precio

                }


                int subTotal = (subTotalFinalVenta - SubtotalVentaDetalle);// resta la subtotal de la venta que se vendio y esta registrada en SalesVentaDetalle

                int Iva = (int)(subTotal * 0.16);//calculo de IVA

                int Total = (subTotal + Iva);//calculo de Total

                txt_subTotalVenta.Text = subTotal.ToString();


                txt_ivaVenta.Text = Iva.ToString();
                txt_totalVenta.Text = Total.ToString();

                
                    //int resta = (cantventaDetalle - CantTextBox);

                    int suma = (existenciaSucursal + CantTextBox);//suma los que se regresaron 
                    txt_existenciaPresentacion.Text = suma.ToString();

                    //cn.modificarSalesVentaDetalleEditBotonDT(txt_idventaDetalle.Text, txt_cantidad.Text, txt_subtotalventaDetalles.Text, txt_idPresentacionVentadetalle.Text);
                    cn.ModificarexistenciaSucursalDT(txt_idExistenciaSucursal.Text, txt_existenciaPresentacion.Text);//modifia la existencia de la suc

                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();
                

                //modifica la salesVenta
                cn.ModificarSalesVentasDT(Cb_idVenta.Text, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text);//modifica 

                //eliminar idventadetalle de la BD
                cn.EliminacionIdVentadetalleDT(txt_idventaDetalle.Text);

                con.Close();

                con.Open();
                string qx = "select SalesVentas.idVenta,SalesVentas.fecha,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,existenciaSucursales.cantidad,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN existenciaSucursales ON existenciaSucursales.idSucursal = SalesVentas.idSucursal where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmdx = new SqlCommand(qx, con);
                SqlDataReader drx = cmdx.ExecuteReader();
                while (drx.Read())
                {

                    txt_fecha.Text = drx[1].ToString();//--
                    Cb_idCliente.Text = drx[9].ToString();//--
                    txt_clienteVenta.Text = drx[9].ToString();//--
                    txt_CantPagada.Text = drx[2].ToString();//--
                    txt_Subtotal.Text = drx[3].ToString();//--
                    txt_iva.Text = drx[4].ToString();//--
                    txt_Total.Text = drx[5].ToString();//--
                    txt_comentarios.Text = drx[6].ToString();//--
                    Cb_idSucursal.Text = drx[11].ToString();//--
                                                            // txt_ExistenciaSucursal.Text = drx[12].ToString();//--
                    Cb_idEmpleado.Text = drx[14].ToString();//--
                    txt_Estatus.Text = drx[7].ToString();//--
                    txt_tipoVenta.Text = drx[15].ToString();//--




                }

                con.Close();


                con.Open();
                if (Cb_idVenta.SelectedIndex <= -1)
                {
                    ds.Clear();
                    loadData();
                }
                else
                {

                    SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto WHERE SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'", con);//modificado
                    DataSet ds = new DataSet();
                    datos.Fill(ds, "SalesVentaDetalle");
                    this.dataGridView1.DataSource = ds.Tables[0];


                    btn_GuardarDetalleventa.Enabled = true;
                    MessageBox.Show("Venta Eliminada!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                con.Close();


                txt_idventaDetalle.Text = " ";

               // txt_precioVenta.Text = " ";
               // txt_cantidad.Text = " ";
                Cb_idVenta.Text = "";
                txt_idproducto.Text = "";
                Cb_idVenta.SelectedIndex = -1;



                txt_subtotalventaDetalles.Text = " ";
                txt_idPresentacionVentadetalle.Text = " ";
                txt_idproducto.Text = "";
                Cb_idVenta.SelectedIndex = -1;
                Cb_idProducto.SelectedIndex = -1;
                Cb_idPresentacion.SelectedIndex = -1;
                txt_idExistenciaSucursal.Text = "";

                btn_EDITARDetalleventa.Enabled = false;
                btn_ELIMINARDetalleventa.Enabled = false;
                btn_GuardarDetalleventa.Enabled = true;
                txt_cantidad.Enabled = true;
                Cb_idProducto.Enabled = true;
                Cb_idPresentacion.Enabled = true;

            }
        }

        private void btn_NUEVODetalleventa_Click(object sender, EventArgs e)
        {
            txt_idventaDetalle.Text = " ";
            // txt_precioVenta.Text = " ";
            //  txt_cantidad.Text = " ";
            txt_subtotalventaDetalles.Text = " ";
            txt_idPresentacionVentadetalle.Text = " ";
            txt_idproducto.Text = "";
            // Cb_idVenta.SelectedIndex = -1;
            Cb_idProducto.SelectedIndex = -1;
            Cb_idPresentacion.SelectedIndex = -1;
            txt_idExistenciaSucursal.Text = "";
            btn_EDITARDetalleventa.Enabled = false;
            btn_ELIMINARDetalleventa.Enabled = false;


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_comentarios.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_tipoVenta.Text == "CREDITO")
            {
                MessageBox.Show("Credito ya fue Aprovado!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (totalCompraCliente < LimiteCredito)
            {
                string venta = this.txt_Total.Text;
                totalCompraCliente = Int32.Parse(venta);//textbox de Precio

                //string tipo = Cb_tipo.SelectedItem.ToString();
                String TipoCredito = "CREDITO";

                cn.ModificarSalesVentasCreditoDT(Cb_idVenta.Text, TipoCredito);

                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                //CIERRA LA VENTA UNA GUARADAD

                MessageBox.Show("Credito Aprobado!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(totalCompraCliente > LimiteCredito)
            {

                MessageBox.Show("Error sobre pasa el limite de Credito el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con2.Open();
            string qxe = "select SalesVentas.idVenta,SalesVentas.fecha,cantPagada, SalesVentas.subtotal, SalesVentas.iva, SalesVentas.total,SalesVentas.comentarios,SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,existenciaSucursales.cantidad,SalesVentas.idEmpleado,Empleados.nombre,SalesVentas.tipo from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empleados ON Empleados.idEmpleado = SalesVentas.idEmpleado JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal JOIN existenciaSucursales ON existenciaSucursales.idSucursal = SalesVentas.idSucursal where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmdxe = new SqlCommand(qxe, con2);
            SqlDataReader drxe = cmdxe.ExecuteReader();
            while (drxe.Read())
            {

                txt_fecha.Text = drxe[1].ToString();//--
                Cb_idCliente.Text = drxe[9].ToString();//--
                txt_clienteVenta.Text = drxe[9].ToString();//--
                txt_CantPagada.Text = drxe[2].ToString();//--
                txt_Subtotal.Text = drxe[3].ToString();//--
                txt_iva.Text = drxe[4].ToString();//--
                txt_Total.Text = drxe[5].ToString();//--
                txt_comentarios.Text = drxe[6].ToString();//--
                Cb_idSucursal.Text = drxe[11].ToString();//--
             // txt_ExistenciaSucursal.Text = drx[12].ToString();//--
                Cb_idEmpleado.Text = drxe[14].ToString();//--
                txt_Estatus.Text = drxe[7].ToString();//--
                txt_tipoVenta.Text = drxe[15].ToString();//--

                

                
                   

                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = true;

                    //
                    btn_GuardarDetalleventa.Enabled = false;
                    btn_EDITARDetalleventa.Enabled = false;
                    btn_ELIMINARDetalleventa.Enabled = false;
                    btn_NUEVODetalleventa.Enabled = false;

            }


            con2.Close();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cn.EliminacionIdVentaDT(Cb_idVenta.Text);
            MessageBox.Show("Venta Eliminada!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // dataGridView1.Rows.Clear();
            Cb_idVenta.Text = "";


        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel vz = new Excel();
            vz.Show();
        }

        private void SalesDetalleVentayVenta_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Cb_idVenta.Enabled = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_cantidad.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            txt_CantOferta.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            Cb_idProducto.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txt_idpreOferta.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            Cb_idPresentacion.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            txt_fechaFinOferta.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            txt_descuentosOferta.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();

            btn_Oferta.Enabled = true;

            Cb_idProducto.Enabled = false;
            Cb_idPresentacion.Enabled = false;
        }

        private void btn_Oferta_Click(object sender, EventArgs e)
        {
            string cant = this.txt_descuentosOferta.Text;
            int descuentosPorcentaje = Int32.Parse(cant);

            string cant5 = this.txt_subtotalventaDetalles.Text;
            SubTotalParaDesc = Int32.Parse(cant5);

            string cant1 = this.txt_idPresentacionVentadetalle.Text;
             idPresentatacionVenta = Int32.Parse(cant1);                     

            string cant2 = this.txt_idpreOferta.Text;
            idPresentatacionOferta = Int32.Parse(cant2);

            string cant3 = this.txt_CantOferta.Text;
            CantminOferta = Int32.Parse(cant3);     

            string cant4 = this.txt_cantidad.Text;
            CantVentav = Int32.Parse(cant4);

            if (idPresentatacionVenta == idPresentatacionOferta && CantVentav >= CantminOferta)
            {
               
                int descFinal = SubTotalParaDesc - (SubTotalParaDesc * descuentosPorcentaje / 100);


                txt_subOferta.Text = descFinal.ToString();

            }
            else if (idPresentatacionVenta == idPresentatacionOferta && CantVentav < CantminOferta)
            {
                btn_Oferta.Enabled = false;
            }

            btn_Oferta.Enabled = false;

        }
    }
}
