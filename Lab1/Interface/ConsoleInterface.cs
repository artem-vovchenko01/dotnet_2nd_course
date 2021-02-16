using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class ConsoleInterface : IInterface {
        private DaoFactory db;
        private ConsoleFlightFilter flightFilter;
        private ItineraryService itineraryService;
        public ConsoleInterface(DaoFactory factory) {
            db = factory;
            itineraryService = new ItineraryService(db);
        }
        public void Begin() {
            flightFilter = new ConsoleFlightFilter(db);
            string inp = "";
            bool done = false;
        while (! done) {
        PrintMenu();
        inp = Console.ReadLine();
        List<IFlight> flights = new List<IFlight>();
        IFlight flight = null;
        Flight flightOnly = null;
        switch (inp.Trim()) {
            case "q": 
            done = true;
            break;
            case "1":
                flights = new List<IFlight>();
                db.FlightDao.GetAll().ForEach(f => flights.Add(f));
                db.ItineraryDao.GetAll().ForEach(i => flights.Add(i));
                flights = flightFilter.Filter(flights);
                ShowFlights(flights);
                break;
            case "2":
                flights = new List<IFlight>();
                db.FlightDao.GetAll().ForEach(f => flights.Add(f));
                ShowFlights(flightFilter.Filter(flights));
                while (true) {
                    flightOnly = (Flight) ChooseFlight(flights);
                    if(DelayFlight(flightOnly)) break;
                    else if (! AskRepeat()) break;
                }
                break;
            // case "3":
            //     flights = flightFilter.Filter(db.FlightDao.GetAll());
            //     ShowFlights(flights);
            //     while (true) {
            //         flightOnly = (Flight) ChooseFlight(flights);
            //         if (ChangeBookingDeadline(flight)) break;
            //         else if (! AskRepeat()) break;
            //     }
            //     break;
        }
        }
        }

        public void ShowSoldTickets(IFlight flight) {
            // int sold = Ticket.SoldTickets(flight);
            // int all = flight.Flight.Airplane.Seats;
            // int avail = all - sold;
            // Console.WriteLine($"All tickets: {all}. ");  
            // Console.WriteLine($"Tickets sold: {sold}, available: {avail}");
            // int n = 1;
            // foreach(Ticket t in Ticket.FlightTickets(flight)) {
            //     Console.WriteLine($"\nTicket {n}: ");
            //     Console.WriteLine($"Passenger: {t.Client}");
            //     Console.WriteLine($"");
            // }
        }
        public bool ChangeBookingDeadline(Flight flight) {
            Console.WriteLine($"Current deadline: {flight.StopBooking}. Departure time: {flight.TimeDepart}. ");
            Console.WriteLine("New deadline (yyyy mm dd hh ss). Should not be greater then departure time. Default - don't change anything:");
            Console.Write("Your input: ");
            string dateStr = Console.ReadLine();
            string[] split = dateStr.Split(' ');
            if (dateStr == "") {
                Console.WriteLine("Backing up to default. Date unchanged. ");
                return true;
            }
            else {
                try {
                    DateTime date = new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]),
                    int.Parse(split[3]), int.Parse(split[4]), int.Parse(split[5]));
                    if (date <= flight.TimeDepart) {
                        flight.StopBooking = date;
                        Console.WriteLine($"Success! New date: {flight.StopBooking}" );
                        return true;
                    }
                    else Console.WriteLine("Cannot set date further than departure time. Date unchanged. ");
                } catch { Console.WriteLine("Wrong format. Date unchanged. "); }
            }
            return false;
        }
        public bool DelayFlight(Flight flight) {
            Console.WriteLine($"Flight departures at {flight.TimeDepart}. Current delay is: {flight.MinDelayed}.");
            Console.Write("New delay (in minutes): ");
            int min;
            try {
                min = int.Parse(Console.ReadLine());
            } catch {
                Console.WriteLine("Wrong format. Delay unchanged. ");
                return false;
            }
            flight.MinDelayed = min;
            Console.WriteLine($"Success! New departure time: {flight.TimeDepart} ");
            return true;
        }
        public void ShowFlights(List<IFlight> flights) {
            int idx = 0;
            foreach (IFlight f in flights) {
                Console.WriteLine(idx + 1);
                if (f is Flight) {
                Console.WriteLine("Departure: " + (f as Flight).TimeDepart);
                Console.WriteLine("Arrival: " + (f as Flight).TimeArrive);
                Console.WriteLine("From: " + (f as Flight).Route.AirportDepart);
                Console.Write("To: " + (f as Flight).Route.AirportArrive);
                }
                if (f is Itinerary) {
                    Route itRoute = itineraryService.GetItineraryRoute(f as Itinerary);
                    Console.WriteLine("Departure: " + itineraryService.TimeDeparture(f as Itinerary));
                    Console.WriteLine("Arrival: " + itineraryService.TimeArrive(f as Itinerary));
                    Console.WriteLine("From: " + itRoute.AirportDepart);
                    Console.Write("To: " + itRoute.AirportArrive);
                    Console.WriteLine("It is an itinerary. Contains " + itineraryService.StopCount(f as Itinerary) + " stops ");
                }
                idx++;
            }
        }

        private IFlight ChooseFlight(List<IFlight> flights) {
            int max = flights.Count;
            Console.Write($"Choose flight (by number): ");
            string inp = Console.ReadLine();
            int choice = int.Parse(inp);
            return flights[choice - 1];
        }

        private bool AskRepeat() {
            Console.WriteLine("Do you want to try again? (y / N) ");
            string inp = Console.ReadLine();
            return inp.StartsWith("y") || inp.StartsWith("Y");
        }

        // private List<IFlight> FilterFlights(List<IFlight> flights, IFlightFilter filter)  

        private void PrintMenu() {
            Console.WriteLine("You're in the main menu. Choose action: ");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("| 1 - Show flights");
            Console.WriteLine("| 2 - Set or cancel flight delay");
            Console.WriteLine("| 3 - Change booking deadline");
            Console.WriteLine("| 4 - Show sold tickets ");
            Console.WriteLine("| q - Quit");
            Console.WriteLine(new string('-', 30));
        }
    }
}