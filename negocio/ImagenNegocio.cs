using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<string> Imagenes(Articulo articulo)
        {
            List<string> listaimagenes = new List<string>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo =" + articulo.Id);
                // accesoDatos.setearParametros("@id", articulo.Id);
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    if (!(accesoDatos.Lector["ImagenUrl"] is DBNull))
                        listaimagenes.Add((string)accesoDatos.Lector["ImagenUrl"]);

                }
                return listaimagenes;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public void agregar(List<string> img, int id)
        {

            try
            {
                foreach (string item in img)
                {
                    AccesoDatos datos = new AccesoDatos();
                    datos.setearConsulta("INSERT INTO IMAGENES VALUES (@IdArticulo,'" + item + "')");
                    datos.setearParametros("@IdArticulo", id);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE IMAGENES WHERE IdArticulo =" + id);
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
