using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using pis_laba_1.Data;
using UI;

namespace pis_laba_1.UI
{
    public class ConsoleUI
    {
        private readonly DateFiles _dateFiles;
        private Menu menu;
        public AppState appContinue = new AppState();
        public ConsoleUI(DateFiles dateFiles, List<string> listParsingErrors)
        {
            menu = new Menu(dateFiles, listParsingErrors, appContinue);
        }

        public void printException(Exception ex)
        {
            if (ex.InnerException != null)
                Console.WriteLine($"{ex.Message}. {ex.InnerException.Message}");
            else
                Console.WriteLine(ex.Message);
        }

        public void rendring()
        {
            try
            {
                menu.showMenu();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Некорректное значение! Введите число:");
                Console.WriteLine("_____________________________________");
                Console.WriteLine();
            }
        }
    }
}
