using System;

namespace Lab1 {
    interface IRouteDao<Key> : IAbstractDao<Route<Key>, Key> where Key : IComparable<Key> {

    }
}

