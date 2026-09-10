using System.IO;
namespace pis_laba_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool pz = true;
            while (pz)
            {
                Console.WriteLine("Прочитать файл (Y - Да; Z - Нет)");
                string z = Console.ReadLine();
                if (z == "Z") return;
                Console.WriteLine("путь к файлу:");
                string path = Console.ReadLine();
                FileInfo fileInfo = new FileInfo(path);
                long sizeFile = fileInfo.Length;
                string stringOffile = File.ReadAllText(path);
                string fileName = Path.GetFileName(path);
                DateTime timeCreatedFile = File.GetCreationTime(path);
                /*Console.WriteLine("Введите размер файла (целое число)");
                int size = int.Parse(Console.ReadLine());*/
                MyFile file = new MyFile();
                file.parsWithFile(fileName, sizeFile, timeCreatedFile);
                Console.Clear();
                Console.WriteLine($"Получен файл: {file.fileName} размер: {file.sizeFile} дата создания: {file.timeCreatedFile}");
                Console.WriteLine("Переименовать? (Y - Да; Z - Нет");
                z = Console.ReadLine();
                if (z == "Z") 
                {
                    Console.Clear();
                    Console.WriteLine($"Создан файл: {file.fileName} размер: {file.sizeFile} дата создания: {file.timeCreatedFile}");
                    return;
                }
                Console.WriteLine("Введите новое имя: ");
                file.fileName = Console.ReadLine();
                Console.WriteLine($"Создан файл: {file.fileName} размер: {file.sizeFile} дата создания: {file.timeCreatedFile}");
            }
        }
    }

    class MyFile 
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
        public long sizeFile { get; set; }
        public void parsWithFile(string parsFileName, long parsFileSize, DateTime parsTimeCreatedFile) 
        {
            _fileName = parsFileName;
            sizeFile = parsFileSize;
            timeCreatedFile = parsTimeCreatedFile;
        }
    }

}
