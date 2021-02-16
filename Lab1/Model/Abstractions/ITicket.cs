namespace Lab1 {
    interface ITicket {
        int SeatsOccupied { get; set; }
        int Adults { get; set; }
        int Children { get; set; }
        decimal Price { get; set; }
        Flight Flight { get; set; }
        Passenger Passenger { get; set; }
    }
}
