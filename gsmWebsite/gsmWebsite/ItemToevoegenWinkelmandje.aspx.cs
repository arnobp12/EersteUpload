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
            int nr = Convert.ToInt32(Session["ArtNr"]);
            if (!IsPostBack)
            {
                DataList1.DataSource = _controller.LaadArtikelmetnummer(nr);
                DataList1.DataBind();
            }

            //Lid ophalen

            int id = Convert.ToInt32(DataList1.SelectedValue);
            

            
        }
    }
}