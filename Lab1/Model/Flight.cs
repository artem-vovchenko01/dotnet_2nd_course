using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class Flight : IBase {
        public Guid Id { get; set; }
        public DateTime StopBooking {
            get { return _stopBooking == DateTime.MaxValue ? TimeDepart : _stopBooking; } 
            set {_stopBooking = value; } 
        }
        public int MinDelayed { get; set; } = 0;
        public DateTime TimeArrive {
            get { 
                return MinDelayed == 0 ? _timeArrive : _timeArrive.AddMinutes(MinDelayed);
            }
            set {_timeArrive = value; } 
        }

        public DateTime TimeDepart {
        get {
           return MinDelayed == 0 ? _timeDepart : _timeDepart.AddMinutes(MinDelayed);
        }
        set {_timeDepart = value; } 
        }
        public int SeatsCapacity { get {return Route.Airplane.Seats; }}
        public Route Route {get; set; }
        private DateTime _timeDepart;
        private DateTime _timeArrive;
        private DateTime _stopBooking = DateTime.MaxValue;
        public override string ToString()
        {
            return "TimeDepart: " + TimeDepart + ", TimeArrive: " + TimeArrive + ", Route: " + Route + ", SeatsCapacity: " + SeatsCapacity +
            ", MinDelayed: " + MinDelayed + ", StopBooking: " + StopBooking;
        }
    }
}
