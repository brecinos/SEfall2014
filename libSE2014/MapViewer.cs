using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PathGraph;

namespace libSE2014
{
    public class MapViewer
    {
        private List<Vertex> verticies;
        private List<Edge> edges;

        public MapViewer(List<Vertex> verticies, List<Edge> edges)
        {
            this.verticies = verticies;
            this.edges = edges;
        }

        public Bitmap drawMap(int width, int height, float scale, Vertex center, List<String> drawableTypes, List<Edge> visitedEdges)
        {
            Bitmap buffer = new Bitmap(width, height);
            List<Vertex> textedVerts = new List<Vertex>();
            float lineWidth = 2.0f;
            var txtFont = new Font("arial", 6);
            var textColor = new SolidBrush(Color.Red);
            var lineColorNormal = new Pen(Color.Black, lineWidth);
            var lineColorUsed = new Pen(Color.Blue, lineWidth);

            // Draw rectangle into the buffer
            using (Graphics bufferGrph = Graphics.FromImage(buffer))
            {
                bufferGrph.FillRectangle(new SolidBrush(Color.White), 0, 0, buffer.Width, buffer.Height);
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

                    if (v1.ZCoord == center.ZCoord || v2.ZCoord == center.ZCoord)
                    {
                        var posV1 = new System.Drawing.Point((int)(v1.XCoord * mul),(int)(-v1.YCoord * mul));
                        var posV2 = new System.Drawing.Point((int)(v2.XCoord * mul), (int)(-v2.YCoord * mul));

                        bufferGrph.DrawLine(lineColorNormal, posV1, posV2);
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
