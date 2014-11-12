using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace SE2014Project
{
    // The data class containing two properties 
    [Serializable()]
    public class Data
    {
        public int witdh { get; set; }
        public int heigth { get; set; }
        public int scale { get; set; }
    }


    public partial class Imageviewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // getData();

            //getSomething();


        }


    

        private void getData() {

            //MapCreator mp = new MapCreator();

            //var sendScale = 90;//Session["getScale"];
            Session["getScale"] = 90;
            Response.Redirect("MapCreator.aspx");

            //mp.drawSomething("200");
        
        }

        protected void ButtonZoomIn_Click(object sender, EventArgs e)
        {
            getData();
        }

    }
}