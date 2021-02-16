using System.Collections.Generic;
using System;

namespace Lab1 {
    class Database {
        public Database() {
            Passengers = new Dictionary<Guid, Passenger>();
            Flights = new Dictionary<Guid, Flight>();
            Itineraries = new Dictionary<Guid, Itinerary>();
            Airplanes = new Dictionary<Guid, Airplane>();
            Airports = new Dictionary<Guid, Airport>();
            Tickets = new Dictionary<Guid, Ticket>();
            ItineraryFlights = new Dictionary<Guid, ItineraryFlight>();
            Routes = new Dictionary<Guid, Route>();
        }
        
        internal Dictionary<Guid, Passenger> Passengers;
        internal Dictionary<Guid, Flight> Flights;
        internal Dictionary<Guid, Itinerary> Itineraries;
        internal Dictionary<Guid, Airplane> Airplanes;
        internal Dictionary<Guid, Airport> Airports;
        internal Dictionary<Guid, Ticket> Tickets;
        internal Dictionary<Guid, ItineraryFlight> ItineraryFlights;
        internal Dictionary<Guid, Route> Routes;
    }
}
