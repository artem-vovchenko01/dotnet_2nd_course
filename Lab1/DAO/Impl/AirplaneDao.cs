namespace Lab1 {
    class AirplaneDao : AbstractDao<Airplane> {
       public AirplaneDao(Database database) : base(database) {
           _entities = _db.Airplanes;
       } 
    }
}
