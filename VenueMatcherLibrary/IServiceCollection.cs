using Microsoft.Extensions.DependencyInjection;
using VenueMatcherLibrary.Providers.ProviderTypes;
using VenueMatcherLibrary.Services;
using VenueMatcherLibrary.Services.Interfaces;

namespace VenueMatcherLibrary
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddVenueLibrary(this IServiceCollection services)
        {
            services.AddTransient<IMatchFactory, MatchFactory>();
            services.AddTransient<IVenueMatcher, Contrary>();
            services.AddTransient<IVenueMatcher, Thereabouts>();
            services.AddTransient<IVenueMatcher, Superfluous>();
            services.AddTransient<IMatchService, MatchService>();
            return services;
        }
    }
}
