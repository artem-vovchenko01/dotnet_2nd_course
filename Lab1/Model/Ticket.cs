using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class Ticket<Key> : IBase<Key> where Key : IComparable<Key> {
        public Key Id { get; set; }
        private Ticket() {}
        public static Ticket<Key> GetNewTicket(Passenger<Key> passenger, int adults, int children, IList<int> seats, Flight<Key> flight, IDaoFactory<Key> db) {
            IFlightService<Key> flightService = new FlightService<Key>(db);
            int avail;
            int adultAddPrice = 50, childrenAddPrice = 20;
            if (seats.Count != adults || children > adults || DateTime.Today > flight.StopBooking) return null;
            avail = flightService.SeatsAvailableCount(flight);
            foreach (int i in seats) if (! flightService.IsSeatAvailable(flight, i)) return null;
            return new Ticket<Key> {Flight = flight, SeatsOccupiedList = seats, Adults = adults, Children = children, Passenger = passenger, SeatsOccupied = seats.Count, Price = flight.Route.Airplane.DefaultPrice + (adults - 1) * adultAddPrice + children * childrenAddPrice};
        }
        public IList<int> SeatsOccupiedList {get {return _seatsOccupiedList; } private set {
            foreach(int seat in value) _seatsOccupiedList.Add(seat);
        }}
        public int SeatsOccupied {get; set; }
        public int Adults {get; set; }
        public int Children {get; set; }
        public decimal Price {get; set; }
        public Flight<Key> Flight {get; set;}
        public Passenger<Key> Passenger {get; set; }
        private IList<int> _seatsOccupiedList = new List<int>();
        public override string ToString()
        {
            return "Passenger: " + Passenger + ", SeatsOccupied: " + SeatsOccupied + ", Adults: " + Adults + 
            ", Children: " + Children + ", Price: " + Price + ", Flight: " + Flight + ", SeatsOccupiedList: " + SeatsOccupiedList;
        }
    }
}
