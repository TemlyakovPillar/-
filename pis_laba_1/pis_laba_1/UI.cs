using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace pis_laba_1
{
    internal class UI
    {
        private DataGraph dateGraph;
        public UI(DataGraph dateGraph)
        {
            this.dateGraph = dateGraph;
        }
        public void rendring()
        {
            var adjacencyList = dateGraph.getEdges();
            foreach(var adjacency in adjacencyList)
            {
                char vertex = adjacency.Key;
                HashSet<char> neighbors = adjacency.Value;

                string neighborsString = string.Join(", ", neighbors);

                Console.WriteLine($"{vertex} -> {neighborsString}");
            }
        }
    }
}
