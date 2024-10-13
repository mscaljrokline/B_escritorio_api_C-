using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_AMHCH.Vista
{
    class Formato
    {
        public static string FormatearNroCuenta(string nroCuenta)
        {
            if (string.IsNullOrEmpty(nroCuenta) || nroCuenta.Length < 13) // Si es muy corto, no ocultamos nada
            {
                return nroCuenta;
            }
            int n = nroCuenta.Length;
            return nroCuenta.Substring(0, 3) + "-" + nroCuenta.Substring(4, n - 6) + "-" + nroCuenta.Substring(n - 5, 2) + "-" + nroCuenta.Substring(n - 2, 1);
        }
    }
}
