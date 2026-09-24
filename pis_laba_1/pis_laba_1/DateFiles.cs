using System;
using System.Collections.Generic;
using System.Text;

namespace pis_laba_1
{
    internal class DateFiles
    {
        private List<DateFile> allFiles = new List<DateFile>();

        public List<DateFile> allFilesForShow { get { return allFiles; } }

        public void addFileToDB(DateFile newFile)
        {
            allFiles.Add(newFile);
        }

        public void ereseRange(DateTime from, DateTime to)
        {
            List<DateFile> filesForDel = new List<DateFile>();
            for (int i = 0; i < allFiles.Count; i++)
            {
                if (allFiles[i].timeCreatedFile >= from & allFiles[i].timeCreatedFile <= to)
                    filesForDel.Add(allFiles[i]);
            }

            for (int i = 0; i < filesForDel.Count; i++)
            {
                allFiles.Remove(filesForDel[i]);
            }
        }

        public void clearBD()
        {
            allFiles.Clear();
        }
    }
}
