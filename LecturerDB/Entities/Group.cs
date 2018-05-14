using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class Group {
        public String GroupID { get; set; }
        public int StudentCount { get; set; }
        public String GroupHead { get; set; }
        public String ContactInfo { get; set; }
        public String Faculty { get; set; }
        public String StudyForm { get; set; }
        public String StudyProgram { get; set; }
        public DateTime StartYear { get; set; }
    }
}
