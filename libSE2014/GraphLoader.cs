using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PathGraph;

namespace libSE2014
{
    class GraphLoaderVertex
    {
        public GraphLoaderVertex()
        {
        }

        public string Name
        { get; set; }

        public double Floor
        { get; set; }

        public string Parent
        { get; set; }

        public string Direction
        { get; set; }

        public double Length
        { get; set; }

        public string Type
        { get; set; }
    }

    class GraphLoaderEdge
    {
        public GraphLoaderEdge()
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


    public class GraphLoader
    {
        private List<Vertex> _listOfNodes;
        private List<Edge> _listOfEdges;
        private XDocument doc;

        public GraphLoader()
        {
            _listOfEdges = new List<Edge>();
            _listOfNodes = new List<Vertex>();
        }

        private GraphLoaderPoint VectorFromAngle(double deg)
        {
            double deg2rad = (Math.PI / 180.0);

            GraphLoaderPoint p = new GraphLoaderPoint();
            p.X = Math.Sin(deg2rad);
            p.Y = Math.Cos(deg2rad);

            return p;
        }
        private GraphLoaderPoint GetRelativePosition(GraphLoaderVertex v)
        {
            GraphLoaderPoint location = new GraphLoaderPoint();

            GraphLoaderPoint dirVec = new GraphLoaderPoint();

            switch(v.Direction.ToLower())
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

            location.X = dirVec.X * v.Length;
            location.Y = dirVec.Y * v.Length;

            return location;
        }

        private GraphLoaderVertex GetGraphVertex(List<GraphLoaderVertex> verts, string name)
        {
            foreach (GraphLoaderVertex v in verts)
            {
                if (v.Name.Equals(name))
                {
                    return v;
                }
            }

            return null;
        }

        private Vertex GetVertex(string name)
        {
            foreach (Vertex v in _listOfNodes)
            {
                if (v.VertexID.Equals(name))
                {
                    return v;
                }
            }

            return null;
        }

        private GraphLoaderPoint GetAbsPosition(GraphLoaderVertex v, List<GraphLoaderVertex> verts)
        {
            GraphLoaderPoint absLocation = GetRelativePosition(v);

            if (GetGraphVertex(verts, v.Parent) == null)
            {
                return absLocation;
            }
           GraphLoaderVertex parent = v;

            while (GetGraphVertex(verts,parent.Parent) != null)
            {
                parent = GetGraphVertex(verts, parent.Parent);

                GraphLoaderPoint parentPos = GetRelativePosition(parent);

                absLocation.X += parentPos.X;
                absLocation.Y += parentPos.Y;
            }

            return absLocation;
        }

        private bool generateVertsAndEdges(List<GraphLoaderVertex> verts, List<GraphLoaderEdge> edges)
        {
            _listOfNodes.Clear();
            _listOfEdges.Clear();

            foreach (var vert in verts)
            {
                GraphLoaderPoint p = GetAbsPosition(vert,verts);

                Vertex v = new Vertex((float)p.X, (float)p.Y, (float)vert.Floor, vert.Name);
                v.Type = vert.Type;

                _listOfNodes.Add(v);
            }

            foreach (var edge in edges)
            {
                Vertex v1 = GetVertex(edge.Vert1);
                Vertex v2 = GetVertex(edge.Vert2);
                string pic1 = edge.Pic1;
                string pic2 = edge.Pic2;

                Edge e = new Edge(v1, v2, v1.distance(v2), pic1, pic2);

                _listOfEdges.Add(e);
            }

            return true;
        }

        public bool load(string pathxml)
        {
            string line = "";
            using (StreamReader sr = new StreamReader(pathxml))
            {
                line = sr.ReadToEnd();
                doc = XDocument.Parse(line);
            }

            if (doc == null)
                return false;

            IEnumerable<XElement> elems =
            doc.Element("layout").Elements();

            IEnumerable<XElement> verts =
                elems.Where( o => o.Name == "verticies").Elements();

            IEnumerable<XElement> edges =
            elems.Where(o => o.Name == "edges").Elements();

            List<GraphLoaderVertex> glVerts = new List<GraphLoaderVertex>();
            List<GraphLoaderEdge> glEdges = new List<GraphLoaderEdge>();

            foreach (var v in verts)
            {
                GraphLoaderVertex vtx = new GraphLoaderVertex();
                vtx.Name = v.Attribute("name").Value;
                vtx.Floor = Double.Parse(v.Attribute("floor").Value);
                vtx.Parent = v.Attribute("parent").Value;
                vtx.Direction = v.Attribute("direction").Value;
                vtx.Length = Double.Parse(v.Attribute("length").Value);
                vtx.Type = v.Attribute("type").Value;

                glVerts.Add(vtx);
            }

            foreach (var e in edges)
            {
                GraphLoaderEdge edge = new GraphLoaderEdge();
                edge.Vert1 = e.Attribute("v1").Value;
                edge.Vert2 = e.Attribute("v2").Value;
                edge.Pic1 = e.Attribute("img1").Value;
                edge.Pic2 = e.Attribute("img2").Value;
                glEdges.Add(edge);
            }

            return generateVertsAndEdges(glVerts, glEdges);
        }

        public List<Edge> GetEdges()
        {
            return _listOfEdges;
        }

        public List<Vertex> GetVerticies()
        {
            return _listOfNodes;
        }
    }
}
