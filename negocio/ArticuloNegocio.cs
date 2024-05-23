using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();
        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            try
            {
                accesoDatos.setearConsulta(
                 "SELECT Codigo, Nombre, A.Descripcion, C.Descripcion AS CDescripcion, M.Descripcion AS MDescripcion, Precio, A.IdCategoria AS ICategoria, A.IdMarca AS IMarca, A.Id AS IdArt " +
                 "FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id"
                );
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read()) {
                    Articulo articulo = new Articulo();

                    articulo.Id = (int)accesoDatos.Lector["IdArt"];
                    articulo.Codigo = (string)accesoDatos.Lector["Codigo"];
                    articulo.Nombre = (string)accesoDatos.Lector["Nombre"];
                    articulo.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    articulo.Precio = accesoDatos.Lector.GetDecimal(5);
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)accesoDatos.Lector["ICategoria"];
                    articulo.Categoria.Descripcion = (string)accesoDatos.Lector["CDescripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)accesoDatos.Lector["IMarca"];
                    articulo.Marca.Descripcion = (string)accesoDatos.Lector["MDescripcion"];
                    listaArticulos.Add(articulo);
                }
                return listaArticulos;
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

        public Articulo BuscarPorId(int id)
        {
            Articulo articulo = new Articulo();
            try
            {
                accesoDatos.setearConsulta(
                 "SELECT Codigo, Nombre, A.Descripcion, C.Descripcion AS CDescripcion, M.Descripcion AS MDescripcion, Precio, A.IdCategoria AS ICategoria, A.IdMarca AS IMarca, A.Id AS IdArt  FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id WHERE A.Id = " + id
                );
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {


                    articulo.Id = (int)accesoDatos.Lector["IdArt"];
                    articulo.Codigo = (string)accesoDatos.Lector["Codigo"];
                    articulo.Nombre = (string)accesoDatos.Lector["Nombre"];
                    articulo.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    articulo.Precio = accesoDatos.Lector.GetDecimal(5);
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)accesoDatos.Lector["ICategoria"];
                    articulo.Categoria.Descripcion = (string)accesoDatos.Lector["CDescripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)accesoDatos.Lector["IMarca"];
                    articulo.Marca.Descripcion = (string)accesoDatos.Lector["MDescripcion"];
                }
                return articulo;
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

        public int agregar(Articulo articulo)
        {
            int idArt;
            try
            {
                accesoDatos.setearConsulta(
                    "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdCategoria, IdMarca, Precio) " +
                    "OUTPUT INSERTED.ID " +
                    "VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @IdMarca, @Precio)"
                );
                accesoDatos.setearParametros("@Codigo", articulo.Codigo);
                accesoDatos.setearParametros("@Nombre", articulo.Nombre);
                accesoDatos.setearParametros("@Descripcion", articulo.Descripcion);
                accesoDatos.setearParametros("@IdCategoria", articulo.Categoria.Id);
                accesoDatos.setearParametros("@IdMarca", articulo.Marca.Id);
                accesoDatos.setearParametros("@Precio", articulo.Precio);
                idArt = accesoDatos.ejecutarScalar();
                return idArt;
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
        public void Modificar(Articulo articulo)
        {           
            try
            {
                accesoDatos.setearConsulta("UPDATE ARTICULOS SET Codigo=@Codigo,Nombre= @Nombre, Descripcion=@Descripcion,IdCategoria= @IdCategoria,Precio= @Precio WHERE Id =" + articulo.Id); 
                accesoDatos.setearParametros("@Codigo", articulo.Codigo);
                accesoDatos.setearParametros("@Nombre", articulo.Nombre);
                accesoDatos.setearParametros("@Descripcion", articulo.Descripcion);
                accesoDatos.setearParametros("@IdCategoria", articulo.Categoria.Id);
                accesoDatos.setearParametros("@Precio", articulo.Precio);
                accesoDatos.setearParametros("@Id", articulo.Id);
                accesoDatos.setearParametros("@IdMarca", articulo.Marca.Id);
                accesoDatos.ejecutarAccion();
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
        public void eliminar(string codigo) {
            try {
                accesoDatos.setearConsulta("DELETE FROM ARTICULOS WHERE Codigo = @Codigo");
                accesoDatos.setearParametros("@Codigo", codigo);
                accesoDatos.ejecutarAccion();
            } catch (Exception exception) {
                throw exception;
            }
        }
    }
}
