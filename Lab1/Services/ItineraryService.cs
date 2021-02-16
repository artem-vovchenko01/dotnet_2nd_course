using System.Collections.Generic;
using System.Linq;
using System;

namespace Lab1 {
    class ItineraryService {
        private DaoFactory db;
        private TicketService ticketService;
        public ItineraryService(DaoFactory factory) {
            db = factory;
            ticketService = new TicketService(db);
        }

        public Route GetItineraryRoute(Itinerary itinerary) {
            List<ItineraryFlight> connections = db.ItineraryFlightDao.GetAll().Where(c => c.Itinerary == itinerary).ToList();
            ItineraryFlight start = connections.Where(c => c.Order == 1).First();
            ItineraryFlight end = connections.Where(c => c.Order == connections.Count()).First();
            return new Route {Airplane = null, AirportArrive = start.Flight.Route.AirportDepart,
            AirportDepart = end.Flight.Route.AirportArrive};
        }

        public int StopCount(Itinerary itinerary) {
            return db.ItineraryFlightDao.GetAll().Where(c => c.Itinerary == itinerary).Count();
        }

        public DateTime TimeDeparture(IFlight flight) {
            Flight f; 
            Itinerary i;
            if (flight is Flight) {
                f = flight as Flight;
                return f.TimeDepart;
            } else {
                i = flight as Itinerary;
                List<ItineraryFlight> connections = db.ItineraryFlightDao.GetAll().Where(c => c.Itinerary == i).ToList();
                ItineraryFlight start = connections.Where(c => c.Order == 1).First();
                return start.Flight.TimeDepart;
            }
        }

        public DateTime TimeArrive(IFlight flight) {
            Flight f; 
            Itinerary i;
            if (flight is Flight) {
                f = flight as Flight;
                return f.TimeArrive;
            } else {
                i = flight as Itinerary;
                List<ItineraryFlight> connections = db.ItineraryFlightDao.GetAll().Where(c => c.Itinerary == i).ToList();
                ItineraryFlight end = connections.Where(c => c.Order == connections.Count()).First();
                return end.Flight.TimeArrive;
            }
        }
    }
}
