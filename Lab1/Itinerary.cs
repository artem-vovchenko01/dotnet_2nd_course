using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class Itinerary {
        public static List<Itinerary> Itineraries = new List<Itinerary>();
        public Ticket Ticket {get {
            return Ticket.Tickets.Where(t => t.Itinerary == this).FirstOrDefault();
        }}
        public List<ScheduledFlight> ScheduledFlights {get {
            return ScheduledFlight.ScheduledFlights.Where(s => s.Itinerary == this).ToList();
        }}
        public int MinDelayed = 0;
    }
}
