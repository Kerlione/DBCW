using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class Publication {
        public int PublicationID { get; set; }
        public String Name { get; set; }
        public DateTime Year { get; set; }
        public String PublicationPlace { get; set; }
        public String Rating { get; set; }
    }
}
