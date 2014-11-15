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

            Graph   gr = AppContext.Instance.getGraph();

             var path = gr.RetrieveShortestPath(gr.FindVertexByID(AppContext.Instance.InitialRoom), gr.FindVertexByID(AppContext.Instance.DestinationRoom));

             if (path != null)
             {
                 var assembler = new GraphPathAssembler(path, gr.Edges, @"\Images");
                 var assemPath = assembler.GenerateOptimizedPath();

                 //creating the step list for the grid
                 List<ShowRooms> graphStepList = new List<ShowRooms>();
                 var countStep = 0;
                 foreach (var g in assemPath)
                 {
                     countStep = countStep + 1;
                     ShowRooms sr = new ShowRooms { Step_number = countStep, Description = g.Vertex.VertexID, Turn = g.DirectionString };
                     graphStepList.Add(sr);
                 }

                 GridView1.DataSource = graphStepList;
                 GridView1.DataBind();
             }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
               if(e.Row.RowType == DataControlRowType.Header)
                    e.Row.Cells[0].Text = "#";
        }

    }
}