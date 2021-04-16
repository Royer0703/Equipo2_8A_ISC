﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //METODO PARA LA CONEXION CON LA BD 
    public class ConexionSQL
    {

         static string conexionstring = "server = ROGELIO\\MSSQLSERVERDEV; database = ERP;" +
              "integrated security = true";

         SqlConnection con = new SqlConnection(conexionstring);


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
        //METODO PARA ELIMINAR NUEVO Cliente
        public int EliminarCliente(string idClien)
        {
            int flag = 0;
            con.Open();

            string query = "Delete from SalesClientes where idCliente = '" + idClien + "'";
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
        public int InsertarParcelas(string idParcela, string extension, string idCliente, string idCultivo, string idDireccion, string estatus)
        {
            int flag = 0;
            con.Open();

            string query = "insert into SalesParcelas values('" + idParcela + "','" + extension + "','" + idCliente + "','" + idCultivo + "','" + idDireccion + "','" + estatus + "' )";
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
        public int insertarDireccionCliente(string idDireccion, string calle, string numero, string colonia, string codigoPostal, string tipo, string idCliente, string idCiudad, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesDireccionesCliente values('" + idDireccion + "', '" + calle + "', '" + numero + "', '" + colonia + "', '" + codigoPostal + "', '" + tipo + "', '" + idCliente + "', '" + idCiudad + "', '" + estatus + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        //METODO PARA MODIFICAR LAS DIRECCIONES CLIENTE EN LA BD
        public int modificarDireccionCliente(string idDireccion, string calle, string numero, string colonia, string codigoPostal, string tipo, string idCliente, string idCiudad, string estatus)
        {
            int flag = 0;
            con.Open();
            string query = "Update SalesDireccionesCliente set idDireccion ='" + idDireccion + "', calle='" + calle + "', numero='" + numero + "', colonia='" + colonia + "', codigoPostal='" + codigoPostal + "', tipo='" + tipo + "', idCliente='" + idCliente + "', idCiudad='" + idCiudad + "', estatus='" + estatus + "' where idDireccion ='" + idDireccion + "'";
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
        public int InsertarMantenimientoDG(string idMantenimiento, string fechaInicio, string fechaFin, string taller, string costo, string comentarios, string tipo, string idUnidadTransporte, string estatus)
        {
            int flag = 0;
            con.Open();

            string query = "insert into SalesMantenimiento values('" + idMantenimiento + "','" + fechaInicio + "','" + fechaFin + "','" + taller + "','" + costo + "','" + comentarios + "','" + tipo + "','" + idUnidadTransporte + "','" + estatus + "' )";
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





    }
}
