using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//test
namespace PathGraph
{

    public class Edge
    {

        private float _cost;
        private Vertex _pointA, _pointB;
        private static int EdgeIDSequencer = 0;
        private int _edgeID;
        private string _firstImage;
        private string _secondImage;


        #region Properties

        public int EdgeID
        {
            get
            {
                return _edgeID;
            }
        }

        public string FirstImage
        {
            get
            {
                return _firstImage;
            }
        }

        public string SecondImage
        {
            get
            {
                return _secondImage;
            }
        }


        public float Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        public Vertex PointA
        {
            get
            {
                return _pointA;
            }
        }

        public Vertex PointB
        {
            get
            {
                return _pointB;
            }
        }

        #endregion

        public Edge(Vertex firstPoint, Vertex secondPoint, float cost, string firstImage, string secondImage)
        {
            _cost = cost;
            _pointA = firstPoint; _pointB = secondPoint;
            _edgeID = ++EdgeIDSequencer;
            _firstImage = firstImage;
            _secondImage = secondImage;
        }

        public Vertex GetTheOtherVertex(Vertex baseVertex)
        {
            if (baseVertex == _pointA)
            {
                return _pointB;
            }
            else if (baseVertex == _pointB)
            {
                return _pointA;
            }
            else
            {
                // somehow the base vertex doesn't equal to either point A or B
                return null;
            }
        }

        public override string ToString()
        {
            return "Edge ID: " + _edgeID.ToString()
                + "; Connected to vertices " + _pointA.VertexID + " and "
                + _pointB.VertexID + " at a cost of " + _cost;
        }
    }

   public class Vertex
    {
        public const int INFINITY = -1;
        private float _xCoord, _yCoord, _zCoord;
        private bool _visited;
        private String _vertexID;
        private float _aggregateCost;
        private Edge _edgeWithLowestCost;


        #region Properties

        public String VertexID
        {
            get
            {
                return _vertexID;
            }
        }

        public float AggregateCost
        {
            get
            {
                return _aggregateCost;
            }
            set
            {
                _aggregateCost = value;
            }
        }

        public float XCoord
        {
            get
            {
                return _xCoord;
            }
            set
            {
                _xCoord = value;
            }
        }

        public float YCoord
        {
            get
            {
                return _yCoord;
            }
            set
            {
                _yCoord = value;
            }
        }

        public float ZCoord
        {
            get
            {
                return _zCoord;
            }
            set
            {
                _zCoord = value;
            }
        }

        public bool Visited
        {
            get
            {
                return _visited;
            }
            set
            {
                _visited = value;
            }
        }

        // Internal members
        internal Edge EdgeWithLowestCost
        {
            get
            {
                return _edgeWithLowestCost;
            }
            set
            {
                _edgeWithLowestCost = value;
            }
        }

        #endregion

        public Vertex(float x, float y, float z, String id)
        {
            _visited = false;
            _xCoord = x;
            _yCoord = y;
            _zCoord = z;
            _aggregateCost = INFINITY;
            _vertexID = id;
            _edgeWithLowestCost = null;
        }

        public float distance(Vertex v2)
        {
            float deltaX = v2.XCoord - XCoord;
            float deltaY = v2.YCoord - YCoord;
            float deltaZ = v2.ZCoord - ZCoord;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }


        public double distance2D(Vertex v2)
        {
            double deltaX = v2.XCoord - XCoord;
            double deltaY = v2.YCoord - YCoord;

            return (double)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public string Type
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "Vertex ID: " + _vertexID; // + "; Coords: X=" + _xCoord + ", Y=" + _yCoord;
        }

    }

    public class Graph
    {
        private Vertex _sourceNode;
        private List<Vertex> _listOfNodes;
        private List<Edge> _listOfEdges;

        #region Properties

        public List<Vertex> AllNodes
        {
            get { return _listOfNodes; }
        }

        // Read-Write properties
        public Vertex SourceVertex
        {
            get
            {
                return _sourceNode;
            }
            set
            {
                // SourceVertex is only valid if it is found in the graph.
                // Do not make any changes otherwise.
                for (int i = 0; i < _listOfNodes.Count; i++)
                {
                    if (_listOfNodes[i] == value)
                    {
                        _sourceNode = value;
                        break;
                    }
                }
            }
        }

        #endregion

        public Graph()
        {
            _listOfEdges = new List<Edge>();
            _listOfNodes = new List<Vertex>();

            _sourceNode = null; //_targetNode = null;
        }

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Edge edge)
        {
            _listOfEdges.Add(edge);

            // Reset stats due to a change to the graph.
            this.Reset();
        }

        /// <summary>
        /// Adds a vertex to the graph.
        /// </summary>
        /// <param name="node"></param>
        public void AddVertex(Vertex node)
        {
            _listOfNodes.Add(node);

            // Reset stats due to a change to the graph.
            this.Reset();
        }

        public Vertex FindVertexByID(String id)
        {
            for (int i = 0; i < _listOfNodes.Count; i++)
            {
                if (_listOfNodes[i].VertexID.ToLower() == id.ToLower())
                {
                    return _listOfNodes[i];
                }
            }

            return null;
        }

