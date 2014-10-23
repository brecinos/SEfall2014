using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Xml.Linq;
using System.Web.Hosting;
using libSE2014;
using PathGraph;

namespace SE2014Project
{
    public partial class MapCreator : System.Web.UI.Page
    {
        /*
        private List<GraphVertex> verticies = new List<GraphVertex>();
        private List<GraphEdge> edges = new List<GraphEdge>();

        public class GraphVertex
    {
        public GraphVertex()
        {
        }

        public string Name
        { get; set; }

        public string Floor
        { get; set; }

        public string Parent
        { get; set; }

        public string Direction
        { get; set; }

        public string Length
        { get; set; }

        public string Type
        { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

        public  class GraphEdge
    {
        public GraphEdge()
        {
        }

        public string Vert1
        { get; set; }

        public string Vert2
        { get; set; }

        public string Pic1
        { get; set; }

        public string Pic2
        { get; set; }

        public override string ToString()
        {
            return Vert1 + " <=> " + Vert2;
        }
    } */

        public void drawSomething()
        {

            
           /* objGraphics.Dispose();
            objBitmap.Dispose();
            Response.End();  */

            Response.Clear();
            int height = 400;
            int width = 600;
            Random r = new Random();
            int x = r.Next(75);

            //creating the bitmap
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            //g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //adding the solidbrush
            SolidBrush solidWhiteBrush = new SolidBrush(Color.White);

            //fillRectangle
            g.FillRectangle(solidWhiteBrush, 0, 0, 600, 400);

            //fillElipse
           // g.FillEllipse(new LinearGradientBrush(new Rectangle(0, 100, 50, 50),
           // Color.Plum, Color.Red, 20), 0, 100, 50, 50);

            //drawing objects

            g.DrawLine(new Pen(Color.Black), 50, 125, 100, 125);
            g.DrawString("J-9", new Font("Arial", 12, FontStyle.Italic),SystemBrushes.WindowText, new PointF(x, 50));
            g.DrawLine(new Pen(Color.Yellow), 55, 130, 110, 130);
            g.DrawString("J-110", new Font("Arial", 12, FontStyle.Italic), SystemBrushes.WindowText, new PointF(x + 5, 130));
            g.DrawLine(new Pen(Color.Red), 160, 40, 30, 140);
            g.DrawString("Stairs", new Font("Arial", 12, FontStyle.Italic), SystemBrushes.WindowText, new PointF(x + 10, 140));
            g.DrawLine(new Pen(Color.BlueViolet), 150, 225, 200, 225);
            g.DrawString("Level 1 Johnson", new Font("Arial", 12, FontStyle.Italic), SystemBrushes.WindowText, new PointF(x + 15, 225));
            //g.DrawBezier(new Pen(Color.Red), 100, 70, 200, 80, 70, 250, 200, 200); // this actually displays the line
            //g.DrawBezier(new Pen(Color.Red), 100, 70, 200, 80, 70, 250, 200, 200); // this actually displays the line


            Response.ContentType = "image/gif";
            bmp.Save(Response.OutputStream, ImageFormat.Gif);
        
        }


        public void DrawSomethingBR(int begin, int end) {

            // reading the xml section
            //declaring variables

            Graph gr = new Graph();

            GraphLoader gl = new GraphLoader();
            String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
            bool success = gl.load(file);

            var vtx = gl.GetVerticies();
            var edges = gl.GetEdges();



            //String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
            //XDocument doc = XDocument.Load(file);
            if (success==true)
            {

                // 
                var myOutputValue = "";


           
                foreach (var v in vtx)
                {
                    gr.AddVertex(v);
                }

                foreach (var e in edges)
                {
                    gr.AddEdge(e);
                }

                var path = gr.RetrieveShortestPath(gr.FindVertexByID("j113"), gr.FindVertexByID("j118"));


                // drawing section
                Response.Clear();
                int height = 400;
                int width = 600;
                Random r = new Random();
                int x = r.Next(75);

                //creating the bitmap
                Bitmap bmp = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bmp);

                //g.TextRenderingHint = TextRenderingHint.AntiAlias;

                //adding the solidbrush
                SolidBrush solidWhiteBrush = new SolidBrush(Color.White);

                //fillRectangle
                g.FillRectangle(solidWhiteBrush, 0, 0, 600, 400);

                //fillElipse
                // g.FillEllipse(new LinearGradientBrush(new Rectangle(0, 100, 50, 50),
                // Color.Plum, Color.Red, 20), 0, 100, 50, 50);

                //drawing objects

                foreach (Vertex v in path)
                {
                    var Room = v.VertexID.ToString();
                    var TypeRoom = v.Type.ToString();
                    g.DrawLine(new Pen(Color.Black), 50, 125, 100, 125);
                    //g.DrawLine(new Pen(Color.Black), 50, 125, 100, 125);
                    g.DrawString(Room+" " +TypeRoom, new Font("Arial", 12, FontStyle.Italic), SystemBrushes.WindowText, new PointF(x, 50));
                   // g.DrawLine(new Pen(Color.Yellow), 55, 130, 110, 130);
                   // g.DrawString("J-110", new Font("Arial", 12, FontStyle.Italic), SystemBrushes.WindowText, new PointF(x + 5, 130));
                }

                string value1 = myOutputValue + " " + ",";
                
            }
            else {

                var myError = "no xml file";
                string value2 = myError;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             drawSomething();
            //ReadXmlFile();
        }


        


       
        }
}