using System;

namespace Lab1 {
    class AirportDao<Key> : AbstractDao<Airport<Key>, Key> where Key : IComparable<Key> {
        public AirportDao(IDatabase<Key> database) : base(database) {_entities = _db.Airports; }
    }
}
