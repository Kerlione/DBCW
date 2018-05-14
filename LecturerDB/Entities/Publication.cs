using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerDB.Entities {
    class Publication {
        public int PublicationID { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string PublicationPlace { get; set; }
        public string Rating { get; set; }
    }
}
