using System.Collections.Generic;
using System;

namespace Lab1 {
    class Airplane : IBase {
        public Guid Id { get; set; }
        public string Company {get; set; }
        public string Model {get; set; }
        public int Seats {get; set; }
        public int DefaultPrice {get; set; }
    }
}
