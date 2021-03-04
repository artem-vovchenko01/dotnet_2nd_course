using System;

namespace Lab1 {
    class RouteDao<Key> : AbstractDao<Route<Key>, Key> where Key : IComparable<Key> {
        public RouteDao(IDatabase<Key> database) : base (database) {
            _entities = _db.Routes;
        }
    }
}