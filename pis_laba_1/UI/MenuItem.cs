using pis_laba_1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UI
{
    public abstract class MenuItem
    {
        protected string description;
        public string PrintDescription() => description;
        public MenuItem(string description)
        {
            this.description = description;
        }
        public abstract void Select();
    }

    public class MI_GetListFiles: MenuItem
    {
        private readonly DateFiles _dateFiles;
        private readonly List<string> _listParsingErrors;
        public MI_GetListFiles(DateFiles dateFiles, List<string> listParsingErrors) : base("Посмотреть имеющийся список файлов")
        {
            _dateFiles = dateFiles;
            _listParsingErrors = listParsingErrors;
        }
        public override void Select()
        {
            _dateFiles.allFilesForShow.PrintListFiles();
            _listParsingErrors.PrintParsingErrors();
            Utilites.afterCase();
        }
    }

    public class MI_DelimitationOfPeriod : MenuItem
    {
        private readonly DateFiles _dateFiles;

        public MI_DelimitationOfPeriod(DateFiles dateFiles) : base("Удалить файлы за период")
        {
            _dateFiles = dateFiles;
        }
        
        public override void Select()
        {
            Utilites.DelimitationOfPeriod(_dateFiles);
            Utilites.afterCase();
        }
    }

    public class MI_ProgramСоmpletion : MenuItem
    {
        private AppState appContinue;
        public MI_ProgramСоmpletion(AppState appContinue) : base("Завершение программы")
        {
            this.appContinue = appContinue;
        }


        public override void Select()
        {
            appContinue.continuationSign = false;
        }
    }
}
