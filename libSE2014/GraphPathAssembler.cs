using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PathGraph;

namespace libSE2014
{
    public enum Direction { Forward, Left, Right, Backward };

    public class GraphPathComponent
    {
        private Vertex _v;
        private String _imgPath;
        private Direction _direction;
        private Vertex _destinationVertex;
        private Edge _edge;

        public GraphPathComponent(Vertex v, String imgPath, Direction direction, Vertex destinationVert, Edge edge)
        {
            _v = v;
            _imgPath = imgPath;
            _destinationVertex = destinationVert;
            _direction = direction;
            _edge = edge;
        }

        public Vertex Vertex
        {
            get
            {
                return _v;
            }
        }

        public String ImagePath
        {
            get
            {
                return _imgPath;
            }
        }


        public Direction Direction
        {
            get
            {
                return _direction;
            }
        }

        public String DirectionString
        {
            get
            {
                switch (_direction)
                {
                    case Direction.Forward:
                        return "Forward";
                    case Direction.Backward:
                        return "Backward";
                    case Direction.Left:
                        return "Left";
                    case Direction.Right:
                        return "Right";
                    default:
                        return "Unknown Direction";
                }
            }
        }

        public Vertex DestinationVertex
        {
            get
            {
                return _destinationVertex;
            }
        }

        public Edge Edge
        {
            get
            {
                return _edge;
            }
        }
    }

    public class GraphPathAssembler
    {
        private List<Vertex> _pathVerticies;
        private List<Edge> _allEdges;
        private String _imageRelPath;

        private Edge GetEdge(Vertex v1, Vertex v2)
        {
            foreach (var e in _allEdges)
            {
                if ((e.PointA == v1 && e.PointB == v2) ||
                    (e.PointA == v2 && e.PointB == v1))
                {
                    return e;
                }
            }

            return null;
        }

        private Direction DetermineDirectionOfV2(Vertex v1, Vertex v2, Vertex v3)
        {
            if (v1 == null || v2 == null || v3 == null)
                return Direction.Forward;


            double ax = v2.XCoord - v1.XCoord;
            double ay = v2.YCoord - v1.YCoord;
            double bx = v3.XCoord - v2.XCoord;
            double by = v3.YCoord - v2.YCoord;

            double z = ax * by - ay * bx;

            if (z > 0.0) return Direction.Left;
            if (z < 0.0) return Direction.Right;
            return Direction.Forward;
        }

        public GraphPathAssembler(List<Vertex> pathVerticies, List<Edge> allEdges, String imageRelativePath)
        {
            _pathVerticies = pathVerticies.ConvertAll(vert => vert);
            _allEdges = allEdges.ConvertAll(edge => edge);
            _imageRelPath = imageRelativePath;

        }

        public List<GraphPathComponent> GeneratePath()
        {
            var path = new List<GraphPathComponent>();

            if(_pathVerticies.Count < 2)
                return path;

            Vertex previous = null;
            Vertex current = null;
            Vertex next = null;
            for (int i = 0; i < _pathVerticies.Count - 1; i++)
            {
                current = _pathVerticies[i];
                next = _pathVerticies[i + 1];

                var imgPath = "";

                var edge = GetEdge(current,next);

                if(edge == null)
                    return new List<GraphPathComponent>();

                if(edge.PointA == current)
                {
                    if(edge.FirstImage.Length > 0)
                    {
                        imgPath = _imageRelPath + edge.FirstImage;
                    }
                }
                else
                {
                    if(edge.SecondImage.Length > 0)
                    {
                        imgPath = _imageRelPath + edge.SecondImage;
                    }
                }

                Vertex destVertex = null;

                if(i == _pathVerticies.Count - 2)
                    destVertex = _pathVerticies[_pathVerticies.Count - 1];

                var gc = new GraphPathComponent(current, imgPath, DetermineDirectionOfV2(previous, current, next), destVertex,edge);
                path.Add(gc);

                previous = _pathVerticies[i];
            }

            return path;
        }

        public List<GraphPathComponent> GenerateOptimizedPath()
        {
            var path = GeneratePath();

            var opPath = new List<GraphPathComponent>();

            if (path.Count < 2)
                return path;

            GraphPathComponent previous = null;
            GraphPathComponent current = null;
            GraphPathComponent next = null;
            for (int i = 0; i < path.Count - 1; i++)
            {
                current = path[i];
                next = path[i + 1];

                if (previous != null && current != null && next != null)
                {
                    if (previous.Direction != Direction.Forward || current.Direction != Direction.Forward ||
                        next.Direction != Direction.Forward)
                    {
                        if(opPath.Where( x => x.ImagePath == current.ImagePath).Count() == 0)
                        opPath.Add(current);
                    }
                }
                previous = path[i];
            }

            if (next != null)
                opPath.Add(next);

            return opPath;
        }
    }
}
