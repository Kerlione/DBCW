using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class MoveStudent {
        public string GroupNum { get; set; }
        public int StudyYear { get; set; }
        public int Semester { get; set; }
        public int BeginSemesterCount { get; set; }
        public int EndSemesterCount { get; set; }
        public int Dismissal { get; set; }
        public string DismissalReason { get; set; }
    }
}
