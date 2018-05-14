using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class Group {
        public string GroupID { get; set; }
        public int StudentCount { get; set; }
        public string GroupHead { get; set; }
        public string ContactInfo { get; set; }
        public string Faculty { get; set; }
        public string StudyForm { get; set; }
        public string StudyProgram { get; set; }
        public DateTime StartYear { get; set; }


        public List<MoveStudent> MoveStudents { get; set; }
        public List<LoadPlan> LoadPlans { get; set; }
    }
}
