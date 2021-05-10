using System.Collections.Generic;
using System;

namespace Lab1 {
    interface IAirplane<Key> : IBase<int> {
        string Company {get; set; }
        string Model {get; set; }
        int Seats {get; set; }
        int DefaultPrice {get; set; }
    }
}

