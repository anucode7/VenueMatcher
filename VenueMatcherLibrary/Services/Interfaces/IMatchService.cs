using System.Threading.Tasks;

namespace VenueMatcherLibrary.Services.Interfaces
{
    public interface IMatchService
    {
        Task<bool> Match(SupplierVenue supplierVenue, Venue venue, string code);
    }
}
