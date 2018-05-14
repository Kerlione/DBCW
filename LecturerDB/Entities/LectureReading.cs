using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class LectureReading {
        public Language ReadingLanguage { get; set; }
        public Lecturer LectureReader { get; set; }
        public Subject ReadingSubject { get; set; }
    }
}
