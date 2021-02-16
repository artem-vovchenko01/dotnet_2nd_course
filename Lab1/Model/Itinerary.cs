using System.Collections.Generic;
using System;
using System.Linq;

namespace Lab1 {
    class Itinerary : IFlight, IBase {
        public Guid Id { get; set; }
        DateTime TimeDeparture { get; set; }
        DateTime TimeArrive { get; set; }
    }
}
