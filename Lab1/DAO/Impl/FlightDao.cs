using System;

namespace Lab1 {
    class FlightDao: AbstractDao<Flight, int>, IFlightDao {
        public FlightDao(IDatabase<int> database) : base(database) {
            _entities = _db.Flights;
        }
    }
}
