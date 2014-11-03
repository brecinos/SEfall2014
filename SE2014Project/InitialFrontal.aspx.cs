using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using libSE2014;
using PathGraph;


namespace SE2014Project
{
    public partial class InitialFrontal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ShowData();
            }
        }

        protected void ShowData() {


             Graph   gr = new Graph();

             GraphLoader gl = new GraphLoader();
             String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
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
             }

            var path = gr.RetrieveShortestPath(gr.FindVertexByID("J103"), gr.FindVertexByID("J116"));

            var assembler = new GraphPathAssembler(path, edges, @"\Images");
            var assemPath = assembler.GenerateOptimizedPath();

            string myVal ="";

            foreach (var g in assemPath)
            {
                  myVal += "From where you are standing, Go " +   g.DirectionString + " and you will see: <br></br><img src=\"" + g.ImagePath + "\"> <br></br>";
                  if (g == assemPath.Last())
                  {
                      myVal += "You have reached " + g.DestinationVertex.VertexID;
                  }
            }



            this.Literal1.Text = myVal;
        
        }

    }
}