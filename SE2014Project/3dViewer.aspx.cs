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

        public int FirstIndex { get; set; }
        public int currentIndex { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            //set the image on the initial load
            if (!IsPostBack)
                ShowData(0);
        
        }

        protected void ShowData(int imageIndex)
        {
    
            Graph gr = AppContext.Instance.getGraph();

            var path = gr.RetrieveShortestPath(gr.FindVertexByID(AppContext.Instance.InitialRoom), gr.FindVertexByID(AppContext.Instance.DestinationRoom));

            if (path != null && path.Count >= 2)
            {
                
                var assembler = new GraphPathAssembler(path, gr.Edges, @"\Images");
                var assemPath = assembler.GenerateOptimizedPath();

                List<String> listImages = new List<String>();


                foreach (var g in assemPath)
                {
                    listImages.Add(g.ImagePath);

                   // solving the image Index inference
                    FirstIndex = imageIndex == 0 ? 0 : imageIndex;    
                }
                this.Image1.ImageUrl = listImages[imageIndex];
                currentIndex = imageIndex;
            }
            HiddenField1.Value = currentIndex.ToString();

        }


        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            var myValNow = int.Parse(HiddenField1.Value);
            var newIndex = myValNow >= 0 ? myValNow + 1 : 0;
            ShowData(newIndex);
        }

        protected void ButtonPrevious_Click(object sender, EventArgs e)
        {
            var myValNow = int.Parse(HiddenField1.Value);
            var newIndex = myValNow >= 1 ? myValNow - 1 : myValNow;
            ShowData(newIndex);
        }



    }
}