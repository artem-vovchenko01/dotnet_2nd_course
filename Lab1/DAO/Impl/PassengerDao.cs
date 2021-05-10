using System.Collections.Generic;
using System;

namespace Lab1 {
    class PassengerDao : AbstractDao<Passenger, int>, IPassengerDao {
        public PassengerDao(IDatabase<int> database) : base(database) {
            _entities = _db.Passengers;
        }
    }
}
