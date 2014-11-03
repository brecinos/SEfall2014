using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathGraph;

namespace libSE2014
{
    public class GraphFrontEnd
    {
        public  List<GraphPathComponent> GeneratePathGraph(string file)
        {
            Graph gr = new Graph();
            GraphLoader gl = new GraphLoader();
            bool success = gl.load(file);

            var vtx = gl.GetVerticies();
            var edges = gl.GetEdges();

            foreach (var v in vtx)
            {
                gr.AddVertex(v);
            }

            foreach (var e in edges)
            {
                gr.AddEdge(e);
            }

            // to be received as parameters, change the fixed values by parameters
            var FindVertexIdValue = "J103";
            var FindVertexIdValue2 = "J116";

            var path = gr.RetrieveShortestPath(gr.FindVertexByID(FindVertexIdValue), gr.FindVertexByID(FindVertexIdValue2));

            var assembler = new GraphPathAssembler(path, edges, "");
            var assemPath = assembler.GeneratePath();
            return assemPath;
        }


    }
}
