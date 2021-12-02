using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllHotel
{
    public class Clientes
    {
        #region Metodos
        public Clientes()
        {
            _id = 0;
            _nombre = "";
            _apepat = "";
            _apemat = "";
            _telefono = "";
            _Conexion = Conexion.ConexionWin();
        }
        public bool Agregar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCliente", cn);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar,15).Value = _nombre;
                cmd.Parameters.Add("@apepat", SqlDbType.VarChar,15).Value = _apepat;
                cmd.Parameters.Add("@apemat", SqlDbType.VarChar, 15).Value = _apemat;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 15).Value = _telefono;
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
                SqlCommand cmd = new SqlCommand("usp_BuscarCliente", cn);
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
                SqlCommand cmd = new SqlCommand("select * from Clientes", cn);
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
                SqlCommand cmd = new SqlCommand("usp_EliminarCliente", cn);
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
        private string _nombre;
        private string _apepat;
        private string _apemat;
        private string _telefono;
        private string _Conexion;
        #endregion

        #region Propiedades
        public byte Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre= value; }
        }
        public string Apepat
        {
            get { return _apepat; }
            set { _apepat = value; }
        }
        public string Apemat
        {
            get { return _apemat; }
            set { _apemat = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        #endregion
    }
}
