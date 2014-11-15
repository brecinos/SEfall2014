using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Hosting;
using libSE2014;
using PathGraph;

namespace SE2014Project
{
    public partial class _3dViewer : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            //set the image on the initial load
           

            if (!IsPostBack)
                setImage();
                //loadImage(); 
         
        }

        private void FillDropDowns() { 
        
            GraphLoader graphicloader =  new GraphLoader();

            String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
            bool success = graphicloader.load(file);

          //  this.DropDownBuilding.DataSource = 
        
        }


        private void setImage()
        {
            string imagepath = HostingEnvironment.MapPath(@"/Images/");
            //var pathFromXmlImage =  @"~\IMG_1949.jpg";
            string initialImageString = "IMG_";
            string numberString = "1949";
            string extension = ".jpg";

            this.Image1.ImageUrl = imagepath + initialImageString + numberString + extension;//@"/App_Data/Images/IMG_1948.jpg";//imagepath+initialImageString+numberString+extension;

            // adding something dynamically
            //System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            //img.ImageUrl = imagepath + initialImageString + numberString + extension;

            //PanelImage.Controls.Add(img);
            //DropDownBuilding.DataSource =  DropDownBuilding
                //DropDownBuilding.DataSource = 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // var filepath = Image1.ImageUrl;
           // var myval = int.Parse((Image1.ImageUrl).Substring(5,4));
           // this.Image1.ImageUrl = //imagepath + initialImageString + numberString + extension;
        }




        /*
        private void  loadImage(){
        
        String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
        string imagepath = HostingEnvironment.MapPath(@"/App_Data/Images/");

        Graph gr = new Graph();

        GraphLoader gl = new GraphLoader();
        
        bool success = gl.load(file);

        var vtx = gl.GetVerticies();
        var edges = gl.GetEdges();

        foreach (var v in vtx)
        {
            gr.AddVertex(v);
        }

        foreach (var e in edges)
        {
            gr.AddEdge(e);
            //string imagepath = @"/App_Data/Images/";
            string imagepath2 = @"~/App_Data/Images/";
            //ImageUrl="~/App_Data/Images/IMG_1948.jpg"

            string value2 = string.Format("{0}{1}", imagepath2, e.FirstImage);//  ("img1").Value);
            this.Image1.ImageUrl = value2;
            this.ImageMap1.ImageUrl = value2;
        }

        var path = gr.RetrieveShortestPath(gr.FindVertexByID("j113"), gr.FindVertexByID("j118"));

        string myVal = "";

        foreach (Vertex v in path)
        {
            
            //string imagepath = @"/App_Data/Images/";
            string imagepath2 = @"~/App_Data/Images/";
            //ImageUrl="~/App_Data/Images/IMG_1948.jpg"

            string value2 = string.Format("{0}{1}", imagepath2, v.Attribute("img1").Value);
            //this.Image1.ImageUrl = value2;
            this.ImageMap1.ImageUrl = value2;
        }


                foreach (var ed in edges)
                {

                    
                }

                //this.verticies = glVerts;
                //this.edges = glEdges;
    }*/

        //protected void Image1_PreRender(object sender, EventArgs e)
        //{
          //  loadImage();
        //}
        
        //end of load image
        


    }
}