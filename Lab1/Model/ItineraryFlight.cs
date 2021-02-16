using System;

namespace Lab1 {
    class ItineraryFlight : IBase {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public Flight Flight { get; set; }
        public Itinerary Itinerary { get; set; }
    }
}