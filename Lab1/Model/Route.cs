using System.Collections.Generic;
using System;

namespace Lab1 {
    class Route : IBase {
        public Guid Id { get; set; }
        public string Carrier {get; set; }
        public string Code {get; set;}
        public Airport AirportDepart {get; set; }
        public Airport AirportArrive {get; set; }

        public Airplane Airplane {get; set; }
    }
}
