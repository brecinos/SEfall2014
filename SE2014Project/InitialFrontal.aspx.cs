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
                         myVal += "You have reached " + g.DestinationVertex.VertexID + " look at the graph to the path: <br></br><a href= \"" + "Imageviewer.aspx" + "\"><strong> Map Image</strong></a> <br></br>";
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
            if (validate_Input() != false)
            {
                LabelErrorInput.Text = "";
                SetStartAndEnd();
                ShowData();
                LabelErrorInput.Visible = false;
            }
            else
            {
                LabelErrorInput.Visible = true;
                LabelErrorInput.Text = "Type again your rooms(j9,valid). Not a valid entry format.";
            }
        }

        protected void ButtonStepList_Click(object sender, EventArgs e)
        {

            Response.Redirect("StepList.aspx");
        }


        /// <summary>
        /// validate input to ensure the format is letters with numbers
        /// </summary>
        private bool validate_Input()
        {
            bool returnOk = false;
            var val1 = TextBox1.Text;
            var val2 = TextBox2.Text;
            bool valueNumeric = System.Text.RegularExpressions.Regex.IsMatch(val1, @"\d");
            bool valueNumeric2 = System.Text.RegularExpressions.Regex.IsMatch(val1, @"\d");

            if (valueNumeric != false && valueNumeric2 !=false) {

                LabelErrorInput.Text = "";
                returnOk = true;
            }

            return returnOk;

        }

      
      
     

       

    }
}