using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using libSE2014;
using PathGraph;

namespace SE2014Project
{
    public class AppContext
    {
        private Graph graph;
        private AppContext()
        {
            graph = new Graph();

            GraphLoader loader = new GraphLoader();
            loader.load(Path.Combine(
           HostingEnvironment.ApplicationPhysicalPath,
           @"App_Data\bishops.xml"));

            var vs = loader.GetVerticies();
            var es = loader.GetEdges();

            foreach (var v in vs)
            {
                graph.AddVertex(v);
            }

            foreach (var e in es)
            {
                graph.AddEdge(e);
            }
        }

        public static AppContext Instance
        {
            get
            {
                if (HttpContext.Current.Session["app_context"] == null)
                {
                    HttpContext.Current.Session["app_context"] = new AppContext();
                }
                return (AppContext)HttpContext.Current.Session["app_context"];
            }
        }

        public Graph getGraph()
        {
            return graph;
        }

        public String InitialRoom
        {
            get;
            set;
        }

        public String DestinationRoom
        {
            get;
            set;
        }

        public int MapZoomFactor
        {
            get;
            set;
        }

        public int MapWidth
        {
            get;
            set;
        }

        public int MapHeight
        {
            get;
            set;
        }
    }
}