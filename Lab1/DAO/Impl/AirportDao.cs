using System;

namespace Lab1 {
    class AirportDao: AbstractDao<Airport, int>, IAirportDao {
        public AirportDao(IDatabase<int> database) : base(database) {_entities = _db.Airports; }
    }
}
