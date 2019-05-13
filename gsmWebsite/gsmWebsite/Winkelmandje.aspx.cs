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



            lblKlantNr.Text = _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).KlantNr.ToString(); //Je klantnummer word opgehaald via een sessie. 

            lblNaam.Text = _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).Voornaam + " " + _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).Naam; //Je naam en voornaam worden opgehaald via een persistence code waarbij je een sessie van je klantennummer bij mee stuurt.

            lblAdres.Text = Convert.ToString(_controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).adres); //je adres word opgehaald via een persistence code waarbij je een sessie van je klantennummer bij mee stuurt.

            lblPC.Text = _controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).PC.ToString(); //je postcode word opgehaald via een persistence code waarbij je een sessie van je klantennummer bij mee stuurt.

            lblgemeente.Text = Convert.ToString(_controller.Laadklant(Convert.ToInt32(Session["KlantNr"])).Gemeente); //je gemeente word opgehaald via een persistence code waarbij je een sessie van je klantennummer bij mee stuurt.

            lblBesteldatum.Text = DateTime.Now.ToLongDateString(); // De dag en datum van vandaag worden toegevoegd.


            gvWinkelmand.DataSource = _controller.haalwinkelmandop(Convert.ToInt32(Session["KlantNr"])); //via de persistence code worden er gegevens toegevoegd aan de gridview
            gvWinkelmand.DataBind();


        }

        protected void gvWinkelmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int NieuweVoorraad = _controller.LaadArtikelmetnummer(Convert.ToInt32(Session["ArtNr"])).Voorraad + Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[4].Text); 

            _controller.deleteProduct(Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[2].Text), Convert.ToInt32(Session["KlantNr"])); //hier verwijder je het artikel uit je winkelmandje    

            _controller.PasDeVoorraadAAN(Convert.ToInt32(Session["ArtNr"]), NieuweVoorraad); // via de persistence code die we hier ophalen gaat de voorraad aangepast worden

            if (_controller.ControleerDemand(Convert.ToInt32(Session["KlantNr"]))==false) //werkt nog niet fatsoenlijk, zou als je artikels verwijderd en er uiteindelijk geen voorwerp meer in winkelmand is dat deze van pagina veranderd.

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
            Response.Redirect("Default.aspx"); //als je op de knop klikt ga je weer naar de catalogus.
        }
    }
}
