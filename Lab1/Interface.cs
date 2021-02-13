using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    static class Interface {
        public static void MainMenu() {
            string inp = "";
            bool done = false;
        while (! done) {
        Console.WriteLine("You're in the main menu. Choose action: ");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("| 1 - Show flights");
        Console.WriteLine("| 2 - Set or cancel flight delay");
        Console.WriteLine("| 3 - Change booking deadline");
        Console.WriteLine("| 4 - Show sold tickets ");
        Console.WriteLine("| q - Quit");
        Console.WriteLine(new string('-', 30));
        inp = Console.ReadLine();
        List<ScheduledFlight> flights = new List<ScheduledFlight>();
        ScheduledFlight flight = null;
        switch (inp.Trim()) {
            case "q": 
            done = true;
            break;
            case "1":
                ShowFlights(FilterFlights());
                break;
            case "2":
                flights = FilterFlights();
                ShowFlights(flights);
                while (true) {
                    flight = ChooseFlight(flights);
                    if(Delay(flight)) break;
                    else if (! AskRepeat()) break;
                }
                break;
            case "3":
                flights = FilterFlights();
                ShowFlights(flights);
                while (true) {
                    flight = ChooseFlight(flights);
                    if (ChangeBookingDeadline(flight)) break;
                    else if (! AskRepeat()) break;
                }
                break;
        }
        }
        }

        static void ShowSoldTickets(ScheduledFlight flight) {
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
        static bool AskRepeat() {
            Console.WriteLine("Do you want to try again? (y / N) ");
            string inp = Console.ReadLine();
            return inp.StartsWith("y") || inp.StartsWith("Y");
        }
        static bool ChangeBookingDeadline(ScheduledFlight flight) {
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
        static bool Delay(ScheduledFlight flight) {
            Console.WriteLine($"Flight departures at {flight.TimeDepart}. Current delay is: {(flight.Itinerary == null ? flight.MinDelayed : flight.Itinerary.MinDelayed)}.");
            Console.Write("New delay (in minutes): ");
            int min;
            try {
                min = int.Parse(Console.ReadLine());
            } catch {
                Console.WriteLine("Wrong format. Delay unchanged. ");
                return false;
            }
            if (flight.Itinerary != null) {
                flight.Itinerary.MinDelayed = min;
            } else flight.MinDelayed = min;
            Console.WriteLine($"Success! New departure time: {flight.TimeDepart} ");
            return true;
        }
        static List<ScheduledFlight> FilterFlights() {
            List<ScheduledFlight> flights = ScheduledFlight.ScheduledFlights;
            List<ScheduledFlight> filteredFlights;
            string startDateStr;
            string endDateStr;
            Console.WriteLine("Search flights. Choose appropriate filters. Leave blank if defaults satisfy: ");
            Console.Write($"Start date (yyyy mm dd). Default: {DateTime.Today}: ");
            startDateStr = Console.ReadLine();
            Console.Write($"End date (yyyy mm dd). Default: {DateTime.Today.AddMonths(1)} : ");
            endDateStr = Console.ReadLine();
            Console.WriteLine();
            string[] split = startDateStr.Split(' ');
            DateTime startDate = startDateStr != "" ? new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])) : DateTime.Today;
            split = endDateStr.Split(' ');
            DateTime endDate = endDateStr != "" ? new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])) : DateTime.Today.AddMonths(1);
            filteredFlights = flights.Where(f => f.TimeDepart >= startDate && f.TimeDepart <= endDate).ToList();
            return filteredFlights;
        }
        static void ShowFlights(List<ScheduledFlight> flights) {
            List<Itinerary> processedItineraries = new List<Itinerary>();
            Itinerary itinerary;
            Flight departFlight;
            Flight arriveFlight;
            int idx = 0;

            foreach (ScheduledFlight f in flights) {
                if (f.Itinerary != null) {
                    itinerary = f.Itinerary;
                    if (processedItineraries.Contains(itinerary)) {idx++; continue;}
                    processedItineraries.Add(itinerary);
                    List<ScheduledFlight> itFlights = itinerary.ScheduledFlights;
                    DateTime departTime = itFlights[0].TimeDepart;
                    DateTime arriveTime = itFlights[itFlights.Count - 1].TimeArrive;
                    departFlight = itFlights[0].Flight;
                    arriveFlight = itFlights[itFlights.Count - 1].Flight;
                    Console.WriteLine(idx + 1);
                    Console.WriteLine("Departure: " + departTime.ToString());
                    Console.WriteLine("Arrival: " + arriveTime.ToString());
                    Console.WriteLine("From: " + departFlight.AirportDepart);
                    Console.Write("To: " + arriveFlight.AirportArrive);
                    Console.WriteLine(" " + (itFlights.Count - 1).ToString().PadLeft(3) + " stops ");
                    Console.WriteLine();
                } else {
                    departFlight = f.Flight;
                    Console.WriteLine("Departure: " + f.TimeDepart.ToString());
                    Console.WriteLine("Arrival: " + f.TimeArrive.ToString());
                    Console.WriteLine("From: " + departFlight.AirportDepart);
                    Console.Write("To: " + departFlight.AirportArrive);
                }
                idx++;
            }
        }
        static ScheduledFlight ChooseFlight(List<ScheduledFlight> flights) {
            int max = flights.Count;
            Console.Write($"Choose flight (by number): ");
            string inp = Console.ReadLine();
            int choice = int.Parse(inp);
            return flights[choice - 1];
        }
    }

}