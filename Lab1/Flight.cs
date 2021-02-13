using System.Collections.Generic;
using System;

namespace Lab1 {
    class Flight {
        public static List<Flight> Flights = new List<Flight>();
        public string Carrier {get; set; }
        public string Code {get; set;}
        public Airport AirportDepart {get; set; }
        public Airport AirportArrive {get; set; }

        public Airplane Airplane {get; set; }
    }
}
