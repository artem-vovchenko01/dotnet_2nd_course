using System.Collections.Generic;
using System;

namespace Lab1 {
    class Route : IRoute<int> {
        public int Id { get; set; }
        public string Carrier {get; set; }
        public string Code {get; set;}
        public IAirport<int> AirportDepart {get; set; }
        public IAirport<int> AirportArrive {get; set; }

        public IAirplane<int> Airplane {get; set; }
    }
}
