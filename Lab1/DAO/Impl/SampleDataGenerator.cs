using System;
using System.Collections.Generic;

namespace Lab1 {
    class SampleDataGenerator<Key> where Key : IComparable<Key> {
        private IDaoFactory<Key> db;
        private IFlightService<Key> flightService;
        public SampleDataGenerator(IDaoFactory<Key> factory) {
            db = factory;
            flightService = new FlightService<Key>(db);
        }
        public void GeneratePassengers() {
            Passenger<Key> p1 = new Passenger<Key> {Name = "Dmytro", Surname = "Polishchuk", Age = 21,
            Passport = 4383856486};
            Passenger<Key> p2 = new Passenger<Key> {Name = "Kateryna", Surname = "Ivanenko", Age = 19,
            Passport = 4873638596};
            List<Passenger<Key>> passengers = new List<Passenger<Key>>{p1, p2};
            passengers.ForEach(p => db.PassengerDao.Add(p));
        }

        public void GenerateFlights() {
            Airport<Key> ataturk = new Airport<Key> {Name = "Ataturk", Country = "Turkey", City = "Istanbul"};
            Airport<Key> boryspil = new Airport<Key> {Name = "Boryspil", Country = "Ukraine", City = "Kyiv"};
            Airport<Key> heathrow = new Airport<Key> {Name = "Heathrow", Country = "England", City = "London"};
            List<Airport<Key>> airports = new List<Airport<Key>> {ataturk, boryspil, heathrow};
            airports.ForEach(a => db.AirportDao.Add(a));

            Airplane<Key> a1 = new Airplane<Key> {Company = "Airbus", Model = "A319", Seats = 130, DefaultPrice = 100};
            Airplane<Key> a2 = new Airplane<Key> {Company = "Boeing", Model = "757-200", Seats = 130, DefaultPrice = 250};
            List<Airplane<Key>> airplanes = new List<Airplane<Key>> {a1, a2};
            airplanes.ForEach(a => db.AirplaneDao.Add(a));

            Route<Key> r1 = new Route<Key> {AirportDepart = boryspil, AirportArrive = ataturk, 
            Carrier = "Ukraine Int Air", Code = "PS-713", Airplane = a1};

            Route<Key> r2 = new Route<Key> {AirportDepart = ataturk, AirportArrive = heathrow, 
            Carrier = "Turkish Airlines", Code = "TK-1979", Airplane = a2};

            DateTime departDate1 = new DateTime(2021, 2, 24, 11, 30, 0);
            DateTime arriveDate1 = new DateTime(2021, 2, 24, 14, 30, 0);
            DateTime departDate2 = new DateTime(2021, 2, 25, 8, 50, 0);
            DateTime arriveDate2 = new DateTime(2021, 2, 25, 9, 55, 0);
            DateTime limit = new DateTime(2021, 4, 1);
            for (; departDate1 < limit && arriveDate1 < limit && departDate2 < limit && arriveDate2 < limit;) {
                Flight<Key> flight = new Flight<Key> {Route = r1, TimeArrive = arriveDate1, TimeDepart = departDate1 };
                Flight<Key> flight2 = new Flight<Key> {Route = r2, TimeArrive = arriveDate2, TimeDepart = departDate2};
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
            Passenger<Key> passenger;
            Flight<Key> flight;
            IList<int> seats;
            IList<int> seatsAvail;
            Ticket<Key> ticket;

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
                ticket = Ticket<Key>.GetNewTicket(passenger, adults, children, seats, flight, db);
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