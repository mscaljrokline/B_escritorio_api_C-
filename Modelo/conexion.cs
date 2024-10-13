using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_AMHCH.Modelo
{
    public class conexion
    {
        public static string cad = "Data Source=LAPTOP-R4IGAAED\\SQLEXPRESS;Initial Catalog=BD_TRANSACCIONES_HCH_2;User ID=USUARIO_3; Password=PASSWORD";
        public static SqlConnection con = new SqlConnection(cad);
    }
}
