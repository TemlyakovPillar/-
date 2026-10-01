using System;
using System.Collections.Generic;
using System.Text;

namespace pis_laba_1
{
    class DataGraph
    {
        private Dictionary<char, HashSet<char>> edges = new Dictionary<char, HashSet<char>>();
        public void AddItemToData(char vertex, char adjacentVertices)
        {
            var neighborSet = new HashSet<char> { adjacentVertices };
            edges.TryAdd(vertex, neighborSet);
        }

        public void PatchItem(char vertex, char newAdjacentVertices)
        {
            if (edges.ContainsKey(vertex))
            {
                edges[vertex].Add(newAdjacentVertices);
            }
        }
        public Dictionary<char, HashSet<char>> getEdges() => edges;
    }
}
