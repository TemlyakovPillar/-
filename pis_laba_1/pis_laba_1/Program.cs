using System.Data;
using System.Diagnostics.Tracing;
using System.IO;
using System.Security.Cryptography;
namespace pis_laba_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = "C:\\Users\\Book\\source\\repos\\-\\git_for_l1\\pis_laba_1\\pis_laba_1\\file.txt";

            DateFiles dataGraph = new DateFiles();
            FileParse fileParse = new FileParse(dataGraph);
            UI ui = new UI(dataGraph);
            fileParse.parsingOfFile(path);
            ui.rendring();
        }

    }
}


