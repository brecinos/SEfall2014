using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            gr.AddVertex(new Vertex(0, 0, 0, "v1"));
            gr.AddVertex(new Vertex(5, 0, 0, "v2"));
            gr.AddVertex(new Vertex(5, 10, 0, "v3"));
            gr.AddVertex(new Vertex(0, 10, 0, "v4"));

            gr.AddVertex(new Vertex(0, 0, 10, "v5"));
            gr.AddVertex(new Vertex(5, 0, 10, "v6"));
            gr.AddVertex(new Vertex(5, 10, 10, "v7"));
            gr.AddVertex(new Vertex(0, 10, 10, "v8"));

            gr.AddEdge("v1", "v2");
            gr.AddEdge("v2", "v3");
            gr.AddEdge("v3", "v4");
            gr.AddEdge("v4", "v1");

            gr.AddEdge("v5", "v6");
            gr.AddEdge("v6", "v7");
            gr.AddEdge("v7", "v8");
            gr.AddEdge("v8", "v5");

            gr.AddEdge("v1", "v5");
            gr.AddEdge("v2", "v6");
            gr.AddEdge("v3", "v7");
            gr.AddEdge("v4", "v8");

            var path = gr.RetrieveShortestPath(gr.FindVertexByID("v1"), gr.FindVertexByID("v7"));

            string myVal ="";

            foreach (Vertex v in path)
            {
                  myVal += v.ToString() + ",";
            }

            this.Label1.Text = myVal;
        
        }

    }
}