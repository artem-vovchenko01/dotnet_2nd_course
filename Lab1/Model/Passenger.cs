using System.Collections.Generic;
using System;

namespace Lab1 
{
    class Passenger<Key> : IBase<Key> where Key : IComparable<Key> {
        public Key Id { get; set; }
        public string Name {get; set;}
        public string Surname {get; set; }
        public long Passport {get; set; }
        public int Age {get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
