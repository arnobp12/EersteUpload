using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gsmWebsite.Business;
namespace gsmWebsite
{
    public partial class Winkelmandje : System.Web.UI.Page
    {
        Controller _controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {



            // lblKlantNr.Text = _controller.Laadklant()
            // lblNaam.Text = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Naam;
            //lblPrijs.Text = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Prijs.ToString();
            // lblVoorraad.Text = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Voorraad.ToString();


            gvWinkelmand.DataSource = _controller.haalwinkelmandop();
            gvWinkelmand.DataBind();

        }
    }
}