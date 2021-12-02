using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllHotel
{
    public class Conexion
    {
        public static string ConexionWin()
        {
            string cadcon = "Data Source=DESKTOP-GJ80GTH;" + "Initial Catalog=ZOOLOGICO_TBD;" + "Integrated Security=true";
            return cadcon;
        }
    }
}
