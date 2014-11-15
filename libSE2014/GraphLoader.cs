using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PathGraph;

namespace libSE2014
{
    /// <summary>
    /// Vertex Attributes obtained from XML
    /// </summary>
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

    /// <summary>
    /// Edge Attributes obtained from XML
    /// </summary>
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


    /// <summary>
    /// Used to solve for the Vertex location
    /// </summary>
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

    /// <summary>
    ///Loads Verticies and Edges from XML
    /// </summary>
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

        /// <summary>
        /// Takes an angle from 0 to 360 and returns a Unit Vector
        /// in the directuon of deg
        /// </summary>
        private GraphLoaderPoint VectorFromAngle(double deg)
        {
            double deg2rad = deg * (Math.PI / 180.0);

            GraphLoaderPoint p = new GraphLoaderPoint();
            p.X = Math.Sin(deg2rad);
            p.Y = Math.Cos(deg2rad);

            return p;
        }

        /// <summary>
        /// Takes a Vertex from XML and returns its relative position
        /// as a vector whose length is the Vertex length and direction is based on n = north etc
        /// </summary>
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

        /// <summary>
        /// O(n) iterates the verticies from XML to try to find a vertex by its name
        /// returns null on failure
        /// </summary>
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

        /// <summary>
        /// O(n) iterates the graph verticies to try to find a vertex by its name
        /// returns null on failure
        /// </summary>
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

        /// <summary>
        /// Obtains the absolute position of a vertex
        /// </summary>
        private GraphLoaderPoint GetAbsPosition(GraphLoaderVertex v, List<GraphLoaderVertex> verts)
        {
            GraphLoaderPoint absLocation = GetRelativePosition(v);

            if (GetGraphVertex(verts, v.Parent) == null)
            {
                return absLocation;
            }
           GraphLoaderVertex parent = v;

            //find position by recursivly adding parent relative positions until the root node is reached
            while (GetGraphVertex(verts,parent.Parent) != null)
            {
                parent = GetGraphVertex(verts, parent.Parent);

                GraphLoaderPoint parentPos = GetRelativePosition(parent);

                //add the parent's relative position
                //the absolute position is a vertex's relative position + the sum of the parent positions until root (0,0)
                absLocation.X += parentPos.X;
                absLocation.Y += parentPos.Y;
            }

            return absLocation;
        }

        /// <summary>
        /// Takes in the XML verticies and edges, gets absolute positions
        /// from this, the graph verticies and edges are generated and stored
        /// returns true on success
        /// </summary>
        private bool generateVertsAndEdges(List<GraphLoaderVertex> verts, List<GraphLoaderEdge> edges)
        {
            _listOfNodes.Clear();
            _listOfEdges.Clear();

            //find the vertex's absolute position, set the type, and add it
            foreach (var vert in verts)
            {
                GraphLoaderPoint p = GetAbsPosition(vert,verts);

                Vertex v = new Vertex((float)p.X, (float)p.Y, (float)vert.Floor, vert.Name);
                v.Type = vert.Type;

                _listOfNodes.Add(v);
            }

            //associate the verticies, and the front/back image locations
            //then add the edge with a cost of the 2D distance between the 2 verticies
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

        /// <summary>
        /// Loads the graph edges and verticies from XML
        /// Fills the Edge and Vertex arrays
        /// </summary>
        public bool load(string pathxml)
        {
            string line = ""; 

            //read the entire document in and parse it
            using (StreamReader sr = new StreamReader(pathxml))
            {
                line = sr.ReadToEnd();
                doc = XDocument.Parse(line);
            }

            if (doc == null)
                return false;

            //first, go into the root layout element
            IEnumerable<XElement> elems =
            doc.Element("layout").Elements();

            //access the verticies element
            IEnumerable<XElement> verts =
                elems.Where( o => o.Name == "verticies").Elements();

            //access the edges element
            IEnumerable<XElement> edges =
            elems.Where(o => o.Name == "edges").Elements();

            List<GraphLoaderVertex> glVerts = new List<GraphLoaderVertex>();
            List<GraphLoaderEdge> glEdges = new List<GraphLoaderEdge>();

            //parse each attribute and make objects
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

            //parse each attribute and make objects
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
