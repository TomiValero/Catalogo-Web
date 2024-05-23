using dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
public class MarcaNegocio
    {
       private List<Marca> lista = new List<Marca>();
       private AccesoDatos accesoMarca = new AccesoDatos();
        private bool ComprobarDato(Marca m)
        {
            foreach (Marca marca in lista)
            {
                if(marca.Descripcion == m.Descripcion)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Marca> listar()
        {
         

            try
            {
                accesoMarca.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                accesoMarca.ejecutarLectura();

                while (accesoMarca.Lector.Read())
                {
                  Marca aux = new Marca();
                    aux.Id = (int)accesoMarca.Lector["Id"];

                    if (!(accesoMarca.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)accesoMarca.Lector["Descripcion"];
                    if (!(ComprobarDato(aux)))
                    { 
                        lista.Add(aux);
                    }
                    
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoMarca.cerrarConexion();
            }

        }
        public void agregar(Marca marca)
        {
           
            try
            {
                accesoMarca.setearConsulta("INSERT INTO MARCAS VALUES ('" +marca.Descripcion + "')");
                accesoMarca.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
               accesoMarca.cerrarConexion();
            }
        }
        public void modificar(Marca marca)
        {
          
            try
            {
                accesoMarca.setearConsulta("UPDATE MARCAS SET Descripcion = '" + marca.Descripcion + "' WHERE ID = " + marca.Id);
                accesoMarca.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoMarca.cerrarConexion();
            }
        }


        public void eliminar(int id)
        {
           
            try
            {
               accesoMarca.setearConsulta("DELETE MARCAS WHERE Id =" + id);
                accesoMarca.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoMarca.cerrarConexion();
            }
        }
    }
}
