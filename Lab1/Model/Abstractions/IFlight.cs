using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    interface IFlight<Key> : IBase<Key> {
        DateTime StopBooking { get; set; }
        int MinDelayed { get; set; }
        DateTime TimeArrive { get; set; }

        DateTime TimeDepart { get; set; }
        int SeatsCapacity { get {return Route.Airplane.Seats; }}
        IRoute<Key> Route {get; set; }
    }
}

