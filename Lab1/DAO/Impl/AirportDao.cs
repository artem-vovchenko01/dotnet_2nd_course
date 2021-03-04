using System;

namespace Lab1 {
    class AirportDao: AbstractDao<Airport<int>, int>, IAirportDao<int> {
        public AirportDao(IDatabase<int> database) : base(database) {_entities = _db.Airports; }
    }
}
