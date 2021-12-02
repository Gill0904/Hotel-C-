using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllHotel
{
    public class Habitacion
    {
        #region Metodos
        public Habitacion()
        {
            _id = 0;
            _piso = 0;
            _numHabitacion = 0;
            _tipo = "";
            _estatus = "";
            _costo = 0;
            _Conexion = Conexion.ConexionWin();
        }
        public bool Actualizar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_ActualizarHabitacion", cn);
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _id;
                cmd.Parameters.Add("@costo", SqlDbType.Money).Value = _costo;
                cmd.Parameters.Add("@estatus", SqlDbType.VarChar,15).Value = _estatus;
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
                SqlCommand cmd = new SqlCommand("usp_BuscarHabitacion", cn);
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
                SqlCommand cmd = new SqlCommand("select * from Habitaciones", cn);
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }
        #endregion

        #region Atributos
        private byte _id;
        private byte _piso ;
        private int _numHabitacion;
        private string _tipo;
        private string _estatus;
        private int _costo;
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
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        public int Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        #endregion
    }
}
