using System;
using System.Collections.Generic;

namespace Lab1 {
    static class Generator {
        public static void GenerateClients() {
            Client c1 = new Client {Name = "Dmytro", Surname = "Polishchuk", Age = 21,
            Passport = 4383856486};
            Client.Clients.Add(c1);
        }

        public static void GenerateFlights() {
            Airport ataturk = new Airport {Name = "Ataturk", Country = "Turkey", City = "Istanbul"};
            Airport boryspil = new Airport {Name = "Boryspil", Country = "Ukraine", City = "Kyiv"};
            Airport heathrow = new Airport {Name = "Heathrow", Country = "England", City = "London"};
            List<Airport> airports = new List<Airport> {ataturk, boryspil, heathrow};
            airports.ForEach(a => Airport.Airports.Add(a));

            Airplane a1 = new Airplane {Company = "Airbus", Model = "A319", Seats = 130};
            Airplane a2 = new Airplane {Company = "Boeing", Model = "757-200", Seats = 130};
            List<Airplane> airplanes = new List<Airplane> {a1, a2};
            airplanes.ForEach(a => Airplane.Airplanes.Add(a));

            Flight f1 = new Flight {AirportDepart = boryspil, AirportArrive = ataturk, 
            Carrier = "Ukraine Int Air", Code = "PS-713", Airplane = a1};

            Flight f2 = new Flight {AirportDepart = ataturk, AirportArrive = heathrow, 
            Carrier = "Turkish Airlines", Code = "TK-1979", Airplane = a2};

            DateTime departDate1 = new DateTime(2021, 2, 14, 11, 30, 0);
            DateTime arriveDate1 = new DateTime(2021, 2, 14, 14, 30, 0);
            DateTime departDate2 = new DateTime(2021, 2, 15, 8, 50, 0);
            DateTime arriveDate2= new DateTime(2021, 2, 15, 9, 55, 0);
            DateTime limit = new DateTime(2021, 4, 1);
            for (; departDate1 < limit && arriveDate1 < limit && departDate2 < limit && arriveDate2 < limit;) {
                Itinerary itinerary = new Itinerary();
                ScheduledFlight flight = new ScheduledFlight {Flight = f1, Itinerary = itinerary, TimeArrive = arriveDate1, TimeDepart = departDate1 };
                ScheduledFlight flight2 = new ScheduledFlight {Flight = f2, Itinerary = itinerary, TimeArrive = arriveDate2, TimeDepart = departDate2};
                ScheduledFlight.ScheduledFlights.Add(flight);
                ScheduledFlight.ScheduledFlights.Add(flight2);
                departDate1 = departDate1.AddDays(2);
                arriveDate1 = arriveDate1.AddDays(2);
                departDate2 = departDate2.AddDays(2);
                arriveDate2 = arriveDate2.AddDays(2);
            }

        }

        public static void GenerateTickets() {
            
        }

        public static void GenerateAll() {
            GenerateClients();
            GenerateFlights();
            GenerateTickets();

        }

    }
}