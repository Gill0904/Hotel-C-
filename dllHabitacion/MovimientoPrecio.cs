using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllHotel
{
    public class MovimientoPrecio
    {
        #region Metodos
        public MovimientoPrecio()
        {
            _id = 0;
            _piso = 0;
            _numHabitacion = 0;
            _costo = 0;
            _costoActualizado = 0;
            _Conexion = Conexion.ConexionWin();
        }
        public bool Agregar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarMovimientoPrecio", cn);
                cmd.Parameters.Add("@numHabitacion", SqlDbType.Int).Value = _numHabitacion;
                cmd.Parameters.Add("@piso", SqlDbType.Int).Value = _piso;
                cmd.Parameters.Add("@costo", SqlDbType.Money).Value = _costo;
                cmd.Parameters.Add("@costoActualizado", SqlDbType.Money).Value = _costoActualizado;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                }
                cn.Close();
            }
            return resultado;
        }
        public System.Data.DataTable BuscarxID()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_BuscarMovimientoPre", cn);
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _id;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }
        public DataTable Consultar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("select * from MovimientoPrecio", cn);
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }
        public bool Eliminar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_EliminarMovimientoPrecio", cn);
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _id;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                }
                cn.Close();
            }
            return resultado;
        }

        #endregion

        #region Atributos
        private byte _id;
        private byte _piso;
        private int _numHabitacion;
        private int _costo;
        private int _costoActualizado;
        private string _Conexion;
        #endregion

        #region Propiedades
        public byte Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public byte Piso
        {
            get { return _piso; }
            set { _piso = value; }
        }
        public int NumHabitacion
        {
            get { return _numHabitacion; }
            set { _numHabitacion = value; }
        }
        public int Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        public int CostoActualizado
        {
            get { return _costoActualizado; }
            set { _costoActualizado = value; }
        }
        #endregion
    }
}
