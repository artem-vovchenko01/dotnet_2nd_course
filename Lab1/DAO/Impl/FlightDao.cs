using System;

namespace Lab1 {
    class FlightDao: AbstractDao<Flight<int>, int>, IFlightDao<int> {
        public FlightDao(IDatabase<int> database) : base(database) {
            _entities = _db.Flights;
        }
    }
}
