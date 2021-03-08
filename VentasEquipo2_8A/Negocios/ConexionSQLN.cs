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









    }
}
