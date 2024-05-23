using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos accesoCategoria = new AccesoDatos();    

            try
            {
                accesoCategoria.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                accesoCategoria.ejecutarLectura();

                while (accesoCategoria.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)accesoCategoria.Lector["Id"];

                    if(!(accesoCategoria.Lector["Descripcion"] is DBNull))
                    aux.Descripcion = (string)accesoCategoria.Lector["Descripcion"];

                    lista.Add(aux);
                }
                                                   
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                accesoCategoria.cerrarConexion();
            }
                     
        }
        public void agregar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO CATEGORIAS VALUES ('" + nueva.Descripcion + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion = '" + nueva.Descripcion + "' WHERE ID = " + nueva.Id );
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE CATEGORIAS WHERE Id =" + id );
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
