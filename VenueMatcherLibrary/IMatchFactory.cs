using System.Threading.Tasks;
using VenueMatcherLibrary.Enums;

namespace VenueMatcherLibrary
{
    public interface IMatchFactory
    {
        Task<bool> IsMatch(SupplierVenue supplierVenue, Venue venue, SupplierCode code);
    }
}
