using System.Collections.Generic;

namespace Lab1 {
    class Airport {
        public static List<Airport> Airports = new List<Airport>();
        public string Name {get; set;}
        public string City {get; set; }
        public string Country {get; set;}

        public override string ToString()
        {
            return Name + ", " + City + ", " + Country;
        }
    }
}