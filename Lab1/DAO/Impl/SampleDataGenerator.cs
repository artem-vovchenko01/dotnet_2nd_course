using System;
using System.Collections.Generic;

namespace Lab1 {
    class SampleDataGenerator {
        private DaoFactory db;
        private FlightService flightService;
        public SampleDataGenerator(DaoFactory factory) {
            db = factory;
            flightService = new FlightService(db);
        }
        public void GeneratePassengers() {
            Passenger p1 = new Passenger {Name = "Dmytro", Surname = "Polishchuk", Age = 21,
            Passport = 4383856486};
            db.PassengerDao.Add(p1);
        }

        public void GenerateFlights() {
            Airport ataturk = new Airport {Name = "Ataturk", Country = "Turkey", City = "Istanbul"};
            Airport boryspil = new Airport {Name = "Boryspil", Country = "Ukraine", City = "Kyiv"};
            Airport heathrow = new Airport {Name = "Heathrow", Country = "England", City = "London"};
            List<Airport> airports = new List<Airport> {ataturk, boryspil, heathrow};
            airports.ForEach(a => db.AirportDao.Add(a));

            Airplane a1 = new Airplane {Company = "Airbus", Model = "A319", Seats = 130};
            Airplane a2 = new Airplane {Company = "Boeing", Model = "757-200", Seats = 130};
            List<Airplane> airplanes = new List<Airplane> {a1, a2};
            airplanes.ForEach(a => db.AirplaneDao.Add(a));

            Route r1 = new Route {AirportDepart = boryspil, AirportArrive = ataturk, 
            Carrier = "Ukraine Int Air", Code = "PS-713", Airplane = a1};

            Route r2 = new Route {AirportDepart = ataturk, AirportArrive = heathrow, 
            Carrier = "Turkish Airlines", Code = "TK-1979", Airplane = a2};

            DateTime departDate1 = new DateTime(2021, 2, 14, 11, 30, 0);
            DateTime arriveDate1 = new DateTime(2021, 2, 14, 14, 30, 0);
            DateTime departDate2 = new DateTime(2021, 2, 15, 8, 50, 0);
            DateTime arriveDate2= new DateTime(2021, 2, 15, 9, 55, 0);
            DateTime limit = new DateTime(2021, 4, 1);
            for (; departDate1 < limit && arriveDate1 < limit && departDate2 < limit && arriveDate2 < limit;) {
                Flight flight = new Flight {Route = r1, TimeArrive = arriveDate1, TimeDepart = departDate1 };
                Flight flight2 = new Flight {Route = r2, TimeArrive = arriveDate2, TimeDepart = departDate2};
                db.FlightDao.Add(flight);
                db.FlightDao.Add(flight2);
                departDate1 = departDate1.AddDays(2);
                arriveDate1 = arriveDate1.AddDays(2);
                departDate2 = departDate2.AddDays(2);
                arriveDate2 = arriveDate2.AddDays(2);
            }

        }

        public void GenerateTickets() {
            Random r = new Random();
            r.Next(3);
            int adults, children, flightIdx, passengerIdx;
            Passenger passenger;
            Flight flight;
            List<int> seats;
            List<int> seatsAvail;
            Ticket ticket;

            for (int i=0; i<500; i++) {
                adults = r.Next(3) + 1;
                children = r.Next(2);
                flightIdx = r.Next(db.FlightDao.GetAll().Count);
                passengerIdx = r.Next(db.PassengerDao.GetAll().Count);
                passenger = db.PassengerDao.GetAll()[passengerIdx];
                flight = db.FlightDao.GetAll()[flightIdx];
                seatsAvail = flightService.SeatsAvailable(flight);
                seats = new List<int>();
                if (adults > seatsAvail.Count || DateTime.Now > flight.TimeDepart) continue;
                while (seats.Count != adults) seats.Add(seatsAvail[ r.Next(seatsAvail.Count) ]);
                ticket = Ticket.GetNewTicket(passenger, adults, children, seats, flight, db);
                db.TicketDao.Add(ticket);
            }
        }

        public void GenerateAll() {
            GeneratePassengers();
            GenerateFlights();
            GenerateTickets();
        }

    }
}