using System.Collections.Generic;
using System;

namespace Lab1 {
    class Airplane<Key> : IBase<Key> where Key : IComparable<Key> {
        public Key Id { get; set; }
        public string Company {get; set; }
        public string Model {get; set; }
        public int Seats {get; set; }
        public int DefaultPrice {get; set; }
    }
}
