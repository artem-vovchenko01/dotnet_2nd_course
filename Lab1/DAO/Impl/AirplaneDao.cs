using System;

namespace Lab1 {
    class AirplaneDao: AbstractDao<Airplane, int>, IAirplaneDao {
       public AirplaneDao(IDatabase<int> database) : base(database) {
           _entities =_db.Airplanes;
       } 
    }
}
