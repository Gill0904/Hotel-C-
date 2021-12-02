using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllHotel
{
    public class Usuarios
    {
        #region Metodos
        public Usuarios()
        {
            _id = 0;
            _nombre = "";
            _contrasena = "";
            _rol = "";
            _Conexion = Conexion.ConexionWin();
        }
        public bool Agregar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarUsuario", cn);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = _nombre;
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar, 20).Value = _contrasena;
                cmd.Parameters.Add("@rol", SqlDbType.VarChar, 20).Value = _rol;
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
                SqlCommand cmd = new SqlCommand("usp_BuscarUsuario", cn);
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
                SqlCommand cmd = new SqlCommand("select * from Usuarios", cn);
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
                SqlCommand cmd = new SqlCommand("usp_EliminarUsuario", cn);
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
        public bool login()
        {
            bool resultado = false;
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT nombre,contrasena FROM Usuarios WHERE nombre='" + _nombre + "' AND contrasena='" + _contrasena + "'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
                return resultado;
            }
        }

        #endregion

        #region Atributos
        private byte _id;
        private string _nombre;
        private string _contrasena;
        private string _rol;
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
            set { _nombre = value; }
        }
        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }
        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
        #endregion
    }
}
