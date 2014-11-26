using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE2014Project
{
    public partial class ScreenSplash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonScreen_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InitialFrontal.aspx");
        }
    }
}