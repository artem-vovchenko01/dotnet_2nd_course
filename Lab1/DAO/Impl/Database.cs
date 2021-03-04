using System.Collections.Generic;
using System;

namespace Lab1 {
    class Database<Key> : IDatabase<Key> where Key : IComparable<Key> {
        public Key keySeed { get; private set; }
        public Func<Key, Key> keyGenerator { get; private set; }
        public Database(Key keySeed, Func<Key, Key> keyGenerator) {
            this.keySeed = keySeed;
            this.keyGenerator = keyGenerator;
            Passengers = new Dictionary<Key, Passenger<Key>>();
            Flights = new Dictionary<Key, Flight<Key>>();
            Airplanes = new Dictionary<Key, Airplane<Key>>();
            Airports = new Dictionary<Key, Airport<Key>>();
            Tickets = new Dictionary<Key, Ticket<Key>>();
            Routes = new Dictionary<Key, Route<Key>>();
        }
        
        public IDictionary<Key, Passenger<Key>> Passengers { get; private set; }
        public IDictionary<Key, Flight<Key>> Flights { get; private set; }
        public IDictionary<Key, Airplane<Key>> Airplanes { get; private set; }
        public IDictionary<Key, Airport<Key>> Airports { get; private set; }
        public IDictionary<Key, Ticket<Key>> Tickets { get; private set; }
        public IDictionary<Key, Route<Key>> Routes { get; private set; }
    }
}
