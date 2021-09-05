using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenueMatcherLibrary.Enums;

namespace VenueMatcherLibrary.Providers.ProviderTypes
{
    public class Contrary : IVenueMatcher
    {
        public SupplierCode code => SupplierCode.GCC;
        public Task<bool> IsMatch(SupplierVenue supplierVenue, Venue venue)
        {
            var cleanSupplierVenueName = new string(supplierVenue.Name.Where(c => !char.IsPunctuation(c)).ToArray());
            var cleanVenueName = new string(venue.Name.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] words = cleanVenueName.Split(' ');
            Array.Reverse(words);
            StringBuilder sb = new StringBuilder();
            foreach (var item in words)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    sb.Append(item);
                    sb.Append(" ");
                }
            }
            var reversedName = sb.ToString().TrimEnd();
         
            return Task.FromResult(string.Compare(cleanSupplierVenueName, reversedName, true) == 0 ? true : false);
        }
       
    }
}
