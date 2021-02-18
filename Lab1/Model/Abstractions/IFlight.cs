using System;
using System.Collections.Generic;

namespace Lab1 {
    interface IFlight : IScheduledEvent {
        DateTime StopBooking { get; set; }
        int MinDelayed { get; set; }
        IRoute Route { get; set; }
        int SeatsCapacity { get; }
    }
}
