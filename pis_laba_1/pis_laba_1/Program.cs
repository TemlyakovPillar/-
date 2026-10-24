using System.Data;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using pis_laba_1.BL;
using pis_laba_1.Data;
using pis_laba_1.UI;


namespace pis_laba_1
{
    public class Program
    {
        static void Main(string[] args)
        {

            string path = "C:\\Users\\Book\\source\\repos\\-\\git_for_l1\\pis_laba_1\\pis_laba_1\\file.txt";

            DateFiles dataGraph = new DateFiles();

            FileParse fileParse = new FileParse(dataGraph);
            fileParse.parsingOfFile(path);

            ConsoleUI ui = new ConsoleUI(dataGraph, fileParse.sendErrorsToUi());

            ui.Run();

            while (ui.appContinue.continuationSign)
            {
                try
                {
                    ui.rendring();
                }
                catch (Exception ex)
                {
                    ui.printException(ex);
                }
            }
            
            
        }

    }
}


