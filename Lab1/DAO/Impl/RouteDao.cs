namespace Lab1 {
    class RouteDao : AbstractDao<Route>, IRouteDao {
        public RouteDao(Database database) : base (database) {
            _entities = _db.Routes;
        }
    }
}