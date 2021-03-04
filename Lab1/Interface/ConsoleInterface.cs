using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class ConsoleInterface : IInterface<int> {
        private IDaoFactory<int> db;
        private IFlightFilter<int> flightFilter;
        private ITicketService<int> ticketService;
        private IFlightService<int> flightService;
        public ConsoleInterface(IDaoFactory<int> factory) {
            db = factory;
            ticketService = new TicketService(factory);
            flightService = new FlightService(factory);
        }
        public void Begin() {
            flightFilter = new ConsoleFlightFilter(db);
            string inp = "";
            bool done = false;
            IList<Flight<int>> flights = new List<Flight<int>>();
            while (! done) {
                PrintMenu();
                inp = Console.ReadLine();
                switch (inp.Trim()) {
                    case "q": 
                        done = true;
                    break;
                    case "1":
                        flights = flightFilter.Filter(db.FlightDao.GetAll());
                        ShowFlights(flights);
                        break;
                    case "2":
                        MenuDelayFlight();
                        break;
                    case "3":
                        MenuChangeBookingDeadline();
                        break;
                    case "4":
                        MenuShowSoldTickets();
                        break;
                    case "5": 
                        foreach(Ticket<int> t in db.TicketDao.GetAll()) PrinTicket(t);
                        break;
                    }
            }
        }

        private void MenuDelayFlight() {
            Flight<int> flight;
            IList<Flight<int>> flights = flightFilter.Filter(db.FlightDao.GetAll());
            ShowFlights(flights);
            while (true) {
                flight =  ChooseFlight(flights);
                if(DelayFlight(flight)) break;
                else if (! AskRepeat()) break;
            }
        }
        private void MenuChangeBookingDeadline() {
            IList<Flight<int>> flights = flightFilter.Filter(db.FlightDao.GetAll());
            ShowFlights(flights);
            Flight<int> flight;
            while (true) {
                flight = ChooseFlight(flights);
                if (ChangeBookingDeadline(flight)) break;
                else if (! AskRepeat()) break;
            }
        }
        private void MenuShowSoldTickets() {
            IList<Flight<int>> flights = flightFilter.Filter(db.FlightDao.GetAll());
            ShowFlights(flights);
            Flight<int> flight = ChooseFlight(flights);
            ShowSoldTickets(flight);
        }
        public void ShowSoldTickets(Flight<int> flight) {
            int sold = ticketService.SoldTicketsCount(flight);
            int all = flight.SeatsCapacity;
            int avail = flightService.SeatsAvailableCount(flight);
            Console.WriteLine($"All seats: {all}, available seats: {avail} ");  
            Console.WriteLine($"Tickets sold: {sold} ");
            int n = 1;
            foreach(Ticket<int> t in ticketService.SoldTickets(flight)) {
                Console.WriteLine($"\nTicket {n}: ");
                PrinTicket(t);
                n++;
            }
        }
        private void PrinTicket(Ticket<int> t) {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Passenger: {t.Passenger}");
            Console.WriteLine($"Adults: {t.Adults}, children: {t.Children}");
            Console.WriteLine($"Price: {t.Price}");
            Console.WriteLine($"Departure from: {t.Flight.Route.AirportDepart}");
            Console.WriteLine($"Destination: {t.Flight.Route.AirportArrive}");
            Console.WriteLine($"Departuring date: {t.Flight.TimeDepart}");
            Console.WriteLine($"Arriving date: {t.Flight.TimeArrive}");
            Console.WriteLine($"Seat count: {t.SeatsOccupied}");
            Console.Write("Seat numbers: ");
            foreach (int seat in t.SeatsOccupiedList) {
                Console.Write(seat + " ");
            }
            Console.WriteLine("\n------------------------------");
        }
        public bool ChangeBookingDeadline(Flight<int> flight) {
            Console.WriteLine($"Current deadline: {flight.StopBooking}. Departure time: {flight.TimeDepart}. ");
            Console.WriteLine("New deadline (yyyy mm dd hh mm ss). Should not be greater then departure time. Default - don't change anything:");
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
        public bool DelayFlight(Flight<int> flight) {
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
        public void ShowFlights(IList<Flight<int>> flights) {
            int idx = 0;
            foreach (Flight<int> f in flights) {
                Console.WriteLine();
                Console.WriteLine(idx + 1);
                Console.WriteLine("Departure: " + f.TimeDepart);
                Console.WriteLine("Arrival: " + f.TimeArrive);
                Console.WriteLine("From: " + f.Route.AirportDepart);
                Console.Write("To: " + f.Route.AirportArrive);
                idx++;
            }
                Console.WriteLine();
        }

        private Flight<int> ChooseFlight(IList<Flight<int>> flights) {
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

        private void PrintMenu() {
            Console.WriteLine("You're in the main menu. Choose action: ");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("| 1 - Show flights");
            Console.WriteLine("| 2 - Set or cancel flight delay");
            Console.WriteLine("| 3 - Change booking deadline");
            Console.WriteLine("| 4 - Show sold tickets ");
            Console.WriteLine("| 5 - Print all sold tickets");
            Console.WriteLine("| q - Quit");
            Console.WriteLine(new string('-', 30));
        }
    }
}