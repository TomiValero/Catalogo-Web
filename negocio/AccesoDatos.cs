using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector { get; set; }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
                Lector = lector;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ejecutarScalar()
        {

            int idart;
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                idart = (int)comando.ExecuteScalar();
                cerrarConexion();

                return idart;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void setearParametros(string name, object value)
        {
            comando.Parameters.AddWithValue(name, value);
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
