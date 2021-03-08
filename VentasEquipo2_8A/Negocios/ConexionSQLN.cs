using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class ConexionSQLN
    {
        ConexionSQL cn = new ConexionSQL();

        //********************** TABLA UNIDADES DE TRANSPORTE **************************
        public DataTable ConsultaDt()
        {
            return cn.ConsultarUnidadesTransporte();
        }

        public int insertarUnidad(int idUnidadTransporte, string placas, string marca, string modelo, int anio, int capacidad, string tipo)
        {
            return cn.insertarUnidad(idUnidadTransporte, placas, marca, modelo, anio, capacidad, tipo);
        }
        public int modificarUnidadTransporte(int idUnidadTransporte, string placas, string marca, string modelo, int anio, int capacidad, string tipo)
        {
            return cn.modificarUnidadTransporte(idUnidadTransporte, placas, marca, modelo, anio, capacidad, tipo);
        }

        public int eliminarunidadTransporte(int idUnidadTransporte)
        {
            return cn.eliminarUnidadTransporte(idUnidadTransporte);
        }



        //******************************TABLA CULTIVOS *******************************************

        public DataTable ConsultaCultivosDT()
        {
            return cn.ConsultarCultivosDG();
        }

        public int insertarCultivos(string idCulti, string nom, string costoAse, string esta)
        {


            return cn.InsertarCultivos(idCulti, nom, costoAse, esta);

        }

        public int modificarCultivos(string idCulti, string nom, string costoAse, string esta)
        {

            return cn.ModificarCultivos(idCulti, nom, costoAse, esta);

        }


        public int eliminarCultivos(string idCul)
        {
            return cn.EliminarCultivos(idCul);
        }


        //******************************TABLA CLIENTES *******************************************

        public DataTable ConsultaCliente()
        {
            return cn.ConsultarCliente();
        }

        public int InsertarCliente(string idClien, string nom, string rz, string lm, string rfc, string tel, string email, string tipo)
        {


            return cn.InsertarCliente(idClien, nom, rz, lm, rfc, tel, email, tipo);

        }

        public int ModificarClientes(string idClien, string nom, string rz, string lm, string rfc, string tel, string email, string tipo)
        {

            return cn.ModificarCliente(idClien, nom, rz, lm, rfc, tel, email, tipo);

        }


        public int EliminarCliente(string idClien)
        {
            return cn.EliminarCliente(idClien);
        }



        //********************** TABLA UNIDADES DE MIEMBROS **************************

        public DataTable ConsultaMiembros()
        {
            return cn.ConsultarMiembros();
        }

        public int insertarMiembros(string idCliente, string idAsociacion, string estatus, string Incorporacion)
        {


            return cn.insertarMiembros(idCliente, idAsociacion, estatus, Incorporacion);

        }

        public int modificarMiembros(string idCliente, string idAsociacion, string estatus, string Incorporacion)
        {

            return cn.modificarMiembros(idCliente, idAsociacion, estatus, Incorporacion);

        }


        public int eliminarMiembros(string idAsociacion)
        {
            return cn.EliminarCultivos(idAsociacion);
        }

        //********************** TABLA UNIDADES DE  Asociacion **************************

        public DataTable ConsultaAsociacion()
        {
            return cn.ConsultarAsociacion();
        }

        public int insertarAsociacion(string idAsociacion, string nombre, string estatus)
        {


            return cn.InsertarAsociacion(idAsociacion, nombre, estatus);

        }

        public int modificarAsociacion(string idAsociacion, string nombre, string estatus)
        {

            return cn.ModificarAsociacion(idAsociacion, nombre, estatus);

        }


        public int eliminarAsociacion(string idAsociacion)
        {
            return cn.EliminarAsociacion(idAsociacion);
        }




    }
}
