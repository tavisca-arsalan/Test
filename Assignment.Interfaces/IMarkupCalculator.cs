using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Interfaces
{
    public interface IMarkupCalculator
    {
        public List<Itinerary> CalculateMarkupAgainstFlightDuration(Itinerary published, List<Itinerary> discounted);

        public List<Itinerary> CalculateMarkupAgainstStops(Itinerary published, List<Itinerary> discounted);

        public List<Itinerary> CalculateMarkupAgainstLayoverTime(Itinerary published, List<Itinerary> discounted);

        public List<Itinerary> CalculateMarkupAgainstDepatureTime(Itinerary published, List<Itinerary> discounted);
    }
}
