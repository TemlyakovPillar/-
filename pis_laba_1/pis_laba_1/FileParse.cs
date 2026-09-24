using System;
using System.Collections.Generic;
using System.Text;

namespace pis_laba_1
{
    internal class FileParse
    {
        private DateFiles currentDatabase;
        public FileParse(DateFiles currentDatabase)
        {
            this.currentDatabase = currentDatabase;
        }

        public List<DateFile> parsingOfFile(string path)
        {
            foreach (string line in File.ReadLines(path))
            {
                int size = 0;
                int fps = 0;
                int widthImage = 0; int heightImage = 0;
                DateTime time = new DateTime();
                string name = "";
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                    break;
                if (parts.Length == 3)
                {
                    DateFile file = new DateFile();
                    foreach (string part in parts)
                    {
                        
                        if (int.TryParse(part, out int parsedSize))
                             size = parsedSize;
                        else if (DateTime.TryParse(part, out DateTime parsDate))
                            time = parsDate;
                        else
                            name = part;
                        file.parsWithFile(name, size, time);
                    }
                    currentDatabase.addFileToDB(file);
                }

                else if (int.TryParse(parts[parts.Length - 1], out int parseFps))
                {
                    DateVideoFile fileVideo = new DateVideoFile();
                    fps = parseFps;
                    foreach (string part in parts)
                    {
                        if (int.TryParse(part, out int parsedSize))
                            size = parsedSize;
                        else if (DateTime.TryParse(part, out DateTime parsDate))
                            time = parsDate;
                        else
                            name = part;
                        fileVideo.parsWihtVideoFile(name, size, time, fps);
                    }
                    currentDatabase.addFileToDB(fileVideo);
                }

                else
                {
                    DateImageFile fileImage = new DateImageFile();
                    string[] dimensions = parts[parts.Length - 1].Split('×', StringSplitOptions.RemoveEmptyEntries);
                    widthImage = int.Parse(dimensions[0]);
                    heightImage = int.Parse(dimensions[1]);
                    foreach (string part in parts)
                    {
                        if (int.TryParse(part, out int parsedSize))
                            size = parsedSize;
                        else if (DateTime.TryParse(part, out DateTime parsDate))
                            time = parsDate;
                        else
                            name = part;
                        fileImage.parsWithImageFile(name, size, time, widthImage, heightImage);
                    }
                    currentDatabase.addFileToDB(fileImage);
                }
            }
            return currentDatabase.allFilesForShow;
        }
    }
}
