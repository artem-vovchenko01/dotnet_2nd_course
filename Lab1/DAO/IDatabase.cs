using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IDatabase<Key> where Key : IComparable<Key> {
        Key keySeed { get; }
        Func<Key, Key> keyGenerator { get;}
        IDictionary<Key, Passenger<Key>> Passengers { get; }
        IDictionary<Key, Flight<Key>> Flights { get; }
        IDictionary<Key, Airplane<Key>> Airplanes { get; }
        IDictionary<Key, Airport<Key>> Airports { get; }
        IDictionary<Key, Ticket<Key>> Tickets { get; }
        IDictionary<Key, Route<Key>> Routes { get; }
    }
}
