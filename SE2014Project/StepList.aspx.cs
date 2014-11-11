using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Hosting;
using libSE2014;
using PathGraph;
using System.Web.UI.WebControls;

namespace SE2014Project
{
    public partial class StepList : System.Web.UI.Page
    {

        public class ShowRooms {
            public int Step_number { get; set; }
            public string Description { get; set; }
            public string Turn { get; set; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
                ShowData();
        

        }

        protected void ShowData()
        {
            //this.Label1.Visible = true;

            Graph gr = new Graph();

            GraphLoader gl = new GraphLoader();
            String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
            bool success = gl.load(file);

            var vtx = gl.GetVerticies();
            var edges = gl.GetEdges();

            var initialroom = Session["initialRoom"].ToString();
            var finalroom = Session["finalRoom"].ToString();  


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

            //creating the step list for the grid
            List<ShowRooms> graphStepList = new List<ShowRooms>();
            var countStep = 0;
            foreach (var g in assemPath)
            {
                countStep = countStep + 1;
                ShowRooms sr = new ShowRooms { Step_number = countStep,  Description = g.Vertex.VertexID, Turn = g.DirectionString };
                graphStepList.Add(sr);
            }
           
            GridView1.DataSource = graphStepList;
            GridView1.DataBind();

        }

    }
}