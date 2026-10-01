using System;
using System.Collections.Generic;
using System.Text;

namespace pis_laba_1
{
    internal class FileParse
    {
        private DataGraph currentDatabase;
        public FileParse(DataGraph currentDatabase)
        {
            this.currentDatabase = currentDatabase;
        }

        public void parsingOfFile(string path)
        {
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 3) continue;

                char vertex = char.Parse(parts[0]);
                char neighbor = char.Parse(parts[2]);

                if (!currentDatabase.getEdges().ContainsKey(vertex))
                    currentDatabase.AddItemToData(vertex, neighbor);

                else
                    currentDatabase.PatchItem(vertex, neighbor);
            }
        }
    }
}
