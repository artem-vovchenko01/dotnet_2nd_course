using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class Ticket : ITicket, IBase {
        public Guid Id { get; set; }
        private Ticket() {}
        // public static Ticket GetNewTicket(Passenger client, int adults, int children, List<int> seats, Flight flight) {
        //         int sold;
        //         int avail;
        //     if (seats.Count != adults + children) return null;
        //         avail = flight.SeatsAvailable;
        //         if (seats.Count <= avail && DateTime.Today <= flight.StopBooking )
        //         return new Ticket {ScheduledFlight = flight, SeatsOccupiedList = seats, Adults = adults, Children = children, Client = client, SeatsOccupied = seats.Count, Price = flight.Flight.Airplane.DefaultPrice + (adults - 1) * AdultAddPrice + children * ChildrenAddPrice};
        //     }
        //     return null;
        // }
        public List<int> SeatsOccupiedList {get {return _seatsOccupiedList; } private set {
            foreach(int seat in value) _seatsOccupiedList.Add(seat);
        }}
        public int SeatsOccupied {get; set; }
        public int Adults {get; set; }
        public int Children {get; set; }
        public decimal Price {get; set; }
        public Flight Flight {get; set;}
        public Passenger Passenger {get; set; }
        private List<int> _seatsOccupiedList = new List<int>();
    }
}
