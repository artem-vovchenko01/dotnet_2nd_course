using System;

namespace Lab1 {
    interface IScheduledEvent {
        DateTime TimeDepart { get; set; }
        DateTime TimeArrive { get; set; }
    }
}
