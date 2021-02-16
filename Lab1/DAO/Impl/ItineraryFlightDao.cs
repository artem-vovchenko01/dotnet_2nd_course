namespace Lab1 {
    class ItineraryFlightDao : AbstractDao<ItineraryFlight>, IItineraryFlightDao {
        public ItineraryFlightDao(Database database) : base(database) {
            _entities = _db.ItineraryFlights;
        }

    }
}