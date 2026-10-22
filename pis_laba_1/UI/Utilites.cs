using pis_laba_1;
using pis_laba_1.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UI
{
    internal static class Utilites
    {
        internal static void PrintListFiles(List<DateFile> listFiles)
        {
            Console.Clear();
            Console.WriteLine($"Файлов всего: {listFiles.Count}");
            for (int i = 0; i < listFiles.Count; i++)
            {
                Console.WriteLine($"{i + 1}.");
                Console.WriteLine(listFiles[i].toString());
                Console.WriteLine(new string('_', listFiles[i].toString().Length + 3));
                Console.WriteLine();
            }
        }

        internal static void PrintParsingErrors(List<string> listParsingErrors)
        {
            foreach (string error in listParsingErrors)
                Console.WriteLine(error);
        }

        internal static Dictionary<string, DateTime> DeterminationOfRmovalPeriod(DateFiles _dateFiles)
        {
            Dictionary<string, DateTime> dates = new Dictionary<string, DateTime>();
            Console.Clear();
            Console.WriteLine("Выберите две даты (начало и конец периода)");

            for (int i = 0; i < _dateFiles.allFilesForShow.Count; i++)
                Console.WriteLine($"{i + 1}. {_dateFiles.allFilesForShow[i].timeCreatedFile}");
            try
            {
                Console.Write("Дата начала периода: ");
                int choseFromUser = int.Parse(Console.ReadLine());
                if (choseFromUser > _dateFiles.allFilesForShow.Count)
                    throw new IOException("В списке нет такой позиции. Попробуйте ещё раз");

                Console.Write("Дата конца периода: ");
                int choseToUser = int.Parse(Console.ReadLine());
                if (choseToUser > _dateFiles.allFilesForShow.Count)
                    throw new IOException("В списке нет такой позиции. Попробуйте ещё раз");

                DateTime dataFrome = _dateFiles.allFilesForShow[choseFromUser - 1].timeCreatedFile;
                DateTime dataTo = _dateFiles.allFilesForShow[choseToUser - 1].timeCreatedFile;

                dates.Add("From", dataFrome);
                dates.Add("To", dataTo);

                return dates;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при выборе даты", ex);
            }
        }

        internal static void DelimitationOfPeriod(DateFiles dateFiles)
        {
            var dates = DeterminationOfRmovalPeriod(dateFiles);

            dateFiles.ereseRange(dates["From"], dates["To"]);

            Console.WriteLine($"Файлы за период от {dates["From"]} до {dates["To"]} удалены");
        }

        internal static void afterCase()
        {
            Console.WriteLine();
            Console.WriteLine("чтобы перейти в основное меню нажмите Enter..");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
