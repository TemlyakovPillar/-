using pis_laba_1.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("ModulesTests")]

namespace pis_laba_1.BL
{
    public class FileParse
    {
        private readonly DateFiles _currentDatabase;
        public FileParse(DateFiles currentDatabase)
        {
            _currentDatabase = currentDatabase;
        }

        private List<string> parsingErrors = new List<string>();

        internal DateFile creatingFileClassicRecord(string[] data)
        {
            int size = -1;
            DateTime time = new DateTime();
            string name = "";
            DateFile file = new DateFile();
            foreach (string part in data)
            {
                if (int.TryParse(part, out int parsedSize))
                    size = parsedSize;
                else if (DateTime.TryParse(part, out DateTime parsDate))
                    time = parsDate;
                else
                    name = part;
                file.parsWithFile(name, size, time);
            }
            return file;
        }

        internal DateVideoFile creatingFileVideoRecord(int parseFps, string[] data)
        {
            int size = -1;
            int fps = -1;
            DateTime time = new DateTime();
            string name = "";

            DateVideoFile fileVideo = new DateVideoFile();

            fps = parseFps;
            foreach (string part in data)
            {
                if (int.TryParse(part, out int parsedSize))
                    size = parsedSize;
                else if (DateTime.TryParse(part, out DateTime parsDate))
                    time = parsDate;
                else
                    name = part;
                fileVideo.parsWihtVideoFile(name, size, time, fps);
            }
            return fileVideo;
        }
        internal DateImageFile creatingFileImageRecord(string[] data)
        {
            int size = -1;
            int widthImage = -1; int heightImage = -1;
            DateTime time = new DateTime();
            string name = "";

            DateImageFile fileImage = new DateImageFile();

            string[] dimensions = data[data.Length - 1].Split('x', StringSplitOptions.RemoveEmptyEntries);

            if (int.TryParse(dimensions[0], out int parseWidthImage))
                widthImage = parseWidthImage;
            if (int.TryParse(dimensions[1], out int parseHeightImage))
                heightImage = parseHeightImage;

            foreach (string part in data)
            {
                if (int.TryParse(part, out int parsedSize))
                    size = parsedSize;
                else if (DateTime.TryParse(part, out DateTime parsDate))
                    time = parsDate;
                else if (part != data[data.Length - 1])
                    name = part;
                fileImage.parsWithImageFile(name, size, time, widthImage, heightImage);
            }
            return fileImage;
        }

        public List<string> sendErrorsToUi()
        {
            return parsingErrors;
        }


        public void parsingOfFile(string path)
        {
            int i = 0;
            foreach (string line in File.ReadLines(path))
            {
                i++;
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                    continue;
                else if (parts.Length < 3 || parts.Length > 4)
                {
                    parsingErrors.Add($"Неопознаный файл, проверьте строку списка №{i} ");
                    continue;
                }
                if (parts.Length == 3)
                {
                    _currentDatabase.addFileToDB(creatingFileClassicRecord(parts));
                }

                else if (int.TryParse(parts[parts.Length - 1], out int parseFps))
                {
                    _currentDatabase.addFileToDB(creatingFileVideoRecord(parseFps, parts));
                }

                else
                {
                    _currentDatabase.addFileToDB(creatingFileImageRecord(parts));
                }

            }
            
        }
    }
}
