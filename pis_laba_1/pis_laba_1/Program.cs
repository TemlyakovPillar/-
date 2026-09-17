using System.Data;
using System.Diagnostics.Tracing;
using System.IO;
namespace pis_laba_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DateFile> allMyFile = new List<DateFile>();

            string path = "C:\\Users\\Book\\source\\repos\\-\\git_for_l1\\pis_laba_1\\pis_laba_1\\file.txt";
            foreach (string line in File.ReadLines(path))
            {
                DateFile file = new DateFile();
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int parsedSize))
                        file.sizeFile = parsedSize;
                    else if (DateTime.TryParse(part, out DateTime parsDate))
                        file.timeCreatedFile = parsDate;
                    else
                        file.fileName = part;
                }
                allMyFile.Add(file);
            }

            void f(List<DateFile> allFile, DateTime from, DateTime to)
            {
                List<DateFile> filesForDel = new List<DateFile>();
                for (int i = 0; i < allFile.Count; i++)
                {
                    if (allFile[i].timeCreatedFile >= from & allFile[i].timeCreatedFile <= to)
                        filesForDel.Add(allFile[i]);
                }

                for (int i = 0; i < filesForDel.Count; i++)
                {
                    allFile.Remove(filesForDel[i]);
                }

            }
            void afterCase()
            {
                Console.WriteLine();
                Console.WriteLine("чтобы перейти в основное меню нажмите Enter..");
                Console.ReadLine();
                Console.Clear();
            }

            while (true)
            {
                Console.WriteLine("Выберите номер действия из списка");
                Console.WriteLine("__________________________________");
                Console.WriteLine();
                Console.WriteLine("1. Посмотреть список файлов");
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
                        for (int i = 0; i < allMyFile.Count; i++)
                            Console.WriteLine($"{i + 1}. {allMyFile[i].fileName} {allMyFile[i].sizeFile} {allMyFile[i].timeCreatedFile}");
                        afterCase();
                        break;

                    case 2:
                        Console.WriteLine("Выберите две даты (начало и конец периода)");
                        for (int i = 0; i < allMyFile.Count; i++)
                            Console.WriteLine($"{i+1}. {allMyFile[i].timeCreatedFile}");
                        Console.Write("Дата начала периода: ");
                    WrongChoseFrom: string choseFrom = Console.ReadLine();
                        if (int.TryParse(choseFrom, out int choseFromUser))
                        {
                            if (choseFromUser < 1 || choseFromUser > allMyFile.Count + 1)
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
                            if (choseToUser < 1 || choseToUser > allMyFile.Count + 1)
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
                        DateTime dataFrome = allMyFile[choseFromUser - 1].timeCreatedFile;
                        DateTime dataTo = allMyFile[choseToUser - 1].timeCreatedFile;
                        f(allMyFile, dataFrome, dataTo);
                        Console.WriteLine($"Файлы за период от {dataFrome} до {dataTo} удалены");
                        afterCase();
                        break;
                    case 3:
                        return;
                }
            }
        }

    }


    class DateFile
    {
        private string _fileName;
        public string fileName
        {
            get => _fileName;
            set
            {
                if (_fileName == value) return;
                _fileName = value;
            }
        }
        public DateTime timeCreatedFile { get; set; } 

        public int sizeFile { get; set; }
        public void parsWithFile(string parsFileName, int parsFileSize, DateTime parsTimeCreatedFile)
        {
            _fileName = parsFileName;
            sizeFile = parsFileSize;
            timeCreatedFile = parsTimeCreatedFile;
        }
    }

}
