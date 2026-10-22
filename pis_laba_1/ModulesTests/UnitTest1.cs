using pis_laba_1;
using pis_laba_1.BL;
using pis_laba_1.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ModulesTests
{
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

    