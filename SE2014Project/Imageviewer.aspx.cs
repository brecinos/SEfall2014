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
        private int zoomFactor = 20;
        private int maxZoom = 300;
        private int minZoom = 10;
        private int zoomIncrement = 30;
        private int mapWidth = 400;
        private int mapHeight = 400;

        protected void Page_Load(object sender, EventArgs e)
        {
           // getData();

            //getSomething();

            if (!IsPostBack)
            {
                AppContext.Instance.MapWidth = mapWidth;
                AppContext.Instance.MapHeight = mapHeight;
                AppContext.Instance.MapZoomFactor = zoomFactor;
            }

            imgMap.ImageUrl = "MapCreator.aspx";
            imgMap.Width = AppContext.Instance.MapWidth;
            imgMap.Height = AppContext.Instance.MapHeight;
        }

        protected void ButtonZoomIn_Click(object sender, EventArgs e)
        {
            AppContext.Instance.MapZoomFactor += zoomIncrement;
            if (AppContext.Instance.MapZoomFactor > maxZoom)
                AppContext.Instance.MapZoomFactor = maxZoom;

            imgMap.ImageUrl = "MapCreator.aspx" + "?CacheBuster=" + DateTime.Now.Ticks.ToString();
        }

        protected void ButtonZoomOut_Click(object sender, EventArgs e)
        {
            AppContext.Instance.MapZoomFactor -= zoomIncrement;
            if (AppContext.Instance.MapZoomFactor < minZoom)
                AppContext.Instance.MapZoomFactor = minZoom;

            imgMap.ImageUrl = "MapCreator.aspx" + "?CacheBuster=" + DateTime.Now.Ticks.ToString();
        }

    }
}