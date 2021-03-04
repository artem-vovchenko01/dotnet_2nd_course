using System.Collections.Generic;
using System;

namespace Lab1 {
    class Route<Key> : IBase<Key> where Key : IComparable<Key> {
        public Key Id { get; set; }
        public string Carrier {get; set; }
        public string Code {get; set;}
        public Airport<Key> AirportDepart {get; set; }
        public Airport<Key> AirportArrive {get; set; }

        public Airplane<Key> Airplane {get; set; }
    }
}
