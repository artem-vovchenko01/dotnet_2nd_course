using System;

namespace Lab1 {
    class AirplaneDao<Key> : AbstractDao<Airplane<Key>, Key> where Key : IComparable<Key> {
       public AirplaneDao(IDatabase<Key> database) : base(database) {
           _entities =_db.Airplanes;
       } 
    }
}
