using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace pis_laba_1
{
    internal class UI
    {
        private DateFiles dateFiles;
        public UI(DateFiles dateFiles)
        {
            this.dateFiles = dateFiles;
        }

        public void afterCase()
        {
            Console.WriteLine();
            Console.WriteLine("чтобы перейти в основное меню нажмите Enter..");
            Console.ReadLine();
            Console.Clear();
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

            WrongChose: string chose = Console.ReadLine();
                int choseUser;
                if (int.TryParse(chose, out int riteChose))
                {
                    if (riteChose < 1 || riteChose > 3)
                    {
                        Console.WriteLine("такого номера нет в списке, попробуйте еще раз");
                        Console.WriteLine();
                        goto WrongChose;
                    }
                    choseUser = riteChose;
                }
                else
                {
                    Console.WriteLine("такого номера нет в списке, попробуйте еще раз");
                    Console.WriteLine();
                    goto WrongChose;
                }
                Console.Clear();

                switch (choseUser)
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
                        Console.Clear();
                        Console.WriteLine("Выберите две даты (начало и конец периода)");

                        for (int i = 0; i < dateFiles.allFilesForShow.Count; i++)
                            Console.WriteLine($"{i + 1}. {dateFiles.allFilesForShow[i].timeCreatedFile}");

                        Console.Write("Дата начала периода: ");
                    WrongChoseFrom: string choseFrom = Console.ReadLine();
                        if (int.TryParse(choseFrom, out int choseFromUser))
                        {
                            if (choseFromUser < 1 || choseFromUser > dateFiles.allFilesForShow.Count + 1)
                            {
                                Console.WriteLine("такого номера нет в списке, попробуйте еще раз");
                                Console.WriteLine();
                                goto WrongChoseFrom;
                            }
                        }
                        else
                        {
                            Console.WriteLine("такого номера нет в списке, попробуйте еще раз");
                            Console.WriteLine();
                            goto WrongChoseFrom;
                        }
                        Console.Write("Дата конца периода: ");
                    WrongChoseTo: string choseTo = Console.ReadLine();
                        if (int.TryParse(choseTo, out int choseToUser))
                        {
                            if (choseToUser < 1 || choseToUser > dateFiles.allFilesForShow.Count + 1)
                            {
                                Console.WriteLine("такого номера нет в списке");
                                Console.WriteLine();
                                goto WrongChoseTo;
                            }
                        }
                        else
                        {
                            Console.WriteLine("такого номера нет в списке, попробуйте еще раз");
                            Console.WriteLine();
                            goto WrongChoseTo;
                        }
                        DateTime dataFrome = dateFiles.allFilesForShow[choseFromUser - 1].timeCreatedFile;
                        DateTime dataTo = dateFiles.allFilesForShow[choseToUser - 1].timeCreatedFile;
                        dateFiles.ereseRange(dataFrome, dataTo);
                        Console.WriteLine($"Файлы за период от {dataFrome} до {dataTo} удалены");
                        afterCase();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}
