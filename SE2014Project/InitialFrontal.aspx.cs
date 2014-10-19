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

            var path = gr.RetrieveShortestPath(gr.FindVertexByID("j113"), gr.FindVertexByID("j118"));

            string myVal ="";

            foreach (Vertex v in path)
            {
                  myVal += v.ToString() + ",";
            }

            this.Label1.Text = myVal;
        
        }

    }
}