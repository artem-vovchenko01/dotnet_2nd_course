using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IDatabase<Key> {
        Key keySeed { get; }
        Func<Key, Key> keyGenerator { get;}
        IDictionary<Key, IPassenger<Key>> Passengers { get; }
        IDictionary<Key, IFlight<Key>> Flights { get; }
        IDictionary<Key, IAirplane<Key>> Airplanes { get; }
        IDictionary<Key, IAirport<Key>> Airports { get; }
        IDictionary<Key, ITicket<Key>> Tickets { get; }
        IDictionary<Key, IRoute<Key>> Routes { get; }
    }
}
