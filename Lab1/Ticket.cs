using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class Ticket {
        public static int AdultAddPrice = 50;
        public static int ChildrenAddPrice = 10;
        public static List<Ticket> Tickets = new List<Ticket>();
        private Ticket() {}
        public static Ticket GetNewTicket(Client client, int adults, int children, List<int> seats, Itinerary itinerary = null, ScheduledFlight flight = null) {
                int sold;
                int avail;

            if ( itinerary == null && flight != null) {
            if (seats.Count != adults + children) return null;
                avail = flight.SeatsAvailable;
                if (seats.Count <= avail && DateTime.Today <= flight.StopBooking )
                return new Ticket {ScheduledFlight = flight, SeatsOccupiedList = seats, Adults = adults, Children = children, Client = client, SeatsOccupied = seats.Count, Price = flight.Flight.Airplane.DefaultPrice + (adults - 1) * AdultAddPrice + children * ChildrenAddPrice};
            }

            else if (flight == null && itinerary != null) {
                
                foreach (ScheduledFlight f in flight.Itinerary.ScheduledFlights) {
                    sold = f.SoldTicketsCount;
                    if (sold > f.Flight.Airplane.Seats || DateTime.Today > f.StopBooking) break;
                }
                return new Ticket {Itinerary = itinerary};
            }
            return null;
        }
        public List<int> SeatsOccupiedList {get {return _seatsOccupiedList; } private set {
            foreach(int seat in value) _seatsOccupiedList.Add(seat);
        }}
        public int SeatsOccupied {get; private set; }
        public int Adults {get; private set; }
        public int Children {get; private set; }
        public decimal Price {get; set; }
        public Itinerary Itinerary {get; private set; }
        public ScheduledFlight ScheduledFlight {get; private set;}
        public Client Client {get; private set; }
        private List<int> _seatsOccupiedList = new List<int>();
    }
}
