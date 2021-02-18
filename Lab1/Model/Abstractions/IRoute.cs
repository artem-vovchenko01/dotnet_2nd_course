namespace Lab1 {
    interface IRoute {
        Airport AirportArrive { get; set; }
        Airport AirportDepart { get; set; }
        Airplane Airplane { get; set; }
    }
}
