
namespace Lab1 {
    class FlightDao : AbstractDao<Flight>, IFlightDao {
        public FlightDao(Database database) : base(database) {
            _entities = _db.Flights;
        }
    }
}