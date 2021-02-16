using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab1 {
    class Flight : IFlight, IBase {
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

        public Route Route {get; set; }
        private DateTime _timeDepart;
        private DateTime _timeArrive;
        private DateTime _stopBooking = DateTime.MaxValue;
    }
}
