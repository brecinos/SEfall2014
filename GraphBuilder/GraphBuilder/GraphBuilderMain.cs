using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GraphBuilder
{

    public partial class MainFrm : Form
    {
        private Bitmap buffer;
        private List<GraphVertex> verticies = new List<GraphVertex>();
        private List<GraphEdge> edges = new List<GraphEdge>();
        private string initialImgDir;

        public MainFrm()
        {
            InitializeComponent();
            panel1_Resize(this, null);
        }

        public void RefreshVerticies(ComboBox cb)
        {
            object o = cb.SelectedItem;
            cb.Items.Clear();
            cb.Items.AddRange(verticies.ToArray());
            cb.SelectedItem = o;
        }

        public void RefreshEdges(ComboBox cb)
        {
            object o = cb.SelectedItem;
            cb.Items.Clear();
            cb.Items.AddRange(edges.ToArray());
            cb.SelectedItem = o;
        }


        public void RefreshVerticies(ListBox cb)
        {
            object o = cb.SelectedItem;
            cb.Items.Clear();
            cb.Items.AddRange(verticies.ToArray());
            cb.SelectedItem = o;
        }

        public void RefreshEdges(ListBox cb)
        {
            object o = cb.SelectedItem;
            cb.Items.Clear();
            cb.Items.AddRange(edges.ToArray());
            cb.SelectedItem = o;
        }

        public void RefreshAllVerticies()
        {
            RefreshVerticies(cbEdgeVertex1);
            RefreshVerticies(cbEdgeVertex2);
            RefreshVerticies(cbParent);
            RefreshVerticies(lbVerticies);
        }

        public void RefreshAllEdges()
        {
            RefreshEdges(lbEdges);
        }


        private GraphVertex AddVertex(string name, string floor, string parent,string direction, string length, string type)
        {
            var v = new GraphVertex();
            v.Name = name;
            v.Floor = floor;
            v.Parent = parent;
            v.Direction = direction;
            v.Length = length;
            v.Type = type;

            verticies.Add(v);

            RefreshAllVerticies();

            return v;
        }

        private GraphVertex GetVertex(string name)
        {
            foreach (var v in verticies)
                if (v.Name == name)
                    return v;
            return null;
        }

        private GraphVertex AddVertex()
        {
            return AddVertex("New Vertex", cbFloor.Items[0].ToString(), "", cbDirection.Items[0].ToString(), "1.0", cbType.Items[0].ToString());
        }

        private GraphEdge AddEdge(string v1, string v2,string path1, string path2)
        {
            var e = new GraphEdge();
            e.Vert1 = v1;
            e.Vert2 = v2;
            e.Pic1 = path1;
            e.Pic2 = path2;
            edges.Add(e);

            RefreshAllEdges();

            return e;
        }
        private GraphEdge AddEdge()
        {
            if (verticies.Count < 2)
                return null;

            return AddEdge(verticies[0].ToString(),verticies[1].ToString(),"","");
        }

        private void GraphBuilderMain_Load(object sender, EventArgs e)
        {
            cbDirection.SelectedIndex = 0;
            cbFloor.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            cbMapFloor.SelectedIndex = 0;
            initialImgDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Images");
            openPic1.InitialDirectory = initialImgDir;
            openPic2.InitialDirectory = initialImgDir;
            openXml.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            saveXml.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        }

        private void btnNewVertex_Click(object sender, EventArgs e)
        {
            lbVerticies.SelectedItem = AddVertex();
        }

        private void btnUpdateVertex_Click(object sender, EventArgs e)
        {
            if(lbVerticies.SelectedIndex == -1)
                return;
           GraphVertex v = (GraphVertex)lbVerticies.SelectedItem;
           foreach (var edge in edges)
           {
               if (edge.Vert1 == v.Name && txtVertexName.Text.Length > 0)
               {
                   edge.Vert1 = txtVertexName.Text;
               }

               if (edge.Vert2 == v.Name && txtVertexName.Text.Length > 0)
               {
                   edge.Vert2 = txtVertexName.Text;
               }
           }

           foreach (var vert in verticies)
           {
               if (vert.Parent == v.Name && txtVertexName.Text.Length > 0)
               {
                   vert.Parent = txtVertexName.Text;
               }
           }

           v.Name = txtVertexName.Text;
           if (cbNullParent.Checked)
           {
               v.Parent = "";
           }
           else
           {
               v.Parent = cbParent.SelectedItem.ToString();
           }

           v.Floor = cbFloor.SelectedItem.ToString();
           v.Length = txtLength.Text;
           v.Direction = cbDirection.SelectedItem.ToString();
           v.Type = cbType.SelectedItem.ToString();

           RefreshAllVerticies();
           RefreshAllEdges();
        }

        private void lbVerticies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbVerticies.SelectedIndex >= 0)
            {
                GraphVertex v = (GraphVertex)lbVerticies.SelectedItem;

                txtVertexName.Text = v.Name;
                cbNullParent.Checked = v.Parent == "";
                if (v.Parent != "")
                    cbParent.SelectedIndex = cbParent.FindStringExact(v.Parent);

                cbDirection.SelectedIndex = cbDirection.FindStringExact(v.Direction);
                cbFloor.SelectedIndex = cbFloor.FindStringExact(v.Floor);
                txtLength.Text = v.Length;
                cbType.SelectedIndex = cbType.FindStringExact(v.Type);

                lbVertexEdges.Items.Clear();
                List<GraphEdge> vEdges = new List<GraphEdge>();
                foreach (var ed in edges)
                {
                    if (ed.Vert1 == v.Name || ed.Vert2 == v.Name)
                    {
                        vEdges.Add(ed);
                    }
                }

                foreach (var ed in vEdges)
                {
                    lbVertexEdges.Items.Add(ed);
                }
            }

        }

        private void cbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNullParent.Checked = false;
        }

        private void btnDeleteVertex_Click(object sender, EventArgs e)
        {
            if (lbVerticies.SelectedIndex != -1)
            {
                GraphVertex v = (GraphVertex)lbVerticies.SelectedItem;

                verticies.Remove(v);
                RefreshAllVerticies();
            }
        }

        private void btnLocateImg1_Click(object sender, EventArgs e)
        {
            var result = openPic1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string diff = openPic1.FileName.Replace(initialImgDir, "");
                lblImgPath1.Text = diff;
                edgeImg1.ImageLocation = initialImgDir + diff;
            }
        }

        private void btnLocateImg2_Click(object sender, EventArgs e)
        {
            var result = openPic2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string diff = openPic2.FileName.Replace(initialImgDir, "");
                lblImgPath2.Text = diff;
                edgeImg2.ImageLocation = initialImgDir + diff;
            }
        }

        private void btnUpdateEdge_Click(object sender, EventArgs e)
        {
            if (lbEdges.SelectedIndex == -1)
                return;
            GraphEdge v = (GraphEdge)lbEdges.SelectedItem;
            v.Vert1 = ((GraphVertex)(cbEdgeVertex1.SelectedItem)).Name;
            v.Vert2 = ((GraphVertex)(cbEdgeVertex2.SelectedItem)).Name;
            v.Pic1 = lblImgPath1.Text;
            v.Pic2 = lblImgPath2.Text;
            RefreshAllEdges();
        }

        private void btnNewEdge_Click(object sender, EventArgs e)
        {
            AddEdge();
        }

        private void lbEdges_SelectedIndexChanged(object sender, EventArgs evt)
        {
            if (lbEdges.SelectedIndex >= 0)
            {
                GraphEdge e = (GraphEdge)lbEdges.SelectedItem;

                cbEdgeVertex1.SelectedItem = GetVertex(e.Vert1);
                cbEdgeVertex2.SelectedItem = GetVertex(e.Vert2);
                lblImgPath1.Text = e.Pic1;
                lblImgPath2.Text = e.Pic2;

                if (lblImgPath1.Text.Length > 0)
                {
                    edgeImg1.ImageLocation = initialImgDir + lblImgPath1.Text;
                }
                else
                {
                    edgeImg1.ImageLocation = null;
                }

                if (lblImgPath2.Text.Length > 0)
                {
                    edgeImg2.ImageLocation = initialImgDir + lblImgPath2.Text;
                }
                else
                {
                    edgeImg2.ImageLocation = null;
                }
            }
        }

        private void btnDeleteEdge_Click(object sender, EventArgs e)
        {
            if (lbEdges.SelectedIndex != -1)
            {
                GraphEdge v = (GraphEdge)lbEdges.SelectedItem;

                edges.Remove(v);
                RefreshAllEdges();
            }
        }

        private void btnLoadXml_Click(object sender, EventArgs e)
        {
             XDocument doc;
            var result = openXml.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = openXml.FileName;


                string line = "";
                using (StreamReader sr = new StreamReader(path))
                {
                    line = sr.ReadToEnd();
                    doc = XDocument.Parse(line);
                }

                if (doc == null)
                    return;

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
                RefreshAllVerticies();
                RefreshAllEdges();
            }
        }

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            var result = saveXml.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("layout");
                xmlDoc.AppendChild(rootNode);

                XmlNode verticiesNode = xmlDoc.CreateElement("verticies");
                rootNode.AppendChild(verticiesNode);

                XmlNode edgesNode = xmlDoc.CreateElement("edges");
                rootNode.AppendChild(edgesNode);

                foreach (var v in verticies)
                {
                    XmlNode vertNode = xmlDoc.CreateElement("vertex");

                    XmlAttribute name = xmlDoc.CreateAttribute("name");
                    name.Value = v.Name;
                    vertNode.Attributes.Append(name);

                    XmlAttribute floor = xmlDoc.CreateAttribute("floor");
                    floor.Value = v.Floor;
                    vertNode.Attributes.Append(floor);

                    XmlAttribute parent = xmlDoc.CreateAttribute("parent");
                    parent.Value = v.Parent;
                    vertNode.Attributes.Append(parent);

                    XmlAttribute dir = xmlDoc.CreateAttribute("direction");
                    dir.Value = v.Direction;
                    vertNode.Attributes.Append(dir);

                    XmlAttribute len = xmlDoc.CreateAttribute("length");
                    len.Value = v.Length;
                    vertNode.Attributes.Append(len);

                    XmlAttribute type = xmlDoc.CreateAttribute("type");
                    type.Value = v.Type;
                    vertNode.Attributes.Append(type);

                    verticiesNode.AppendChild(vertNode);
                }

                foreach (var v in edges)
                {
                    XmlNode vertNode = xmlDoc.CreateElement("edge");

                    XmlAttribute v1 = xmlDoc.CreateAttribute("v1");
                    v1.Value = v.Vert1;
                    vertNode.Attributes.Append(v1);

                    XmlAttribute v2 = xmlDoc.CreateAttribute("v2");
                    v2.Value = v.Vert2;
                    vertNode.Attributes.Append(v2);

                    XmlAttribute img1 = xmlDoc.CreateAttribute("img1");
                    img1.Value = v.Pic1;
                    vertNode.Attributes.Append(img1);

                    XmlAttribute img2 = xmlDoc.CreateAttribute("img2");
                    img2.Value = v.Pic2;
                    vertNode.Attributes.Append(img2);

                    edgesNode.AppendChild(vertNode);
                }

                xmlDoc.Save(saveXml.FileName);
            }
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            PaintMapRectangle();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            // Resize the buffer, if it is growing
            if (buffer == null ||
                buffer.Width < pnlMap.Width ||
                buffer.Height < pnlMap.Height)
            {
                Bitmap newBuffer = new Bitmap(pnlMap.Width, pnlMap.Height);
                if (buffer != null)
                    using (Graphics bufferGrph = Graphics.FromImage(newBuffer))
                        bufferGrph.DrawImageUnscaled(buffer, Point.Empty);
                buffer = newBuffer;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the buffer into the panel
            e.Graphics.DrawImageUnscaled(buffer, Point.Empty);
        }


        private GraphLoaderPoint VectorFromAngle(double deg)
        {
            double deg2rad = deg * (Math.PI / 180.0);

            GraphLoaderPoint p = new GraphLoaderPoint();
            p.X = Math.Sin(deg2rad);
            p.Y = Math.Cos(deg2rad);

            return p;
        }
        private GraphLoaderPoint GetRelativePosition(GraphVertex v)
        {
            GraphLoaderPoint location = new GraphLoaderPoint();

            GraphLoaderPoint dirVec = new GraphLoaderPoint();

            switch (v.Direction.ToLower())
            {
                case "n":
                    dirVec = VectorFromAngle(0);
                    break;
                case "nw":
                    dirVec = VectorFromAngle(45);
                    break;
                case "w":
                    dirVec = VectorFromAngle(90);
                    break;
                case "sw":
                    dirVec = VectorFromAngle(135);
                    break;
                case "s":
                    dirVec = VectorFromAngle(180);
                    break;
                case "se":
                    dirVec = VectorFromAngle(225);
                    break;
                case "e":
                    dirVec = VectorFromAngle(270);
                    break;
                case "ne":
                    dirVec = VectorFromAngle(315);
                    break;
                default:
                    break;

            }

            location.X = dirVec.X * Double.Parse(v.Length);
            location.Y = dirVec.Y * Double.Parse(v.Length);

            return location;
        }

        private GraphVertex GetGraphVertex(string name)
        {
            foreach (GraphVertex v in verticies)
            {
                if (v.Name.Equals(name))
                {
                    return v;
                }
            }

            return null;
        }

        private GraphLoaderPoint GetAbsPosition(GraphVertex v)
        {
            GraphLoaderPoint absLocation = GetRelativePosition(v);

            if (GetVertex(v.Parent) == null)
            {
                return absLocation;
            }
            GraphVertex parent = v;

            while (GetVertex(parent.Parent) != null)
            {
                parent = GetVertex(parent.Parent);

                GraphLoaderPoint parentPos = GetRelativePosition(parent);

                absLocation.X += parentPos.X;
                absLocation.Y += parentPos.Y;
            }

            return absLocation;
        }


        
        private void PaintMapRectangle()
        {
            // Draw blue rectangle into the buffer
            using (Graphics bufferGrph = Graphics.FromImage(buffer))
            {
                bufferGrph.FillRectangle(new SolidBrush(Color.White), 0,0,buffer.Width,buffer.Height);
                bufferGrph.TranslateTransform(buffer.Width / 2, buffer.Height / 2);

                float mul = 50.0f;

                foreach (var edge in edges)
                {
                    var v1 = GetVertex(edge.Vert1);
                    var v2 = GetVertex(edge.Vert2);

                    if (v1 == null || v2 == null)
                    {
                        continue;
                    }

                    if (v1.Floor == cbMapFloor.SelectedItem.ToString() || v2.Floor == cbMapFloor.SelectedItem.ToString())
                    {
                        var posV1 = GetAbsPosition(v1);
                        var posV2 = GetAbsPosition(v2);

                        bufferGrph.DrawLine(new Pen(Color.Black,2.0f), (int)(posV1.X * mul), (int)(-posV1.Y * mul), (int)(posV2.X * mul), (int)(-posV2.Y * mul));
                        bufferGrph.DrawString(v1.Name, new Font("arial", 6), new SolidBrush(Color.Red), new PointF((float)posV1.X * mul, (float)-posV1.Y * mul));
                        bufferGrph.DrawString(v2.Name, new Font("arial", 6), new SolidBrush(Color.Red), new PointF((float)posV2.X * mul, (float)-posV2.Y * mul));
                    }
                }
            }

            // Invalidate the panel. This will lead to a call of 'panel1_Paint'
            pnlMap.Invalidate();
        }

        private void cbMapFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaintMapRectangle();
        }

 }

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

   class GraphLoaderPoint
   {
       public GraphLoaderPoint()
       {
       }

       public double X
       { get; set; }

       public double Y
       { get; set; }
   }

}
