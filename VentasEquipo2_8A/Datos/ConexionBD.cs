using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //METODO PARA LA CONEXION CON LA BD 
    public class ConexionBD
    {

         static string conexionstring = "server = ROGELIO\\MSSQLSERVERDEV; database = ERP;" +
              "integrated security = true";

         SqlConnection con = new SqlConnection(conexionstring);

    }
}
