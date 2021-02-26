
namespace Lab1 {
    class FlightDao : AbstractDao<Flight> {
        public FlightDao(Database database) : base(database) {
            _entities = _db.Flights;
        }
    }
}