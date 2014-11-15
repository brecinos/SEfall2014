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


        public string initialRoom { get; set; }
        public string finalRoom { get; set; }

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

             Graph   gr = AppContext.Instance.getGraph();

             var path = gr.RetrieveShortestPath(gr.FindVertexByID(AppContext.Instance.InitialRoom), gr.FindVertexByID(AppContext.Instance.DestinationRoom));

             if (path != null && path.Count >= 2)
             {
                 OnPathFound();

                 var assembler = new GraphPathAssembler(path, gr.Edges, @"\Images");
                 var assemPath = assembler.GenerateOptimizedPath();

                 string myVal = "";

                 foreach (var g in assemPath)
                 {
                     myVal += "From where you are standing, Go " + g.DirectionString + " and you will see: <br></br><img src=\"" + g.ImagePath + "\"> <br></br>";
                     if (g == assemPath.Last())
                     {
                         myVal += "You have reached " + g.DestinationVertex.VertexID + " look at the graph to the path: <br></br><a href= \"" + "Imageviewer.aspx" + "\"> Map Image</a> <br></br>";
                     }
                 }

                 this.OutputLiteral.Text = myVal;
             }
             else if (path != null)
             {
                 this.OutputLiteral.Text = "<h2>Turn around... you made it!</h2>";
             }
             else
             {
                 this.OutputLiteral.Text = "<h2>We're not sure where that is. Try somewhere else.</h2>";
             }
        
        }

        protected void SetStartAndEnd()
        {
            var initialroom = this.TextBox1.Text.Trim();
            var finalroom = this.TextBox2.Text.Trim();

            AppContext.Instance.InitialRoom = initialroom;
            AppContext.Instance.DestinationRoom = finalroom; 
        }

        protected void OnPathFound()
        {
            this.ButtonStepList.Visible = true;  
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {

                SetStartAndEnd();
                ShowData();          
        }

        protected void ButtonStepList_Click(object sender, EventArgs e)
        {

            Response.Redirect("StepList.aspx");
        }

    }
}