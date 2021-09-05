using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenueMatcherLibrary.Enums;

namespace VenueMatcherLibrary
{
    public class MatchFactory : IMatchFactory
    {
        private readonly IEnumerable<IVenueMatcher> _matchImplementations;

        public MatchFactory(IEnumerable<IVenueMatcher> matchImplementations)
        {
            _matchImplementations = matchImplementations;
        }

        public Task<bool> IsMatch(SupplierVenue supplierVenue, Venue venue, SupplierCode code)
        {
            return _matchImplementations.FirstOrDefault(x => x.code == code)?.IsMatch(supplierVenue, venue) ?? throw new ArgumentNullException(nameof(code));
        }
    }
}
