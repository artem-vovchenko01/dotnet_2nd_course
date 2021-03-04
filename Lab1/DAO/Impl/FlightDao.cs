using System;

namespace Lab1 {
    class FlightDao<Key> : AbstractDao<Flight<Key>, Key> where Key : IComparable<Key> {
        public FlightDao(IDatabase<Key> database) : base(database) {
            _entities = _db.Flights;
        }
    }
}