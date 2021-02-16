
namespace Lab1 {
    class AirportDao : AbstractDao<Airport>, IAirportDao {
        public AirportDao(Database database) : base(database) {_entities = _db.Airports; }
    }
}
