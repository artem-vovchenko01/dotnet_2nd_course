using System.Collections.Generic;

namespace Lab1 {
    interface IInterface {
        void Begin();
        bool ChangeBookingDeadline(Flight flight);
        bool DelayFlight(Flight flight); 
        void ShowFlights(List<IFlight> flights);
        // void ShowSoldTickets(IFlight flight);
    }
}
