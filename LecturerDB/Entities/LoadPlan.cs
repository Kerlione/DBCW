using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LecturerDB.Entities.Enums;

namespace LecturerDB.Entities {
    class LoadPlan {
        public string GroupID { get; set; }
        public string SubjectCode { get; set; }
        public string StudyYear { get; set; }
        public string Semester { get; set; }
        public int Lections { get; set; }
        public int Practices { get; set; }
        public int Laboratories { get; set; }
        public bool CourseWork { get; set; }
        public string LecturerPK { get; set; }
        public Language SubjectLanguage { get; set; }
        public float LoadCoefficient { get;  }
        public int TotalHours { get; set; }
    }
}
