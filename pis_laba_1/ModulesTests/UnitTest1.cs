using pis_laba_1;
using pis_laba_1.BL;
using pis_laba_1.Data;
using pis_laba_1.UI;
using System.Reflection;
using System.Runtime.CompilerServices;
using UI;

namespace ModulesTests
{
    public class UtilitesTests
    {
        private DateFiles CreateMockDateFiles()
        {
            var dateFiles = new DateFiles();

            var file1 = new DateFile();
            var file2 = new DateFile();
            var file3 = new DateFile();

            file1.parsWithFile("file1.txt", 100, new DateTime(2026, 10, 1));
            file2.parsWithFile("file2.txt", 200, new DateTime(2026, 10, 15));
            file3.parsWithFile("file3.txt", 300, new DateTime(2026, 10, 30));

            dateFiles.addFileToDB(file1);
            dateFiles.addFileToDB(file2);
            dateFiles.addFileToDB(file3);

            return dateFiles;
        }

        [Fact]
        public void DeterminationOfRemovalPeriod_ValidInput_ReturnsCorrectDates()
        {
            var dateFiles = CreateMockDateFiles();

            string simulatedInput = $"1{Environment.NewLine}3{Environment.NewLine}";
            using var stringReader = new StringReader(simulatedInput);
            Console.SetIn(stringReader);

            var result = Utilites.DeterminationOfRemovalPeriod(dateFiles);

            Assert.NotNull(result);
            Assert.Equal(new DateTime(2026, 10, 1), result["From"]);
            Assert.Equal(new DateTime(2026, 10, 30), result["To"]);
        }

        [Theory]
        [InlineData("99", "2")] 
        [InlineData("2", "99")]   
        [InlineData("-5", "2")]  
        public void DeterminationOfRemovalPeriod_OutofRangeInput_ThrowsIOException(string badFrom, string badTo)
        {
            var dateFiles = CreateMockDateFiles();
            Console.SetIn(new StringReader($"{badFrom}{Environment.NewLine}{badTo}{Environment.NewLine}"));

            var exception = Assert.Throws<IOException>(() => Utilites.DeterminationOfRemovalPeriod(dateFiles));

            Assert.Equal("В списке нет такой позиции. Попробуйте ещё раз", exception.Message);
        }

        [Theory]
        [InlineData("abc", "2")] 
        [InlineData("", "2")]
        [InlineData("", "abc")]
        public void DeterminationOfRemovalPeriod_NonNumericInput_ThrowsWrappedException(string badFrom, string badTo)
        {
            var dateFiles = CreateMockDateFiles();
            Console.SetIn(new StringReader($"{badFrom}{Environment.NewLine}{badTo}{Environment.NewLine}"));

            var exception = Assert.Throws<Exception>(() => Utilites.DeterminationOfRemovalPeriod(dateFiles));

            Assert.Equal("Ошибка при выборе даты", exception.Message);
        }


    }
    public class FileParseTests: IDisposable
    {
        private readonly string _testFilePath;
        private readonly FileParse _parser;

        public FileParseTests()
        {
            _testFilePath = Path.GetTempFileName();
            _parser = new FileParse(new DateFiles());
        }

        public void Dispose()
        {
            if(File.Exists(_testFilePath))
                File.Delete(_testFilePath);
        }

        public void WriteLines(params string[] lines)
        {
            File.WriteAllLines(_testFilePath, lines);
        }

        [Fact]
        public void ParsingOfFile_ValidLine_NoErrors()
        {
            WriteLines("file4 3 05.01.0001 2560x1440", "file5 4 06.01.0001", "file8 4 09.01.0001 50");
            _parser.parsingOfFile(_testFilePath);
            Assert.Empty(_parser.sendErrorsToUi());
        }

        [Theory]
        [InlineData(int.MaxValue)]
        public void CreatingFileVideoRecord_ExtremeFps_StoredAsIs(int fps)
        {
            DateVideoFile file = _parser.creatingFileVideoRecord(fps, new[] { "file4", "3", "05.01.0001" });
            Assert.Equal(fps, file.fps); 
        }

        [Theory]
        [InlineData("-100")]

        public void CreatingFileClassicRecord_NegativeSize_StoredAsIS(string syze)
        {
            var file = _parser.creatingFileClassicRecord(new[] { "file4", syze, "05.01.0001" });
            Assert.Equal(-100, file.sizeFile);
        }

        [Fact]
        public void SendErrorsToUi_NoErrorsElement_NotReturnNull()
        {
            Assert.NotNull(_parser.sendErrorsToUi());
        }

        [Theory]            
        [InlineData("\t")]                
        [InlineData("", "   ", "\t")]    
        public void ParsingOfFile_NoValidLine_NoErrors(params string[] lines)
        {
            WriteLines(lines);
            _parser.parsingOfFile(_testFilePath);
            Assert.Single(_parser.sendErrorsToUi());
        }
    }
}

    