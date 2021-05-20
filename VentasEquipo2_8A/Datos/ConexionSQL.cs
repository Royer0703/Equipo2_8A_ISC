using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;//new
using Entidad;//new 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{

    //METODO PARA LA CONEXION CON LA BD 
    public class ConexionSQL
    {

         static string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERPVENTA;" +
              "integrated security = true";

         SqlConnection con = new SqlConnection(conexionstring);

        //METODO PARA VALIDAR EL LOGIN CON LA BD 
        public int consultalogin(string Usuario, string Contrasena)
        {
            int count;
            con.Open();
            string Query = "Select Count(*) From Usuarios where usuario = '" + Usuario + "'" +
                "and contrasena = '" + Contrasena + "'";

            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            return count;
        }



        //***************************** TABLA SALESUNIDADESTRANSPORTE ********************************
        //METDOD CONSULTAR
        public DataTable ConsultarUnidadesTransporte()
        {
            string query = "Select * from SalesUnidadesTransporte";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        //METODO PARA INSERTAR LAS UNIDADES DE TRANSPORTE EN LA BD
        public int insertarUnidad(int idUnidadTransporte, string placas, string marca, string modelo, int anio, int capacidad, string tipo, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesUnidadesTransporte values('" + idUnidadTransporte + "', '" + placas + "', '" + marca + "', '" + modelo + "', '" + anio + "', '" + capacidad + "', '" + tipo + "', '" + estatus + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS UNIDADES DE TRANSPORTE EN LA BD
        public int modificarUnidadTransporte(int idUnidadTransporte, string placas, string marca, string modelo, int anio, int capacidad, string tipo, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesUnidadesTransporte set idUnidadTransporte ='" + idUnidadTransporte + "', placas ='" + placas + "', marca ='" + marca + "', modelo ='" + modelo + "', anio  ='" + anio + "', capacidad   ='" + capacidad + "', tipo   ='" + tipo + "', estatus   ='" + estatus + "'where idUnidadTransporte ='" + idUnidadTransporte + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA ELIMINAR Unidad de Transporte EN LA BD
        public int eliminarUnidadTransporte(int curp)
        {
            int flag = 0;
            con.Open();

            string query = "Delete from SalesUnidadesTransporte where idUnidadTransporte  = '" + curp + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }



        //***********************************TABLA CULTIVOS **************************************************
        //METODO PARA AGREGAR NUEVO CULTIVO
        public int InsertarCultivos(string idCulti, string nom, string costoAse, string esta)
        {
            int flag = 0;
            con.Open();

            string query = "insert into SalesCultivos values('" + idCulti + "','" + nom + "','" + costoAse + "','" + esta + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICA NUEVO CULTIVO
        public int ModificarCultivos(string idCul, string nom, string costoAse, string esta)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesCultivos set nombre='" + nom + "', costoAsesoria='" + costoAse + "', estatus='" + esta + "'where idCultivo='" + idCul + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;


        }
        //METODO PARA ELIMINAR NUEVO CULTIVO
        public int EliminarCultivos(string idCul)
        {
            int flag = 0;
            con.Open();

            string query = "Delete from SalesCultivos where idCultivo = '" + idCul + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        //CONSULTAR LOS DATOS DE TABLA SQL CULTIVOS
        public DataTable ConsultarCultivosDG()
        {
            string query = "select * from SalesCultivos";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }




        //***********************************TABLA CLIENTES **************************************************
        //METODO PARA AGREGAR NUEVO Cliente
        public int InsertarCliente(string idClien, string nom, string rz, string lm, string rfc, string tel, string email, string tipo)
        {
            int flag = 0;
            con.Open();

            string query = "insert into SalesClientes values('" + idClien + "','" + nom + "','" + rz + "','" + lm + "','" + rfc + "','" + tel + "','" + email + "','" + tipo + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICA NUEVO Cliente
        public int ModificarCliente(string idClien, string nom, string rz, string lm, string rfc, string tel, string email, string tipo)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesClientes set nombre='" + nom + "', razonSocial ='" + rz + "', limiteCredito ='" + lm + "', rfc  ='" + rfc + "', telefono  ='" + tel + "', email   ='" + email + "', tipo   ='" + tipo + "'where idCliente ='" + idClien + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;


        }
       
       

        //CONSULTAR LOS DATOS DE TABLA SQL Cliente
        public DataTable ConsultarCliente()
        {
            string query = "select * from SalesClientes";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }



        //***************************** TABLA MIEMBROS ********************************
        //METDOD CONSULTAR
        public DataTable ConsultarMiembros()
        {
            string query = "Select * from SalesMiembros";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        //METODO PARA INSERTAR MIEMBROS EN LA BD
        public int insertarMiembros(string idCliente, string idAsociacion, string estatus, string Incorporacion)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesMiembros values('" + idCliente + "','" + idAsociacion + "', '" + estatus + "', '" + Incorporacion + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LOS MIEMBROS EN LA BD
        public int modificarMiembros(string idCliente, string idAsociacion, string estatus, string Incorporacion)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesMiembros set idAsociacion ='" + idAsociacion + "', estatus ='" + estatus + "', Incorporacion ='" + Incorporacion + "', modelo ='";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA ELIMINAR MIEMBRO EN LA BD
        public int eliminarMiembros(int asociacion)
        {
            int flag = 0;
            con.Open();

            string query = "Delete from SalesMiembros where idAsociacion  = '" + asociacion + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }


        //***********************************TABLA Asociacion... **************************************************
        //METODO PARA AGREGAR NUEVO  Asociacion
        public int InsertarAsociacion(string idAsociacion, string nombre, string Estatus)
        {
            int flag = 0;
            con.Open();

            string query = "insert into SalesAsociaciones values('" + idAsociacion + "','" + nombre + "','" + Estatus + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICA NUEVO  
        public int ModificarAsociacion(string idAsociacion, string nombre, string Estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesAsociaciones set idAsosiacion='" + idAsociacion + "', nombre='" + nombre + "',   estatus='" + Estatus + "'where idAsosiacion ='" + idAsociacion + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;


        }
        //METODO PARA ELIMINAR NUEVO  
        public int EliminarAsociacion(string idAsociacion)
        {
            int flag = 0;
            con.Open();

            string query = "Delete from SalesAsociaciones where  idAsosiacion = '" + idAsociacion + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        //CONSULTAR LOS DATOS DE TABLA SQL  
        public DataTable ConsultarAsociacion()
        {
            string query = "select * from SalesAsociaciones";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }





        //***********************************TABLA PARCELAS **************************************************
        //METODO PARA AGREGAR NUEVO PARCELAS
        public int InsertarParcelas(string extension, string idCliente, string idCultivo, string idDireccion, string estatus)
        {
            int flag = 0;
            con.Open();

            string query = "insert into SalesParcelas values('" + extension + "','" + idCliente + "','" + idCultivo + "','" + idDireccion + "','" + estatus + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICA NUEVO PARCELAS
        public int ModificarParcelas(string idParcela, string extension, string idCliente, string idCultivo, string idDireccion, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesParcelas set extension='" + extension + "', idCliente='" + idCliente + "', idCultivo='" + idCultivo + "', idDireccion='" + idDireccion + "', estatus='" + estatus + "'where idParcela='" + idParcela + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;


        }


        //CONSULTAR LOS DATOS DE TABLA SQL PARCELAS
        public DataTable ConsultarParcelasDG()
        {
            string query = "select * from SalesParcelas";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


        //***************************** TABLA SALESDIRECCIONESCLIENTE ********************************
        //METDOD CONSULTAR
        public DataTable ConsultarDireccionCliente()
        {
            string query = "Select * from SalesDireccionesCliente";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        //METODO PARA INSERTAR LAS DIRECCIONES CLIENTE EN LA BD
        public int insertarDireccionCliente(string calle, string numero, string colonia, string codigoPostal, string tipo, string idCliente, string idCiudad)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesDireccionesCliente values('" + calle + "', '" + numero + "', '" + colonia + "', '" + codigoPostal + "', '" + tipo + "', '" + idCliente + "', '" + idCiudad + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS DIRECCIONES CLIENTE EN LA BD
        public int modificarDireccionCliente(string idDireccion, string calle, string numero, string colonia, string codigoPostal, string tipo, string idCliente, string idCiudad)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesDireccionesCliente set idDireccion ='" + idDireccion + "', calle='" + calle + "', numero='" + numero + "', colonia='" + colonia + "', codigoPostal='" + codigoPostal + "', tipo='" + tipo + "', idCliente='" + idCliente + "', idCiudad='" + idCiudad + "' where idDireccion ='" + idDireccion + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA ELIMINAR LAS DIRECCIONES CLIENTE EN LA BD
        public int eliminarDireccionCliente(string curp)
        {
            int flag = 0;
            con.Open();

            string query = "Delete from SalesDireccionesCliente where idDireccion  = '" + curp + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }


        //***************************** TABLA MIEMBROS ********************************
        //METDOD CONSULTAR
        public DataTable ConsultarMiembrosDG()
        {
            string query = "Select * from SalesMiembros";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        //METODO PARA INSERTAR MIEMBROS EN LA BD
        public int insertarMiembrosDG(string idCliente, string idAsociacion, string estatus, string Incorporacion)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesMiembros values('" + idCliente + "','" + idAsociacion + "', '" + estatus + "', '" + Incorporacion + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LOS MIEMBROS EN LA BD
        public int modificarMiembrosDG(string idCliente, string idAsosiacion, string estatus, string fechaIncorporacion)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesMiembros set idAsosiacion='" + idAsosiacion + "', estatus='" + estatus + "', fechaIncorporacion='" + fechaIncorporacion + "'where idCliente='" + idCliente + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }



        //***********************************TABLA MANTENIMIENTO **************************************************
        //METODO PARA AGREGAR NUEVO MANTENIMIENTO
        public int InsertarMantenimientoDG( string fechaInicio, string fechaFin, string taller, string costo, string comentarios, string tipo, string idUnidadTransporte, string estatus)
        {
            int flag = 0;
            con.Open();

            string query = "insert into SalesMantenimiento values('" + fechaInicio + "','" + fechaFin + "','" + taller + "','" + costo + "','" + comentarios + "','" + tipo + "','" + idUnidadTransporte + "','" + estatus + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICA NUEVO MANTENIMIENTO
        public int ModificarMantenimientoDG(string idMantenimiento, string fechaInicio, string fechaFin, string taller, string costo, string comentarios, string tipo, string idUnidadTransporte, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesMantenimiento set fechaInicio='" + fechaInicio + "', fechaFin ='" + fechaFin + "', taller ='" + taller + "', costo  ='" + costo + "', comentarios  ='" + comentarios + "', tipo   ='" + tipo + "', idUnidadTransporte   ='" + idUnidadTransporte + "', estatus   ='" + estatus + "'where idMantenimiento ='" + idMantenimiento + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;


        }


        //CONSULTAR LOS DATOS DE TABLA SQL MANTENIMIENTO
        public DataTable ConsultarMantenimientoDG()
        {
            string query = "select * from SalesMantenimiento";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }



        //***********************************TABLA CONTACTOCLIENTE **************************************************
        //METODO PARA AGREGAR NUEVO CONTACTO CLIENTE
        public int InsertarContactoClienteDG(string nombre, string telefono, string email, string idCliente, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesContactosCliente values('" + nombre + "','" + telefono + "','" + email + "','" + idCliente + "','" + estatus + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICA CONTACTO CLIENTE
        public int ModificarContactoClienteDG(string idContacto, string nombre, string telefono, string email, string idCliente, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesContactosCliente set nombre='" + nombre + "', telefono='" + telefono + "', email='" + email + "', idCliente='" + idCliente + "', estatus='" + estatus + "'where idContacto='" + idContacto + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;


        }

        public DataTable ConsultarContactoClienteDG()
        {
            string query = "select * from SalesContactosCliente";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }



        //***********************************TABLA SalesAsesorias **************************************************
        //METODO PARA AGREGAR NUEVO CONTACTO CLIENTE
        public int insertarSalesAsesoriasDG(string fecha, string comentarios, string estatus, string costo, string idParcela, string idEmpleado, string idUnidadTransporte)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesAsesorias values('" + fecha + "', '" + comentarios + "', '" + estatus + "', '" + costo + "', '" + idParcela + "', '" + idEmpleado + "', '" + idUnidadTransporte + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS UNIDADES DE TRANSPORTE EN LA BD
        public int modificarSalesAsesoriasDG(string idAsesoria, string fecha, string comentarios, string estatus, string costo, string idParcela, string idEmpleado, string idUnidadTransporte)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesAsesorias set fecha ='" + fecha + "', comentarios ='" + comentarios + "', estatus ='" + estatus + "', costo ='" + costo + "', idParcela  ='" + idParcela + "', idEmpleado   ='" + idEmpleado + "', idUnidadTransporte   ='" + idUnidadTransporte + "'where idAsesoria ='" + idAsesoria + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public DataTable ConsultarSalesAsesoriasDG()
        {
            string query = "select * from SalesAsesorias";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


        //***********************************TABLA SalesVentas **************************************************
        //METODO PARA AGREGAR NUEVO CONTACTO CLIENTE
        public int insertarSalesVentasDG(string fecha, string cantPagada, string idProducto, string subtotal, string iva, string total, string comentarios, string estatus, string idCliente, string idSucursal, string idEmpleado, string tipo)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesVentas values('" + fecha + "', '" + cantPagada + "', '" + idProducto + "', '" + subtotal + "', '" + iva + "', '" + total + "', '" + comentarios + "', '" + estatus + "', '" + idCliente + "', '" + idSucursal + "', '" + idEmpleado + "', '" + tipo + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS UNIDADES DE TRANSPORTE EN LA BD
        public int modificarSalesVentasDG(string idVenta, string fecha, string cantPagada, string idProducto, string subtotal, string iva, string total, string comentarios, string estatus, string idCliente, string idSucursal, string idEmpleado, string tipo)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesVentas set fecha ='" + fecha + "', cantPagada ='" + cantPagada + "', idProducto ='" + idProducto + "', subtotal ='" + subtotal + "', iva  ='" + iva + "', total   ='" + total + "', comentarios   ='" + comentarios + "', estatus   ='" + estatus + "', idCliente   ='" + idCliente + "', idSucursal   ='" + idSucursal + "', idEmpleado   ='" + idEmpleado + "', tipo   ='" + tipo + "'where idVenta ='" + idVenta + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public DataTable ConsultarSalesVentasDG()
        {
            string query = "select * from SalesVentas";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


        //***********************************TABLA SalesVentasDEtalles **************************************************
        //METODO PARA AGREGAR NUEVO SalesVentaDetalle
        public int insertarSalesVentaDetalleDG(string precioVenta, string cantidad, string subtotal, string idVenta, string idPresentacion, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesVentaDetalle values('" + precioVenta + "', '" + cantidad + "', '" + subtotal + "', '" + idVenta + "', '" + idPresentacion + "', '" + estatus + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS SalesVentaDetalle EN LA BD
        public int modificarSalesVentaDetalleDG(string idVentaDetalle, string precioVenta, string cantidad, string subtotal, string idVenta, string idPresentacion, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesVentaDetalle set precioVenta ='" + precioVenta + "', cantidad   ='" + cantidad + "', subtotal   ='" + subtotal + "', idVenta   ='" + idVenta + "', idPresentacion   ='" + idPresentacion + "', estatus   ='" + estatus + "'where idVentaDetalle ='" + idVentaDetalle + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public DataTable ConsultarSalesVentaDetalleDG()
        {
            string query = "select * from SalesVentaDetalle";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }





        //***********************************TABLA Salescobros **************************************************
        //METODO PARA AGREGAR NUEVO Salescobros
        public int insertarSalesCobrosDG(string fecha, string importe, string idVenta, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesCobros values('" + fecha + "', '" + importe + "', '" + idVenta + "', '" + estatus + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS Salescobros EN LA BD
        public int modificarSalesCobrosDG(string idCobro, string fecha, string importe, string idVenta, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesCobros set fecha ='" + fecha + "', importe   ='" + importe + "', idVenta   ='" + idVenta + "', estatus   ='" + estatus + "'where idCobro ='" + idCobro + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //***********************************TABLA SalesDetallesEnvio **************************************************
        //METODO PARA AGREGAR NUEVO SalesDetallesEnvio
        public int insertarSalesDetallesEnvioDG(string idVenta, string idDireccion, string fechaEntregaPlaneada, string peso, string estatus, string idContacto)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesDetallesEnvio values('" + idVenta + "', '" + idDireccion + "', '" + fechaEntregaPlaneada + "', '" + peso + "', '" + estatus + "', '" + idContacto + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS SalesDetallesEnvio EN LA BD
        public int modificarSalesDetallesEnvioDG(string idEnvio, string idVenta, string idDireccion, string fechaEntregaPlaneada, string peso, string estatus, string idContacto)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesDetallesEnvio set idVenta ='" + idVenta + "', idDireccion ='" + idDireccion + "', fechaEntregaPlaneada ='" + fechaEntregaPlaneada + "', peso ='" + peso + "', estatus  ='" + estatus + "', idContacto   ='" + idContacto + "'where idEnvio ='" + idEnvio + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS SalesEnvios EN LA BD
        public int insertarSalesEnviosDG(string fechaInicio, string fechaFin, string idUnidadTransporte, string pesoTotal, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesEnvios values('" + fechaInicio + "', '" + fechaFin + "', '" + idUnidadTransporte + "', '" + pesoTotal + "', '" + estatus + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS SalesEnvios EN LA BD
        public int modificarSalesEnviosDG(string idEnvio, string fechaInicio, string fechaFin, string idUnidadTransporte, string pesoTotal, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesEnvios set fechaInicio ='" + fechaInicio + "', fechaFin ='" + fechaFin + "', idUnidadTransporte ='" + idUnidadTransporte + "', pesoTotal  ='" + pesoTotal + "', estatus   ='" + estatus + "'where idEnvio ='" + idEnvio + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }



        //METODO SELECT DE CIUDADES
        public DataTable ConsultarCiudadesDG()
        {
            string query = "select * from Ciudades";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        //METODO SELECT DE EMPLEADOSS
        public DataTable ConsultarEmpleadosDG()
        {
            string query = "select * from empleadoss";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }




        //////////////////TABLAS JOIN CLIENTES Y DIRECCIONES_CLIENTE////////////////////////////////////////

        public DataTable ConsultarClienteYDireClienteDG()
        {
            string query = "select  SalesClientes.idCliente, SalesDireccionesCliente.idDireccion, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia from SalesDireccionesCliente INNER JOIN SalesClientes ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


        //////////////////TABLAS JOIN  de parcelas ////////////////////////////////////////

        public DataTable ConsultarJoinParcelasDG()
        {
            string query = "select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente  JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesParcelas.idDireccion JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


        //////////////////TABLAS JOIN  de MANTENIMIENTO ////////////////////////////////////////

        public DataTable ConsultarJoinMantenimientoDG()
        {
            string query = "select SalesMantenimiento.idMantenimiento, SalesMantenimiento.fechaInicio, SalesMantenimiento.fechaFin,SalesMantenimiento.taller, SalesMantenimiento.costo,SalesMantenimiento.comentarios, SalesMantenimiento.tipo, SalesMantenimiento.idUnidadTransporte, SalesMantenimiento.estatus, SalesUnidadesTransporte.placas, SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesMantenimiento JOIN SalesUnidadesTransporte ON SalesMantenimiento.idUnidadTransporte = SalesUnidadesTransporte.idUnidadTransporte ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        //////////////////TABLAS JOIN  de ContactoCliente ////////////////////////////////////////

        public DataTable ConsultarJoinContactoClienteDG()
        {
            string query = "select SalesContactosCliente.idContacto, SalesClientes.nombre, SalesContactosCliente.telefono, SalesContactosCliente.email, SalesContactosCliente.idCliente, SalesContactosCliente.estatus from SalesContactosCliente JOIN SalesClientes ON SalesContactosCliente.idCliente = SalesClientes.idCliente ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        //////////////////TABLAS JOIN  de ASESORIAS ////////////////////////////////////////

        public DataTable ConsultarJoinAsesoriasDG()
        {
            string query = "select SalesAsesorias.idAsesoria, SalesAsesorias.fecha, SalesAsesorias.comentarios, SalesAsesorias.estatus,SalesAsesorias.costo,SalesAsesorias.idParcela,SalesAsesorias.idEmpleado, SalesAsesorias.idUnidadTransporte, SalesParcelas.extension, SalesCultivos.nombre, Empleados.nombre, SalesUnidadesTransporte.placas , SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesAsesorias JOIN SalesParcelas ON SalesParcelas.idParcela = SalesAsesorias.idParcela JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo JOIN Empleados ON Empleados.idEmpleado = SalesAsesorias.idEmpleado JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesAsesorias.idUnidadTransporte";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }








        /////////////PAGINACION DE PARCELAS /////////////////////////////////////////////////

        public DataSet Lista_Parcelas(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesParcelas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


        ////////////////PAGINACION DE CULTIVOS////////////////////
        ///
        public DataSet Lista_Cultivos(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesCultivos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }



        ////////////////PAGINACION DE Miembros////////////////////
        ///
        public DataSet Lista_Miembros(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesMiembros", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


        ////////////////PAGINACION DE Miembros////////////////////
        ///
        public DataSet Lista_Mantenimiento(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesMantenimiento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


        ////////////////PAGINACION DE SalesAsociaciones ////////////////////
        ///
        public DataSet Lista_Asociaciones(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesAsociaciones", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


        ////////////////PAGINACION DE SalesContactosCliente ////////////////////
        ///
        public DataSet Lista_ContactosCliente(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesContactosCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        ////////////////PAGINACION DE SalesUnidadesTransporte ////////////////////
        public DataSet Lista_SalesUnidadesTransporte(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesUnidadesTransporte", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        ////////////////PAGINACION DE SalesDireccionesCliente ////////////////////
        public DataSet Lista_SalesDireccionesCliente(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesDireccionesCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        ////////////////PAGINACION DE Clientes ////////////////////
        public DataSet Lista_Cliente(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesClientes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        ////////////////PAGINACION DE SalesAsesorias ////////////////////
        public DataSet Lista_SalesAsesorias(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesAsesorias", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


        ////////////////PAGINACION DE SalesVentas ////////////////////
        public DataSet Lista_SalesVentas(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesVentas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


        
        ////////////////PAGINACION DE SalesVentaDetalle ////////////////////
        public DataSet Lista_SalesVentaDetalle(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesVentaDetalle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        ////////////////PAGINACION DE SalesCobros ////////////////////
        public DataSet Lista_SalesCobros(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesCobros", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

      
        ////////////////PAGINACION DE SalesDetallesEnvio ////////////////////
        public DataSet Lista_SalesDetallesEnvio(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesDetallesEnvio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


        ////////////////PAGINACION DE SalesEnvios ////////////////////
        public DataSet Lista_SalesEnvios(Class_Entidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_SalesEnvios", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tab_inicio", obje.varDatoInicio);
            cmd.Parameters.AddWithValue("@tab_final", obje.varDatoFinal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }


    }
}
