using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    interface ITicket<Key> : IBase<Key> {
        IList<int> SeatsOccupiedList {get; }
        int SeatsOccupied {get; set; }
        int Adults {get; set; }
        int Children {get; set; }
        decimal Price {get; set; }
        Flight Flight {get; set;}
        Passenger Passenger {get; set; }
    }
}
