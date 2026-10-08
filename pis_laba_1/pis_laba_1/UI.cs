using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace pis_laba_1
{
    internal class UI
    {
        DateFiles dateFiles;
        public UI(DateFiles dateFiles)
        {
            this.dateFiles = dateFiles;
        }

        private void afterCase()
        {
            Console.WriteLine();
            Console.WriteLine("чтобы перейти в основное меню нажмите Enter..");
            Console.ReadLine();
            Console.Clear();
        }

        private void delimitationOfPeriod()
        {
            Console.Clear();
            Console.WriteLine("Выберите две даты (начало и конец периода)");

            for (int i = 0; i < dateFiles.allFilesForShow.Count; i++)
                Console.WriteLine($"{i + 1}. {dateFiles.allFilesForShow[i].timeCreatedFile}");
            while (true)
            {
                try
                {
                    Console.Write("Дата начала периода: ");
                    int choseFromUser = int.Parse(Console.ReadLine());
                    if (choseFromUser > dateFiles.allFilesForShow.Count)
                        throw new IOException("В списке нет такой позиции. Попробуйте ещё раз");

                    Console.Write("Дата конца периода: ");
                    int choseToUser = int.Parse(Console.ReadLine());
                    if (choseToUser > dateFiles.allFilesForShow.Count)
                        throw new IOException("В списке нет такой позиции. Попробуйте ещё раз");

                    DateTime dataFrome = dateFiles.allFilesForShow[choseFromUser - 1].timeCreatedFile;
                    DateTime dataTo = dateFiles.allFilesForShow[choseToUser - 1].timeCreatedFile;

                    dateFiles.ereseRange(dataFrome, dataTo);

                    Console.WriteLine($"Файлы за период от {dataFrome} до {dataTo} удалены");
                    afterCase();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при выборе даты", ex);
                }

            }
        }

        public void printException(Exception ex)
        {
            if (ex.InnerException != null)
                Console.WriteLine($"{ex.Message}. {ex.InnerException.Message}");
            else
                Console.WriteLine($"{ex.Message}");
        }

        public void rendring()
        {
            while (true)
            {
                Console.WriteLine("Выберите номер действия из списка");
                Console.WriteLine("__________________________________");
                Console.WriteLine();
                Console.WriteLine("1. Посмотреть имеющийся список файлов");
                Console.WriteLine("2. Удалить файлы за период");
                Console.WriteLine("3. Завершение программы");

                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine($"Файлов всего: {dateFiles.allFilesForShow.Count}");
                            for (int i = 0; i < dateFiles.allFilesForShow.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.");
                                Console.WriteLine(dateFiles.allFilesForShow[i].toString());
                                Console.WriteLine("______________________________________");
                                Console.WriteLine();
                            }
                            afterCase();
                            break;

                        case 2:
                            delimitationOfPeriod();
                            break;

                        case 3:
                            return;
                    }
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
}
