using System;
using System.Collections.Generic;
using System.Text;

namespace pis_laba_1
{
    public class DateFile
    {
        public string fileName = "";
        protected DateTime _timeCreatedFile;
        public DateTime timeCreatedFile { get { return _timeCreatedFile; } }
        protected int _sizeFile;
        public int sizeFile { get { return _sizeFile; } }

        public virtual void parsWithFile(string parsFileName, int parsFileSize, DateTime parsTimeCreatedFile)
        {
            fileName = parsFileName;
            _sizeFile = parsFileSize;
            _timeCreatedFile = parsTimeCreatedFile;
        }
        public virtual string toString()
        {
            return $"Имя файла: {fileName}\n Размер: {_sizeFile}\n Дата создания: {_timeCreatedFile}";
        }
    }
    public class DateImageFile : DateFile
    {

        public int widthImage { get; set; }

        public int heightImage { get; set; }

        public void parsWithImageFile(string parsFileName, int parsFileSize, DateTime parsTimeCreatedFile, int pathWidthImage, int pathHeightImage)
        {
            widthImage = pathWidthImage;
            heightImage = pathHeightImage;
            parsWithFile(parsFileName, parsFileSize, parsTimeCreatedFile);
        }
        public override string toString()
        {
            return $"Имя файла: {fileName}\n Размер: {_sizeFile}\n Дата создания: {_timeCreatedFile}\n Разрешение: {widthImage}x{heightImage}";

        }
    }

    public class DateVideoFile : DateFile
    {
        public int fps { get; set; }

        public void parsWihtVideoFile(string parsFileName, int parsFileSize, DateTime parsTimeCreatedFile, int parsFps)
        {

            fps = parsFps;
            parsWithFile(parsFileName, parsFileSize, parsTimeCreatedFile);
        }
        public override string toString()
        {
            return $"Имя файла: {fileName}\n Размер: {_sizeFile}\n Дата создания: {_timeCreatedFile}\n fps: {fps}q";

        }
    }
}
