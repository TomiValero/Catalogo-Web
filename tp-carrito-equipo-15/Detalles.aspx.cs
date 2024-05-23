using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_equipo_15
{
    public partial class Detalles : System.Web.UI.Page
    {
        public List<string> Img;
        public int indi = 0;
        public Articulo art;

        public object Int { get; private set; }

        private void CargarProducto(int id)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            art = articuloNegocio.BuscarPorId(id);

            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Img = imagenNegocio.Imagenes(art);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            CargarProducto(id);
            lblWarningCant.Text = "";
            lblCategoria.Text = art.Categoria.ToString();
            lblMarca.Text = art.Marca.ToString();
            lblCodigo.Text = art.Codigo.ToString();
            if (!IsPostBack)
            {
                Session["indi"] = 0;
                Imagen.ImageUrl = Img[(int)Session["indi"]];

            }
        }

        protected void BtnAnterior_Click(object sender, EventArgs e)
        {
            int indi = (int)Session["indi"];
            if (indi > 0)
            {
                indi--;
                Session["indi"] = indi;
                Imagen.ImageUrl = Img[indi];

            }
        }

        protected void BtnProxima_Click(object sender, EventArgs e)
        {
            int indi = (int)Session["indi"];
            if (indi < Img.Count - 1)
            {
                indi++;
                Session["indi"] = indi;
                Imagen.ImageUrl = Img[indi];
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                int cant = int.Parse(txtCantidad.Text);

                if (cant > 0)
                {
                    int cantActual = 0;
                    int idArt = art.Id;

                    if (Session["cantArt"] != null)
                    {
                        cantActual = (int)Session["cantArt"];
                    }

                    cantActual += cant;
                    Session["cant"] = cant;
                    Session["idArt"] = idArt;
                    Response.Redirect("Carrito.aspx?", false);
                }
                else
                {
                    lblWarningCant.Text = "Cantidad invalida";
                }

            }
            else lblWarningCant.Text = "Ingrese una cantidad";




        }
    }
}