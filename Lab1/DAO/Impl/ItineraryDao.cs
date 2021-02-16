namespace Lab1 {
    class ItineraryDao : AbstractDao<Itinerary>, IItineraryDao {
        public ItineraryDao(Database database) : base(database) {
            _entities = _db.Itineraries;
        }
    }
}