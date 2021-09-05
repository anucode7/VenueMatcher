using System;
using System.Threading.Tasks;
using VenueMatcherLibrary.Enums;
using VenueMatcherLibrary.Services.Interfaces;

namespace VenueMatcherLibrary.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchFactory _matchFactory;
        public MatchService(IMatchFactory matchFactory)
        {
            _matchFactory = matchFactory;
        }
        public async Task<bool> Match(SupplierVenue supplierVenue, Venue venue, string code)
        {
            try
            {
                SupplierCodeValidator validator = new SupplierCodeValidator();
                var isValidCode = validator.IsValid(code);
                if (!isValidCode)
                {
                    return false;
                }
                var result = await _matchFactory.IsMatch(supplierVenue, venue, (SupplierCode)Enum.Parse(typeof(SupplierCode), code, true));
                return result;
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
