using System.Collections.Generic;
using System;

namespace Lab1 {
    interface IAirport<Key> : IBase<Key> {
        string Name {get; set;}
        string City {get; set; }
        string Country {get; set;}
    }
}