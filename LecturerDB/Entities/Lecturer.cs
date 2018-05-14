using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class Lecturer {
        public string PK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Languages { get; set; }
        public string SecondName { get; set; }
        public string Degree { get; set; }
        public string Occupation { get; set; }
        public DateTime Birthday { get; set; }
        public byte[] CV { get; set; }
        public byte[] Photo { get; set; }
        public string Cathedra { get; set; }

        public List<Publication> Publications { get; set; }
    }
}
