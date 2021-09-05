using Geolocation;
using System.Threading.Tasks;
using VenueMatcherLibrary.Enums;

namespace VenueMatcherLibrary.Providers.ProviderTypes
{
    public class Thereabouts : IVenueMatcher
    {
        public SupplierCode code => SupplierCode.HUH;
        public Task<bool> IsMatch(SupplierVenue supplierVenue, Venue venue)
        {
            bool isChainCodeEqual = string.Compare(supplierVenue.VenueCode, venue.VenueCode, true) == 0 ? true : false;
            var supplierVenueCoords = new Coordinate((double)supplierVenue.Latitude, (double)supplierVenue.Longitude);
            var venueCoords = new Coordinate((double)venue.Latitude, (double)venue.Longitude);
            double distanceApartInMeter = GeoCalculator.GetDistance(supplierVenueCoords, venueCoords, 2);
            bool locationSatisfy = distanceApartInMeter <= 200 ? true : false;
            return Task.FromResult(isChainCodeEqual && locationSatisfy);
        }       
    }
}
