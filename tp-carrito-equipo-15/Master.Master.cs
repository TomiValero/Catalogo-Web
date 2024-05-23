using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_equipo_15 {
    public partial class Master : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            int cantActual = 0;
            if (Session["cantArt"] != null)
            {
                cantActual = (int)Session["cantArt"];
            }
            lblNumCarr.Text = cantActual.ToString();
        }
    }
}