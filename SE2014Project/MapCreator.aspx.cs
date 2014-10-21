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

namespace SE2014Project
{
    public partial class MapCreator : System.Web.UI.Page
    {
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
    } 

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


        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             drawSomething();
            //ReadXmlFile();
        }


        


        public void ReadXmlFile()
        {

            //declaring variables
            String file = HostingEnvironment.MapPath(@"/App_Data/bishops.xml");
            XDocument doc = XDocument.Load(file);
            if (doc != null)
            {

                // 
                var myOutputValue = "";


                //var rooms = doc.Root.Elements().Select(x => x.Element("verticies"));
                //var rooms = doc.Root.Element(.Select(x => x.Element("verticies"));

                /*here to construct the xml*/
                IEnumerable<XElement> elems =
                    doc.Element("layout").Elements();

                IEnumerable<XElement> verts =
                    elems.Where(o => o.Name == "verticies").Elements();

                IEnumerable<XElement> edges =
                elems.Where(o => o.Name == "edges").Elements();

                List<GraphVertex> glVerts = new List<GraphVertex>();
                List<GraphEdge> glEdges = new List<GraphEdge>();

                foreach (var v in verts)
                {
                    GraphVertex vtx = new GraphVertex();
                    vtx.Name = v.Attribute("name").Value;
                    vtx.Floor = v.Attribute("floor").Value;
                    vtx.Parent = v.Attribute("parent").Value;
                    vtx.Direction = v.Attribute("direction").Value;
                    vtx.Length = v.Attribute("length").Value;
                    vtx.Type = v.Attribute("type").Value;

                    glVerts.Add(vtx);
                }

                foreach (var ed in edges)
                {
                    GraphEdge edge = new GraphEdge();
                    edge.Vert1 = ed.Attribute("v1").Value;
                    edge.Vert2 = ed.Attribute("v2").Value;
                    edge.Pic1 = ed.Attribute("img1").Value;
                    edge.Pic2 = ed.Attribute("img2").Value;
                    glEdges.Add(edge);
                }

                this.verticies = glVerts;
                this.edges = glEdges;



                foreach (var v in verts)
                {
                    myOutputValue += v.Attribute("name").Value.ToString();
                }

                string value1 = myOutputValue + " " + ",";
                //Label1.Text = myOutputValue+" "+ ",";


            }
            else
            {
                var myError = "no xml file";
                string value2 = myError;
                //Label1.Text = myError;
            }

        }
        }
}