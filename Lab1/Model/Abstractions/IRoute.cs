using System.Collections.Generic;
using System;

namespace Lab1 {
    interface IRoute<Key> : IBase<Key> {
        string Carrier {get; set; }
        string Code {get; set;}
        IAirport<Key> AirportDepart {get; set; }
        IAirport<Key> AirportArrive {get; set; }
        IAirplane<Key> Airplane {get; set; }
    }
}

