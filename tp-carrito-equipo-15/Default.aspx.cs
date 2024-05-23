using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace tp_carrito_equipo_15 {
    public partial class Default : System.Web.UI.Page {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e) {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<string> listaImagenesBanner = new List<string> {
                "https://http2.mlstatic.com/D_NQ_688120-MLA76025194258_052024-OO.webp",
                "https://http2.mlstatic.com/D_NQ_946704-MLA76296870887_052024-OO.webp",
                "https://http2.mlstatic.com/D_NQ_732245-MLA76247333205_052024-OO.webp",
                "https://http2.mlstatic.com/D_NQ_606738-MLA76267875949_052024-OO.webp",
            };
            Session.Add("listaArticulos", articuloNegocio.listar());
            listaArticulos.DataSource = Session["listaArticulos"];
            listaArticulos.DataBind();
            imagenesBanner.DataSource = listaImagenesBanner;
            imagenesBanner.DataBind();
        }
        protected void filter_TextChanged(object sender, EventArgs e) {
            List<Articulo> listaArticulosDb = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltradaDb = listaArticulosDb.FindAll(articulo => articulo.Nombre.ToUpper().Contains(filter.Text.ToUpper()));
            listaArticulos.DataSource = listaFiltradaDb;
            listaArticulos.DataBind();
        }
        protected void listaArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Articulo articulo = (Articulo)e.Item.DataItem;
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                List<string> listaImagenes = imagenNegocio.Imagenes(articulo);
                Image img = (Image)e.Item.FindControl("imagenArticulo");
                img.ImageUrl = listaImagenes[0];
            }
        }
    }
}