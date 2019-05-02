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

            for (int i = 0; i >= gvArtikels.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(gvArtikels.SelectedRow.Cells[i]) == 0)
                {
                    gvArtikels.SelectedRow.Cells[5].Text = "Niet op voorraad.";
                }
                else
                {
                    gvArtikels.SelectedRow.Cells[5].Text = "Voeg product toe aan winkelmandje...";
                }
            }
        }

        protected void btnWinkelmandje_Click(object sender, EventArgs e)
        {
            Response.Redirect("Winkelmandje.aspx");
        }

        protected void gvArtikels_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void gvArtikels_PreRender(object sender, EventArgs e)
        {
            
        }
    }
}