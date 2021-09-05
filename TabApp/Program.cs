using Microsoft.Extensions.DependencyInjection;
using VenueMatcherLibrary;
using VenueMatcherLibrary.Services.Interfaces;

namespace TabApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddVenueLibrary();
            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<IMatchService>();
            Venue venue = new Venue()
            {
                Name = "Race Country Mayhew’s Ralph Lord"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Lord Ralph Mayhew’s Country Race"
            };
            service.Match(supplierVenue,venue,"HUH");
            serviceProvider.Dispose();
        }
    }
}
