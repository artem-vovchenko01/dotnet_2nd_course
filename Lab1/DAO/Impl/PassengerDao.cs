using System.Collections.Generic;
using System;

namespace Lab1 {
    class PassengerDao : AbstractDao<Passenger>, IPassengerDao {
        public PassengerDao(Database database) : base(database) {
            _entities = _db.Passengers;
        }
    }
}
