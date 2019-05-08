using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gsmWebsite.Business;

namespace gsmWebsite
{
    public partial class ItemToevoegenWinkelmandje : System.Web.UI.Page
    {
        Controller _controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            imgArtikel.ImageUrl ="~/Images/" +  _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Foto;
            lblArtNr.Text = Convert.ToString(Session["ArtNr"]);
            lblNaam.Text = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Naam;
            lblPrijs.Text = "€ "+_controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Prijs.ToString();
            lblVoorraad.Text = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Voorraad.ToString();






        }
        protected void btnvoegtoe(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtAantal.Text) > _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Voorraad)
            {
               lblfout .Text = "je voorraad is te klein! ";

            }
            else
            {
                try
                {
                    int NieuweVoorraad = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Voorraad - Convert.ToInt32(txtAantal.Text);
                    _controller.voegProductAanMandjeToe(1, _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).ArtNr, Convert.ToInt32(txtAantal.Text));
                    _controller.PasDeVoorraadAAN(Convert.ToInt32(Session["ArtNr"]), NieuweVoorraad);
                    _controller.SaveProduct();

                    Response.Redirect("winkelmandje.aspx");
                }
                catch
                {
                    lblfout.Text = "Dit product zit al in het mandje. Als u het aantal wil wijzigen, verwijder het dan uit het mandje en voeg het correcte aantal toe.";
                }

            }
        }

        protected void btnVoegtoe_Click(object sender, EventArgs e)
        {
            Response.Redirect("Winkelmandje.aspx");
        }
    }
}