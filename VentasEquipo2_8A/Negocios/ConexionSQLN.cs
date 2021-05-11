using System;
using System.Collections.Generic;
using System.Data;//
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;//
using Entidad;//

namespace Negocios
{
    public class ConexionSQLN
    {
        ConexionSQL cn = new ConexionSQL();

        //*************LOGIN**************
        public int conSQL(string user, string pass)
        {
            return cn.consultalogin(user, pass);
        }



        //********************** TABLA CIUDADES **************************
        public DataTable ConsultaCiudadesDT()
        {
            return cn.ConsultarCiudadesDG();
        }





        //********************** TABLA UNIDADES DE TRANSPORTE **************************
        public DataTable ConsultaDt()
        {
            return cn.ConsultarUnidadesTransporte();
        }

        public int insertarUnidad(int idUnidadTransporte, string placas, string marca, string modelo, int anio, int capacidad, string tipo, string estatus)
        {
            return cn.insertarUnidad(idUnidadTransporte, placas, marca, modelo, anio, capacidad, tipo, estatus);
        }
        public int modificarUnidadTransporte(int idUnidadTransporte, string placas, string marca, string modelo, int anio, int capacidad, string tipo, string estatus)
        {
            return cn.modificarUnidadTransporte(idUnidadTransporte, placas, marca, modelo, anio, capacidad, tipo, estatus);
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



        //******************************TABLA PARCELAS *******************************************

        public DataTable ConsultaParcelasDT()
        {
            return cn.ConsultarParcelasDG();
        }

        public int InsertarParcelas(string idParcela, string extension, string idCliente, string idCultivo, string idDireccion, string estatus)
        {


            return cn.InsertarParcelas(idParcela, extension, idCliente, idCultivo, idDireccion, estatus);

        }

        public int ModificarParcelas(string idParcela, string extension, string idCliente, string idCultivo, string idDireccion, string estatus)
        {

            return cn.ModificarParcelas(idParcela, extension, idCliente, idCultivo, idDireccion, estatus);

        }

        //-*******************************JOIN DE LA TABLA CLIENTE Y IRECCIONES CLIENTES****************
        public DataTable ConsultarClienteYDireClienteDT()
        {
            return cn.ConsultarClienteYDireClienteDG();
        }


        //-*******************************JOIN DE PARCELAS****************
        public DataTable ConsultarJoinParcelasDT()
        {
            return cn.ConsultarJoinParcelasDG();
        }





        //********************** TABLA DIRECCIONES CLIENTES **************************
        public DataTable ConsultaDireccionCliente()
        {
            return cn.ConsultarDireccionCliente();
        }

        public int insertarDireccionCliente(string idDireccion, string calle, string numero, string colonia, string codigoPostal, string tipo, string idCliente, string idCiudad)
        {
            return cn.insertarDireccionCliente(idDireccion, calle, numero, colonia, codigoPostal, tipo, idCliente, idCiudad);
        }
        public int modificarDireccionCliente(string idDireccion, string calle, string numero, string colonia, string codigoPostal, string tipo, string idCliente, string idCiudad)
        {
            return cn.modificarDireccionCliente(idDireccion, calle, numero, colonia, codigoPostal, tipo, idCliente, idCiudad);
        }

        public int eliminarDireccionCliente(string idDireccion)
        {
            return cn.eliminarDireccionCliente(idDireccion);
        }


        //********************** TABLA UNIDADES DE MIEMBROS **************************

        public DataTable ConsultaMiembrosDT()
        {
            return cn.ConsultarMiembrosDG();
        }

        public int insertarMiembrosDT(string idCliente, string idAsociacion, string estatus, string Incorporacion)
        {


            return cn.insertarMiembrosDG(idCliente, idAsociacion, estatus, Incorporacion);

        }

        public int modificarMiembrosDT(string idCliente, string idAsociacion, string estatus, string Incorporacion)
        {

            return cn.modificarMiembrosDG(idCliente, idAsociacion, estatus, Incorporacion);

        }



        //******************************TABLA MANTENIMIENTO *******************************************
        public DataTable ConsultaMantenimientoDT()
        {
            return cn.ConsultarMantenimientoDG();
        }

        public int InsertarMantenimientoDT(string idMantenimiento, string fechaInicio, string fechaFin, string taller, string costo, string comentarios, string tipo, string idUnidadTransporte, string estatus)
        {


            return cn.InsertarMantenimientoDG(idMantenimiento, fechaInicio, fechaFin, taller, costo, comentarios, tipo, idUnidadTransporte, estatus);

        }

        public int ModificarMantenimientoDT(string idMantenimiento, string fechaInicio, string fechaFin, string taller, string costo, string comentarios, string tipo, string idUnidadTransporte, string estatus)
        {

            return cn.ModificarMantenimientoDG(idMantenimiento, fechaInicio, fechaFin, taller, costo, comentarios, tipo, idUnidadTransporte, estatus);

        }


        //******************************TABLA CONTACTOCLIENTE *******************************************
        public DataTable ConsultaContactoClienteDT()
        {
            return cn.ConsultarContactoClienteDG();
        }

        public int InsertarContactoClienteDT(string idContacto, string nombre, string telefono, string email, string idCliente, string estatus)
        {


            return cn.InsertarContactoClienteDG(idContacto, nombre, telefono, email, idCliente, estatus);

        }

        public int ModificarContactoClienteDT(string idContacto, string nombre, string telefono, string email, string idCliente, string estatus)
        {

            return cn.ModificarContactoClienteDG(idContacto, nombre, telefono, email, idCliente, estatus);

        }



        //******************************TABLA SalesAsesorias *******************************************
        public DataTable ConsultarSalesAsesoriasDT()
        {
            return cn.ConsultarSalesAsesoriasDG();
        }

        public int InsertarSalesAsesoriasDT(string idAsesoria, string fecha, string comentarios, string estatus, string costo, string idParcela, string idEmpleado, string idUnidadTransporte)
        {


            return cn.insertarSalesAsesoriasDG(idAsesoria, fecha, comentarios, estatus, costo, idParcela, idEmpleado, idUnidadTransporte);

        }

        public int ModificarSalesAsesoriasDT(string idAsesoria, string fecha, string comentarios, string estatus, string costo, string idParcela, string idEmpleado, string idUnidadTransporte)
        {

            return cn.modificarSalesAsesoriasDG(idAsesoria, fecha, comentarios, estatus, costo, idParcela, idEmpleado, idUnidadTransporte);

        }

       
        //-----select de empleados
            public DataTable ConsultarEmpleadosDT()
        {
            return cn.ConsultarEmpleadosDG();
        }





        ////////////////////Paginacion_Parcelas/////////////
        ///
        ConexionSQL objd = new ConexionSQL();
        public DataSet N_listar_Parcelas(Class_Entidad obje)
        {
            return objd.Lista_Parcelas(obje);
        }

        ////////////////////Paginacion_Cultivos/////////////
        public DataSet N_listar_Cultivos(Class_Entidad obje)
        {
            return objd.Lista_Cultivos(obje);
        }



        ////////////////////Paginacion_Miembros/////////////
        public DataSet N_listar_Miembros(Class_Entidad obje)
        {
            return objd.Lista_Miembros(obje);
        }

        ////////////////////Paginacion_Miembros/////////////
        public DataSet N_listar_Mantenimiento(Class_Entidad obje)
        {
            return objd.Lista_Mantenimiento(obje);
        }


        ////////////////////Paginacion_Asociaciones/////////////
        public DataSet N_listar_SalesAsociaciones(Class_Entidad obje)
        {
            return objd.Lista_Asociaciones(obje);
        }

        ////////////////////Paginacion_CONTACTO_CLIENTE/////////////
        public DataSet N_listar_CONTACTOCLIENTE(Class_Entidad obje)
        {
            return objd.Lista_ContactosCliente(obje);
        }



        ////////////////////Paginacion_SalesUnidadesTransporte/////////////
        public DataSet N_listar_SalesUnidadesTransporte(Class_Entidad obje)
        {
            return objd.Lista_SalesUnidadesTransporte(obje);
        }


        ////////////////////Paginacion_SalesDireccionesCliente/////////////
        public DataSet N_listar_SalesDireccionesCliente(Class_Entidad obje)
        {
            return objd.Lista_SalesDireccionesCliente(obje);
        }

        ////////////////////Paginacion_Cliente/////////////
        public DataSet N_listar_Cliente(Class_Entidad obje)
        {
            return objd.Lista_Cliente(obje);
        }

        ////////////////////Paginacion_SalesAsesorias/////////////
        public DataSet N_listar_SalesAsesorias(Class_Entidad obje)
        {
            return objd.Lista_SalesAsesorias(obje);
        }



    }
}
