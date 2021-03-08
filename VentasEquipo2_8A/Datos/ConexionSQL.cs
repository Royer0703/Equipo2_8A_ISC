using System;
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
        public int insertarUnidad(int idUnidadTransporte, string placas, string marca, string modelo, int anio, int capacidad, string tipo)
        {
            int flag = 0;
            con.Open();
            string query = "insert into SalesUnidadesTransporte values('" + idUnidadTransporte + "', '" + placas + "', '" + marca + "', '" + modelo + "', '" + anio + "', '" + capacidad + "', '" + tipo + "')";
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















    }
}
