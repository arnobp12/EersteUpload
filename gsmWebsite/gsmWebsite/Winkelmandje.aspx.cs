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



            lblKlantNr.Text = _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).KlantNr.ToString();

            lblNaam.Text = _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).Voornaam + " " + _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).Naam;

            lblAdres.Text = Convert.ToString(_controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).adres);

            lblPC.Text = _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).PC.ToString();

            lblgemeente.Text = Convert.ToString(_controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).Gemeente);

            lblBesteldatum.Text = DateTime.Now.ToLongDateString();


            gvWinkelmand.DataSource = _controller.haalwinkelmandop(Convert.ToInt32(Session["KlantNr"]));

            gvWinkelmand.DataBind();


        }

        protected void gvWinkelmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int NieuweVoorraad = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Voorraad + Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[4].Text);

            _controller.deleteProduct(Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[2].Text), Convert.ToInt32(Session["KlantNr"]));

            _controller.PasDeVoorraadAAN(Convert.ToInt32(Session["ArtNr"]), NieuweVoorraad);

            if (_controller.ControleerDemand(Convert.ToInt32(Session["KlantNr"]))==false)

            {
                Response.Redirect("WinkelmandLeeg.aspx");
            }

            else
            {
                gvWinkelmand.DataSource = _controller.haalwinkelmandop(Convert.ToInt32(Session["KlantNr"]));

                gvWinkelmand.DataBind();
            }

        }

        protected void btnbestel_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnTerugCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
