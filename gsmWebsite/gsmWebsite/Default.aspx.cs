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
        }

        protected void btnWinkelmandje_Click(object sender, EventArgs e)
        {
            Response.Redirect("Winkelmandje.aspx");
        }

        protected void gvArtikels_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}