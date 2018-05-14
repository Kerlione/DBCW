using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class Lecturer {
        public String PK { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Languages { get; set; }
        public String SecondName { get; set; }
        public String Degree { get; set; }
        public String Occupation { get; set; }
        public DateTime Birthday { get; set; }
        public Byte[] CV { get; set; }
        public Bitmap Photo { get; set; }

        public List<Publication> Publications { get; set; }
    }
}
