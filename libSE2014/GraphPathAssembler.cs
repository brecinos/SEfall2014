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


            double p12 = v1.distance2D(v2);
            double p13 = v1.distance2D(v3);
            double p23 = v2.distance2D(v3);

            double p12S = p12 * p12;
            double p13S = p13 * p13;
            double p23S = p23 * p23;

            double a = p12S + p13S - p23S;
            double b = 2 * p12 * p13;

            if(b == 0.0)
                 return Direction.Forward;

            double angle = Math.Acos(a / b);

            double thresh = 0.0;
            if(angle >= -thresh && angle <= thresh)
            {
                return Direction.Forward;
            }
            else if (angle > 0 && angle < Math.PI)
            {
                return Direction.Right;
            }
            else
            {
                return Direction.Left;
            }

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
    }
}
