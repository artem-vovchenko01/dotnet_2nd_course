using System.Collections.Generic;

namespace Lab1 {
    interface IInterface {
        void Begin();
        bool ChangeBookingDeadline(Flight flight);
        bool DelayFlight(Flight flight); 
        void ShowFlights(List<Flight> flights);
        void ShowSoldTickets(Flight flight);
    }
}
