using System.Collections.Generic;
using System;

namespace Lab1 {
    class Database : IDatabase<int> {
        public int keySeed { get; private set; }
        public Func<int, int> keyGenerator { get; private set; }
        public Database(int keySeed, Func<int, int> keyGenerator) {
            this.keySeed = keySeed;
            this.keyGenerator = keyGenerator;
            Passengers = new Dictionary<int, Passenger>();
            Flights = new Dictionary<int, Flight>();
            Airplanes = new Dictionary<int, Airplane>();
            Airports = new Dictionary<int, Airport>();
            Tickets = new Dictionary<int, Ticket>();
            Routes = new Dictionary<int, Route>();
        }
        
        public IDictionary<int, IPassenger<int>> Passengers { get; private set; }
        public IDictionary<int, IFlight<int>> Flights { get; private set; }
        public IDictionary<int, IAirplane<int>> Airplanes { get; private set; }
        public IDictionary<int, IAirport<int>> Airports { get; private set; }
        public IDictionary<int, ITicket<int>> Tickets { get; private set; }
        public IDictionary<int, IRoute<int>> Routes { get; private set; }
    }
}
