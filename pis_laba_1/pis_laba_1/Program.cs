
namespace pis_laba_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool pz = true;
            while (pz)
            {
                Console.WriteLine("Создать файл (Y - Да; Z - Нет)");
                string z = Console.ReadLine();
                if (z == "Z") return;
                Console.WriteLine("Введите имя файла: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите размер файла (целое число)");
                int size = int.Parse(Console.ReadLine());
                MyFile file = new MyFile(name, size);
                Console.Clear();
                Console.WriteLine($"Создан файл: {file.fileName} размер: {file.sizeFile} дата создания: {file.timeCreatedFile}");
                Console.WriteLine("Переименовать? (Y - Да; Z - Нет");
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
        public DateTime timeCreatedFile { get; }
        public int sizeFile { get; }
        public MyFile(string _fileName, int sizeFile)
        {
            this._fileName = _fileName;
            this.sizeFile = sizeFile;
            timeCreatedFile = DateTime.Now;
        }
    }

}
