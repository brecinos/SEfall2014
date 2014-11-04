using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using libSE2014;
using PathGraph;
using System.Collections;


namespace SE2014Project
{
    public partial class InitialFrontal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.Label1.Visible = false;
                //fillDropDowns();
                //ShowData();
            }
        }


       

        protected void ShowData() {
            this.Label1.Visible = true;

             Graph   gr = new Graph();

             GraphLoader gl = new GraphLoader();
             String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
             bool success = gl.load(file);

             var vtx = gl.GetVerticies();
             var edges = gl.GetEdges();

             var initialroom = this.TextBox1.Text.Trim(); 
             var finalroom = this.TextBox2.Text.Trim();



             foreach (var v in vtx)
             {
                 gr.AddVertex(v);
             }

             foreach (var e in edges)
             {
                 gr.AddEdge(e);
             }

             var path = gr.RetrieveShortestPath(gr.FindVertexByID(initialroom), gr.FindVertexByID(finalroom));
            

            var assembler = new GraphPathAssembler(path, edges, @"\Images");
            var assemPath = assembler.GenerateOptimizedPath();

            string myVal ="";

            foreach (var g in assemPath)
            {
                  myVal += "From where you are standing, Go " +   g.DirectionString + " and you will see: <br></br><img src=\"" + g.ImagePath + "\"> <br></br>";
                  if (g == assemPath.Last())
                  {
                      myVal += "You have reached " + g.DestinationVertex.VertexID + " look at the graph to the path: <br></br><a href= \"" + "Imageviewer.aspx" + "\"> Map Image</a> <br></br>";
                  }
            }



            this.Literal1.Text = myVal;
        
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                ShowData();
            }
            else {

                this.Literal1.Text = "no valid names for rooms";
            }
            

        }

    }
}