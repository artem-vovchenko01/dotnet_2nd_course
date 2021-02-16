using System.Collections.Generic;

namespace Lab1 {
    interface IFlightFilter {
        List<IFlight> Filter(List<IFlight> flights);
    }
}
