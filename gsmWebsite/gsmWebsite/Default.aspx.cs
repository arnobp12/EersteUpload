using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gsmWebsite.Business;

namespace gsmWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        Controller _controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvArtikels.DataSource = _controller.HaalArtikelsOp();
            gvArtikels.DataBind();

            for (int i = 0; i < gvArtikels.Rows.Count; i++)
            {
                if (gvArtikels.Rows[i].Cells[4].Text == "0")
                {
                    gvArtikels.Rows[i].Cells[5].Text = "Niet op voorraad";
                    

                }
            
            }
        }

        protected void btnWinkelmandje_Click(object sender, EventArgs e)
        {
            if (_controller.controleervoorraad(Convert.ToInt32(Session["KlantNr"])))
            {
                Response.Redirect("winkelmandje.aspx");
            }
            else
            {
                Response.Redirect("WinkelmandLeeg.aspx");
            }
        }

        protected void gvArtikels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ArtNr"] = gvArtikels.SelectedRow.Cells[0].Text;

            Response.Redirect("itemToevoegenWinkelmandje.aspx");

        }

        
    }
}