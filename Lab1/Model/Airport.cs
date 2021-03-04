using System.Collections.Generic;
using System;

namespace Lab1 {
    class Airport<Key> : IBase<Key> where Key : IComparable<Key> {
        public Key Id { get; set; }
        public string Name {get; set;}
        public string City {get; set; }
        public string Country {get; set;}

        public override string ToString()
        {
            return Name + ", " + City + ", " + Country;
        }
    }
}