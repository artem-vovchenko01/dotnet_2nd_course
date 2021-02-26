namespace Lab1 {
    class RouteDao : AbstractDao<Route> {
        public RouteDao(Database database) : base (database) {
            _entities = _db.Routes;
        }
    }
}