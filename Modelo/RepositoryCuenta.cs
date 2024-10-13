using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCP_AMHCH.Modelo
{
    public class RepositoryCuenta
    {
        public IEnumerable<T> ObtenerCuentas<T>() where T : class, new()
        {
            var cuentas = new List<T>();
            SqlCommand command = new SqlCommand("ObtenerCuentas", conexion.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                conexion.con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Seleccionar de la DataTable y mapear a los tipos T (Cuenta o CuentaList)
                cuentas = dataTable.AsEnumerable().Select(row =>
                {
                    var cuenta = new T();

                    // Si es del tipo "Cuenta", establecer las propiedades específicas
                    if (cuenta is Cuenta cuentaObj)
                    {
                        cuentaObj.NRO_CUENTA = Convert.ToString(row["NRO_CUENTA"]);
                        cuentaObj.NRO_CUENTA2 = FormatearNroCuenta(Convert.ToString(row["NRO_CUENTA"]));
                        cuentaObj.TIPO = Convert.ToString(row["TIPO"]);
                        cuentaObj.MONEDA = Convert.ToString(row["MONEDA"]);
                        cuentaObj.NOMBRE = Convert.ToString(row["NOMBRE"]);
                        cuentaObj.SALDO = Convert.ToDouble(row["SALDO"]);
                    }
                    // Si es del tipo "CuentaList", establecer las propiedades específicas
                    else if (cuenta is CuentaList cuentaListObj)
                    {
                        cuentaListObj.NRO_CUENTA = FormatearNroCuenta(Convert.ToString(row["NRO_CUENTA"]));
                        cuentaListObj.TIPO = Convert.ToString(row["TIPO"]);
                        cuentaListObj.MONEDA = Convert.ToString(row["MONEDA"]);
                        cuentaListObj.NOMBRE = Convert.ToString(row["NOMBRE"]);
                        cuentaListObj.SALDO = Convert.ToDouble(row["SALDO"]);
                    }

                    return cuenta;
                }).Cast<T>().ToList();

                conexion.con.Close();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return cuentas;
        }
        /*
        public IEnumerable<T> ObtenerCuentas<T>(int tipo) where T : class, new()
        {

            var cuentas = new List<T>();
            SqlCommand command = new SqlCommand("ObtenerCuentas", conexion.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                conexion.con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (tipo==1)
                {
                    cuentas = dataTable.AsEnumerable().Select(row => new Cuenta
                    {
                        NRO_CUENTA = Convert.ToString(row["NRO_CUENTA"]),
                        NRO_CUENTA2 = FormatearNroCuenta(Convert.ToString(row["NRO_CUENTA"])),
                        TIPO = Convert.ToString(row["TIPO"]),
                        MONEDA = Convert.ToString(row["MONEDA"]),
                        NOMBRE = Convert.ToString(row["NOMBRE"]),
                        SALDO = Convert.ToDouble(row["SALDO"])
                    }).ToList();
                }
                else
                {
                    cuentas = dataTable.AsEnumerable().Select(row => new CuentaList
                    {
                        TIPO = Convert.ToString(row["TIPO"]),
                        MONEDA = Convert.ToString(row["MONEDA"]),
                        NRO_CUENTA = FormatearNroCuenta(Convert.ToString(row["NRO_CUENTA"])),
                        NOMBRE = Convert.ToString(row["NOMBRE"]),
                        SALDO = Convert.ToDouble(row["SALDO"])
                    }).ToList();
                }


                conexion.con.Close();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar o lanzar la excepción según tus necesidades)
                Console.WriteLine(ex.Message);
            }

            return cuentas;
        }
        */
        public string FormatearNroCuenta(string nroCuenta)
        {
            if (string.IsNullOrEmpty(nroCuenta) || nroCuenta.Length < 13) // Si es muy corto, no ocultamos nada
            {
                return nroCuenta;
            }
            int n = nroCuenta.Length;
            return nroCuenta.Substring(0, 3) + "-" + nroCuenta.Substring(4, n - 6) + "-" + nroCuenta.Substring(n - 5, 2) + "-" + nroCuenta.Substring(n - 2, 1);
        }
        public void AgregarCuenta(Cuenta cuenta)
        {
            string mensaje = "";
            cuenta.TIPO = (cuenta.NRO_CUENTA.Length == 14)?"AHO":"CTE";
            cuenta.SALDO = 0.00;
            try
            {
                SqlCommand command = new SqlCommand("sp_AgregarCuenta", conexion.con)
                {
                    CommandType = CommandType.StoredProcedure

                };
                command.Parameters.AddWithValue("@NRO_CUENTA", cuenta.NRO_CUENTA);
                command.Parameters.AddWithValue("@TIPO", cuenta.TIPO);
                command.Parameters.AddWithValue("@MONEDA", cuenta.MONEDA);
                command.Parameters.AddWithValue("@NOMBRE", cuenta.NOMBRE);
                command.Parameters.AddWithValue("@SALDO", cuenta.SALDO);
                conexion.con.Open();
                command.ExecuteNonQuery();

                conexion.con.Close();
                mensaje = "Registro exitoso";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            MessageBox.Show(mensaje);
        }
        public static bool dep_ret(string nro, string monto, int dr)
        {
            string cad;
            bool sw = false;
            if (dr == 1)
            {
                cad = "pro_deposito_cuenta";
            }
            else
            {
                cad = "pro_retiro_cuenta";
            }
            SqlCommand cmd = new SqlCommand(cad, conexion.con);
            cmd.Parameters.AddWithValue("@nro_cuenta", nro);
            cmd.Parameters.AddWithValue("@monto", Convert.ToDecimal(monto));

            cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(DateTime.Now.ToString("F")));
            if (dr == 2)
            {
                cmd.Parameters.Add("sw", SqlDbType.Int).Direction = ParameterDirection.Output;

            }
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.con.Open();
            cmd.ExecuteNonQuery();

            if (dr == 2)
            {
                if (Convert.ToInt32(cmd.Parameters["sw"].Value) == 1)
                {
                    sw = true;
                }
            }
            else
            {
                sw = true;
            }
            conexion.con.Close();
            return sw;


        }

        public static string obtener_saldo(string nro)
        {
            string saldo = "";

            try
            {
                // Abrir la conexión
                conexion.con.Open();

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand cmd = new SqlCommand("pro_obt_saldo", conexion.con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro de entrada para el número de cuenta
                cmd.Parameters.AddWithValue("@nro_cuenta", nro);

                // Agregar el parámetro de salida para obtener el saldo
                SqlParameter saldoParam = new SqlParameter("@saldo", SqlDbType.Decimal);
                saldoParam.Direction = ParameterDirection.Output; // Definir como parámetro de salida
                cmd.Parameters.Add(saldoParam);

                // Ejecutar el comando
                cmd.ExecuteNonQuery();

                // Recuperar el valor del parámetro de salida
                saldo = Convert.ToString(saldoParam.Value);
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes mostrar un mensaje o registrar el error)
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Cerrar la conexión en el bloque finally para garantizar que siempre se cierre
                conexion.con.Close();
            }

            return saldo;
        }




        }
}
