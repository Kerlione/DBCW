using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class Subject {
        public string SubjectCode { get; set; }
        public string SubjectNameRus { get; set; }
        public string SubjectNameEn { get; set; }
        public string SubjectNameLv { get; set; }
        public int KP { get; set; }
        public int LecturesDay { get; set; }
        public int LecturesEvening { get; set; }
        public int LecturesDistance { get; set; }
        public int PracticeDay { get; set; }
        public int PracticeEvening { get; set; }
        public int PracticeDistance { get; set; }
    }
}