        public bool AddEdge(String v1, String v2, string imagePath1, string imagePath2)
        {
            Vertex vtx1 = FindVertexByID(v1);
            Vertex vtx2 = FindVertexByID(v2);

            if (vtx1 == null || vtx2 == null)
            {
                return false;
            }

            AddEdge(new Edge(vtx1,vtx2,vtx1.distance(vtx2),imagePath1,imagePath2));
            return true;
        }

        /// <summary>
        /// As the name suggests, this method calculates the shortest path between the source and target node.
        /// If successful, it updates the TotalCost and the OptimalPath properties with the corresponding values.
        /// </summary>
        /// <returns>Success/Failure</returns>
        public bool CalculateShortestPath()
        {
            bool destUnreachable = false;

            if (_sourceNode == null) // || _targetNode == null)
            {
                return false;
            }

            // Algorithm starts here

            // Reset stats
            this.Reset();

            // Set the cost on the source node to 0 and flag it as visited
            _sourceNode.AggregateCost = 0;


            // if the targetnode is not the sourcenode
            // if (_targetNode.AggregateCost == Vector2D.INFINITY) {
            // Start the traversal across the graph
            this.PerformCalculationForAllNodes();
            //}

            //_totalCost = _targetNode.AggregateCost;


            if (destUnreachable)
            {
                return false;
            }

            return true;
        }

        public List<Vertex> RetrieveShortestPath(Vertex targetNode)
        {
            List<Vertex> shortestPath = new List<Vertex>();

            if (targetNode == null)
            {
                throw new InvalidOperationException("Target node is null.");
            }
            else
            {
                Vertex currentNode = targetNode;

                shortestPath.Add(currentNode);

                while (currentNode.EdgeWithLowestCost != null)
                {
                    currentNode = currentNode.EdgeWithLowestCost.GetTheOtherVertex(currentNode);
                    shortestPath.Add(currentNode);
                }
            }

            // reverse the order of the nodes, because we started from target node first
            shortestPath.Reverse();

            return shortestPath;
        }

        public List<Vertex> RetrieveShortestPath(Vertex start, Vertex targetNode)
        {
            if (start == null || targetNode == null)
                return null;

            SourceVertex = start;
            CalculateShortestPath();
            return RetrieveShortestPath(targetNode);
        }

        private List<Edge> GetConnectedEdges(Vertex startNode)
        {
            List<Edge> connectedEdges = new List<Edge>();

            for (int i = 0; i < _listOfEdges.Count; i++)
            {
                if (_listOfEdges[i].GetTheOtherVertex(startNode) != null &&
                    !_listOfEdges[i].GetTheOtherVertex(startNode).Visited)
                {
                    connectedEdges.Add((Edge)_listOfEdges[i]);
                }
            }

            return connectedEdges;
        }


        public List<Vertex> Verticies
        {
            get
            {
                return _listOfNodes;
            }
        }

        public List<Edge> Edges
        {
            get
            {
                return _listOfEdges;
            }
        }


        /// <summary>
        /// Resets the costs from this instance.
        /// </summary>
        private void Reset()
        {
            // reset visited flag and reset the aggregate cost on all nodes
            for (int i = 0; i < _listOfNodes.Count; i++)
            {
                // The current node is now considered visited
                _listOfNodes[i].Visited = false;
                _listOfNodes[i].AggregateCost = Vertex.INFINITY;
                _listOfNodes[i].EdgeWithLowestCost = null;
            }
        }

        private List<Vertex> GetAListOfVisitedNodes()
        {
            List<Vertex> listOfVisitedNodes = new List<Vertex>();

            foreach (Vertex node in _listOfNodes)
            {
                if (node.Visited)
                {
                    listOfVisitedNodes.Add(node);
                }
            }

            return listOfVisitedNodes;
        }

        private void PerformCalculationForAllNodes()
        {
            Vertex currentNode = _sourceNode;

            // Start by marking the source node as visited
            currentNode.Visited = true;

            do
            {
                Vertex nextBestNode = null;

                // Retrieve a list of all visited nodes and for each node, get a list of all edges
                // that are not connected to visited nodes and update the aggregate cost on these other nodes.
                foreach (Vertex visitedNode in this.GetAListOfVisitedNodes())
                {
                    foreach (Edge connectedEdge in this.GetConnectedEdges(visitedNode))
                    {
                        // Only update if the aggregate cost on the other node is infinite 
                        // or is greater and equal to the aggregate cost on the current visited node.
                        if (connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost == Vertex.INFINITY
                            || (visitedNode.AggregateCost + connectedEdge.Cost) < connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost)
                        {
                            connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost = visitedNode.AggregateCost + connectedEdge.Cost;

                            // update the pointer to the edge with the lowest cost in the other node
                            connectedEdge.GetTheOtherVertex(visitedNode).EdgeWithLowestCost = connectedEdge;
                        }


                        if (nextBestNode == null || connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost < nextBestNode.AggregateCost)
                        {
                            nextBestNode = connectedEdge.GetTheOtherVertex(visitedNode);
                        }
                    }
                }

                // Move the currentNode onto the next optimal node.
                currentNode = nextBestNode;

                // Now set the visited property of the current node to true
                currentNode.Visited = true;

            } while (this.MoreVisitedNodes()); // Loop until every node's been visited.
        }

        private bool MoreVisitedNodes()
        {
            return GetAListOfVisitedNodes().Count < _listOfNodes.Count;
        }
    }
}
