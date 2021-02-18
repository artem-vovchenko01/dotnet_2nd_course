using System.Collections.Generic;

namespace Lab1 {
    interface IInterface {
        void Begin();
        bool ChangeBookingDeadline(IFlight flight);
        bool DelayFlight(IFlight flight); 
        void ShowFlights(List<IFlight> flights);
        void ShowSoldTickets(IFlight flight);
    }
}
