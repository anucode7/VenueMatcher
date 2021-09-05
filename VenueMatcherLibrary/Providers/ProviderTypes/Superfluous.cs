using System;
using System.Linq;
using System.Threading.Tasks;
using VenueMatcherLibrary.Enums;

namespace VenueMatcherLibrary.Providers.ProviderTypes
{
    public class Superfluous : IVenueMatcher
    {
        public SupplierCode code => SupplierCode.SUP;

        public Task<bool> IsMatch(SupplierVenue supplierVenue, Venue venue)
        {
            var cleanSupplierVenueName = new string(supplierVenue.Name.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());
            var cleanSupplierVenueAddress = new string(supplierVenue.Address.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray()); ;
            var cleanVenueName = new string(venue.Name.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());
            var cleanVenueAddress = new string(venue.Address.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());
            int nameCompare = string.Compare(cleanSupplierVenueName, cleanVenueName, true);
            int addressCompare = string.Compare(cleanSupplierVenueAddress, cleanVenueAddress, true);
            return Task.FromResult((Math.Abs(nameCompare) + Math.Abs(addressCompare)) == 0);
        }
       
    }
}
