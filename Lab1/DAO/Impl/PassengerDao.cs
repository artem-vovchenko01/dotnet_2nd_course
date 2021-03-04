using System.Collections.Generic;
using System;

namespace Lab1 {
    class PassengerDao<Key> : AbstractDao<Passenger<Key>, Key> where Key : IComparable<Key> {
        public PassengerDao(IDatabase<Key> database) : base(database) {
            _entities = _db.Passengers;
        }
    }
}
