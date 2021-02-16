namespace Lab1 {
    class AirplaneDao : AbstractDao<Airplane>, IAirplaneDao {
       public AirplaneDao(Database database) : base(database) {
           _entities = _db.Airplanes;
       } 
    }
}
