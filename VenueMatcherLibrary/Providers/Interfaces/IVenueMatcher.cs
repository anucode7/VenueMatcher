using System.Threading.Tasks;
using VenueMatcherLibrary.Enums;

namespace VenueMatcherLibrary
{
    public interface IVenueMatcher
    {
        SupplierCode code { get; }
        Task<bool> IsMatch(SupplierVenue supplierVenue, Venue venue);
    }
}
