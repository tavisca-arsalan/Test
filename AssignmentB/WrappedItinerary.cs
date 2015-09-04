using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentB
{
    public class WrappedItinerary
    {
        public int Points{get; set;}
        public Itinerary Itinerary{get; set;}

        public WrappedItinerary(int points, Itinerary discountedItinerary)
        {
            Points = points;
            Itinerary = discountedItinerary;
        }
    }
}
