using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class ScheduledFlight {
        public int SeatsAvailable  {get {
            int occupied = 0;
            foreach (Ticket t in SoldTickets) {
                occupied += t.SeatsOccupied;
            }
            return Flight.Airplane.Seats - occupied;
        }}
        
        public int SoldTicketsCount {get {
            return Ticket.Tickets.Where(t => t.ScheduledFlight == this).Count();
        }}
        public List<Ticket> SoldTickets {get {
            return Ticket.Tickets.Where(t => t.ScheduledFlight == this).ToList();
        }}
        public DateTime StopBooking {
            get { return _stopBooking == DateTime.MaxValue ? TimeDepart : _stopBooking; } 
            set {_stopBooking = value; } 
        }
        public int MinDelayed = 0;
        public static List<ScheduledFlight> ScheduledFlights = new List<ScheduledFlight>();
        public Ticket Ticket {get {
            return Ticket.Tickets.Where(t => t.ScheduledFlight == this).FirstOrDefault();
        }}
        public DateTime TimeArrive {
            get { 
                if (Itinerary != null && Itinerary.MinDelayed != 0) return _timeArrive.AddMinutes(Itinerary.MinDelayed);
                else return MinDelayed == 0 ? _timeArrive : _timeArrive.AddMinutes(MinDelayed);
            }
            set {_timeArrive = value; } 
        }

        public DateTime TimeDepart {
        get {
           if (Itinerary != null && Itinerary.MinDelayed != 0) return _timeDepart.AddMinutes(Itinerary.MinDelayed);
           else return MinDelayed == 0 ? _timeDepart : _timeDepart.AddMinutes(MinDelayed);
        }
        set {_timeDepart = value; } 
        }

        public Itinerary Itinerary {get; set; }
        public Flight Flight {get; set; }
        private DateTime _timeDepart;
        private DateTime _timeArrive;
        private DateTime _stopBooking = DateTime.MaxValue;
    }
}
