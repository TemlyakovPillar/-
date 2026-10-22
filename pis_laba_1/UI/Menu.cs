using pis_laba_1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    internal class Menu
    {
        private List<MenuItem> items;
        public Menu(DateFiles dateFiles, List<string> listParsingErrors, AppState appContinue)
        {

            items = new List<MenuItem>()
            {
                new MI_GetListFiles(dateFiles, listParsingErrors),
                new MI_DelimitationOfPeriod(dateFiles), 
                new MI_ProgramСоmpletion(appContinue)
            };
        }
        public void AddMenuItem(MenuItem item)
        {
            items.Add(item);
        }

        public void showMenu()
        {
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine($"{i + 1}. {items[i].PrintDescription()}");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice > 0 && choice <= items.Count())
                    items[choice - 1].Select();
            }
        }
    }
}
