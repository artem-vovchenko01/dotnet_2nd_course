using System.Collections.Generic;

namespace Lab1 {
    class Airplane {
        public static List<Airplane> Airplanes = new List<Airplane>();
        public string Company {get; set; }
        public string Model {get; set; }
        public int Seats {get; set; }
        public int DefaultPrice {get; set; }
    }
}
