using BCP_AMHCH.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCP_AMHCH.Controlador
{
    class CuentaController
    {
        RepositoryCuenta rep = new RepositoryCuenta();
        public void listar_cuenta(DataGridView dg)
        {
            dg.ColumnCount = 5;
            dg.Columns[0].Name = "Tipo";
            dg.Columns[1].Name = "Moneda";
            dg.Columns[2].Name = "Cuenta";

            dg.Columns[3].Name = "Titular";


            dg.Columns[4].Name = "Saldo";
            
            conexion a = new conexion();
            /*
            conexion.con.Open();
            //SqlDataReader row = rep.ObtenerCuentas<CuentaList>().ExecuteReader();

            while (row.Read())
            {
                ArrayList al = new ArrayList();
                al.Add(row["TIPO"].ToString());
                al.Add(row["MONEDA"].ToString());
                al.Add(row["NRO_CUENTA"].ToString());
                al.Add(row["NOMBRE"].ToString());
                al.Add(row["SALDO"].ToString());
                dg.Rows.Add(al.ToArray());
            }
            */
            conexion.con.Close();

            

        }


        public static bool valdec(string val)
        {
            return Regex.IsMatch(val, @"(\d+((\,{1,1}\d{ 1,2})?))$");
        }

        public static bool dep_ret(string nro, string monto, int dr)
        {
            bool sw = false;
            if (valdec(monto))
            {
                if (RepositoryCuenta.dep_ret(nro, monto, dr))
                {
                    sw = true;
                }
                else
                {
                    MessageBox.Show("No se dispone de ese monto en la cuenta");
                }

            }
            else
            {
                MessageBox.Show("Monto no valido");
            }
            return sw;

        }

    }
}
