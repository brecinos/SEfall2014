﻿using System;
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
            var widthMap = AppContext.Instance.MapWidth;
            var heightMap = AppContext.Instance.MapHeight;
            var scaleMap = AppContext.Instance.MapZoomFactor;
            var bmp = map.drawMap(widthMap, heightMap, scaleMap, AppContext.Instance.getGraph().FindVertexByID(AppContext.Instance.DestinationRoom), drawable, new List<Edge>());
            //var bmp =  map.drawMap(1024,1024,90,AppContext.Instance.getGraph().Verticies[27],drawable,new List<Edge>());
            bmp.Save(Response.OutputStream, ImageFormat.Gif);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            drawSomething();
        }

   }
}