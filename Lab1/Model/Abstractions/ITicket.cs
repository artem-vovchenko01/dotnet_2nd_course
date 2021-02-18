using System.Collections.Generic;

namespace Lab1 {
    interface ITicket {
        int SeatsOccupied { get; set; }
        List<int> SeatsOccupiedList { get; }
        int Adults { get; set; }
        int Children { get; set; }
        decimal Price { get; set; }
        IFlight Flight { get; set; }
        Passenger Passenger { get; set; }
    }
}
