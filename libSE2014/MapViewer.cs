using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PathGraph;

namespace libSE2014
{
    /// <summary>
    /// Given the graph verticies and edges, a map Bitmap is drawn with parameters
    /// </summary>
    public class MapViewer
    {
        private List<Vertex> verticies;
        private List<Edge> edges;

        public MapViewer(List<Vertex> verticies, List<Edge> edges)
        {
            this.verticies = verticies;
            this.edges = edges;
        }

        /// <summary>
        /// returns a Bitmap of parameter size and parameter scale of the edges and areas
        /// Only draw the text lable for types in drawableTypes
        /// the edges found in visitedEdges will be colored differently
        /// the center vertex will be at the center of the bitmap
        /// </summary>
        public Bitmap drawMap(int width, int height, float scale, Vertex center, List<String> drawableTypes, List<Edge> visitedEdges)
        {
            Bitmap buffer = new Bitmap(width, height);
            List<Vertex> textedVerts = new List<Vertex>();
            float lineWidth = 2.0f;
            var txtFont = new Font("arial", 6);
            var textColor = new SolidBrush(Color.Red);
            var lineColorNormal = new Pen(Color.Black, lineWidth);
            var lineColorUsed = new Pen(Color.Blue, lineWidth);

            // draw into the buffer using a graphics context for the buffer
            using (Graphics bufferGrph = Graphics.FromImage(buffer))
            {
                //white background
                bufferGrph.FillRectangle(new SolidBrush(Color.White), 0, 0, buffer.Width, buffer.Height);

                //translate to the center vertex
                bufferGrph.TranslateTransform(buffer.Width / 2, buffer.Height / 2);
                bufferGrph.TranslateTransform(-center.XCoord * scale, center.YCoord * scale);

                float mul = scale;

                foreach (var edge in edges)
                {
                    var v1 = edge.PointA;
                    var v2 = edge.PointB;

                    if (v1 == null || v2 == null)
                    {
                        continue;
                    }

                    //only draw the edge if the floor matches the center vertex
                    if (v1.ZCoord == center.ZCoord || v2.ZCoord == center.ZCoord)
                    {
                        //algebra
                        var posV1 = new System.Drawing.Point((int)(v1.XCoord * mul),(int)(-v1.YCoord * mul));
                        var posV2 = new System.Drawing.Point((int)(v2.XCoord * mul), (int)(-v2.YCoord * mul));

                        Pen lineColor;
                        //different color for visited edges
                        if (visitedEdges.Contains(edge))
                            lineColor = lineColorUsed;
                        else
                            lineColor = lineColorNormal;

                        bufferGrph.DrawLine(lineColor, posV1, posV2);

                        //draw the label for the verticies
                        if (drawableTypes.Contains(v1.Type) && !textedVerts.Contains(v1))
                        {
                            textedVerts.Add(v1);
                            bufferGrph.DrawString(v1.VertexID, txtFont, textColor, new PointF(posV1.X, posV1.Y));
                        }

                        if (drawableTypes.Contains(v2.Type) && !textedVerts.Contains(v2))
                        {
                            textedVerts.Add(v2);
                            bufferGrph.DrawString(v2.VertexID, txtFont, textColor, new PointF(posV2.X, posV2.Y));
                        }
                    }
                }
            }
            return buffer;
        }
    }
}
