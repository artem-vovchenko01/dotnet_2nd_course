using System;

namespace Lab1 {
    class RouteDao : AbstractDao<Route<int>, int>, IRouteDao<int> {
        public RouteDao(IDatabase<int> database) : base (database) {
            _entities = _db.Routes;
        }
    }
}