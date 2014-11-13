using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Xml.Linq;
using System.Web.Hosting;
using libSE2014;
using SE2014Project;
using PathGraph;

namespace SE2014Project
{
    public partial class MapCreator : System.Web.UI.Page
    {
        

        public void drawSomething()
        {
            Response.Clear();
            Response.ContentType = "image/gif";
            List<string> drawable = new List<string>();
            drawable.Add("room"); //only draw rooms
            var map = new MapViewer(AppContext.Instance.getGraph().Verticies, AppContext.Instance.getGraph().Edges);
            //testing with default values
            var widthMap = 400;
            var heightMap = 400;
            var scaleMap = 200;
            var bmp = map.drawMap(widthMap, heightMap, scaleMap, AppContext.Instance.getGraph().Verticies[27], drawable, new List<Edge>());
            //var bmp =  map.drawMap(1024,1024,90,AppContext.Instance.getGraph().Verticies[27],drawable,new List<Edge>());
            bmp.Save(Response.OutputStream, ImageFormat.Gif);
        }

        public void drawSomething(string scale)
        {
           // Response.Clear();
           // Response.ContentType = "image/gif";
            List<string> drawable = new List<string>();
            drawable.Add("room"); //only draw rooms
            var scaleInt = int.Parse(scale);
            var map = new MapViewer(AppContext.Instance.getGraph().Verticies, AppContext.Instance.getGraph().Edges);
            var bmp = map.drawMap(1024, 1024, scaleInt, AppContext.Instance.getGraph().Verticies[27], drawable, new List<Edge>());
            bmp.Save(Response.OutputStream, ImageFormat.Gif);
            
        
        }


       

        protected void Page_Load(object sender, EventArgs e)
        {
             drawSomething();
            //ReadXmlFile();
        }

        protected void ButtonZoomIn_Click(object sender, EventArgs e)
        {
            drawSomething("400");    
        }

        protected void ButtonZoomOut_Click(object sender, EventArgs e)
        {
            drawSomething("90");
        }

   }
}