using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentB
{
    public class MarkupManager
    {

        public List<Itinerary> CalculateMarkup(Itinerary published, List<Itinerary> discounted)
        {
            List<WrappedItinerary> wrappedItineraryList = CreateWrappedItineraryList(published, discounted);
            wrappedItineraryList = AddMarkupToItineraries(wrappedItineraryList, published.TotalFareInUSD);
            return UnWrapItineraries(wrappedItineraryList, published);
        }


        private List<WrappedItinerary> CreateWrappedItineraryList(Itinerary published,List<Itinerary> discounted)
        {
            int points;
            
            List<WrappedItinerary> wrappedItineraryList=new List<WrappedItinerary>();  //TO DO: Check if loose coupling is possible.
            foreach (Itinerary itinerary in discounted)
            {
                if (itinerary.BaseFareInUSD < (published.BaseFareInUSD - 10))  //Confirm this condition.
                {
                    points = CreatePoints(itinerary);
                    wrappedItineraryList.Add(new WrappedItinerary(points,itinerary));
                }
            }
            return wrappedItineraryList;
        }


        private int CreatePoints(Itinerary itinerary)
        {
            // TO DO: Make room for weighted-parameters.
            int points=0;
            points = points - itinerary.NumberOfStops * 15;

            if (itinerary.UtcDepartureTime.Hour > 20 && itinerary.UtcDepartureTime.Hour < 6)
            { points = points - 15; }

            else if (itinerary.UtcDepartureTime.Hour > 8 && itinerary.UtcDepartureTime.Hour < 12)
            { points = points + 15;}

            if (itinerary.TotalLayoverTime.Hours > 1)
            { points = points - (itinerary.TotalLayoverTime.Hours / 2) * 15; }      // TO DO: involve minutes by writing a function for rounding off time span. 

            return points;
        }

        private List<WrappedItinerary> AddMarkupToItineraries(List<WrappedItinerary> wrappedItineraryList,decimal publishedTotalFareInUSD)
        {
            foreach (WrappedItinerary wrappedItinerary in wrappedItineraryList)
            {
                wrappedItinerary.Itinerary.MarkupInUSD = (publishedTotalFareInUSD + wrappedItinerary.Points) - wrappedItinerary.Itinerary.BaseFareInUSD;
            }
            return wrappedItineraryList;
        }

        private List<Itinerary> UnWrapItineraries(List<WrappedItinerary> wrappedItineraryList,Itinerary published)
        {
            List<Itinerary> markedupItinararies = new List<Itinerary>();        //TO DO: Check if loose coupling is possible
            foreach (WrappedItinerary wrappedItinerary in wrappedItineraryList)
            {
                if (wrappedItinerary.Itinerary.TotalFareInUSD > published.TotalFareInUSD)
                { 
                    wrappedItinerary.Itinerary.MarkupInUSD = published.TotalFareInUSD - wrappedItinerary.Itinerary.BaseFareInUSD; 

                }
                if (wrappedItinerary.Itinerary.MarkupInUSD >= 10)        // Weak Link ----Confirm It------
                {
                    markedupItinararies.Add(wrappedItinerary.Itinerary);
                }
            }
            return markedupItinararies; 
        }

       
    }
}
