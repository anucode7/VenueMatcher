using Xunit;

namespace VenueMatcherLibrary.Providers.ProviderTypes.Tests
{
    public class SuperfluousTests
    {
        private readonly Superfluous _sut;
        public SuperfluousTests()
        {
            _sut = new Superfluous();
        }
        [Fact()]
        public void Venues_with_same_strings_different_punctuations_should_be_valid()
        {
            Venue venue = new Venue()
            {
                Name = "*Good*-Times! VENUE (Dubbo)",
                Address = "22 Carrington-Square, Dubbo, NSW."
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Good Times Venue, Dubbo",
                Address = "22 Carrington Square, Dubbo NSW"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Venues_with_same_strings_different_spaces_should_be_valid()
        {
            Venue venue = new Venue()
            {
                Name = "Good Times Venue,  Dubbo",
                Address = "22 Carrington-Square, Dubbo  NSW."
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Good Times Venue, Dubbo",
                Address = "22 Carrington Square, Dubbo NSW"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Venues_with_diff_name_should_be_invalid()
        {
            Venue venue = new Venue()
            {
                Name = "Good Times Venue, Olympic park",
                Address = "22 Carrington-Square, Dubbo  NSW."
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Good Times Venue, Dubbo",
                Address = "22 Carrington Square, Dubbo NSW"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.False(isMatch.Result);
        }
        [Fact()]
        public void Venues_with_diff_address_should_be_invalid()
        {
            Venue venue = new Venue()
            {
                Name = "Good Times Venue, Dubbo",
                Address = "22 Carrington Square, Dubbo NSW"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Good Times Venue, Dubbo",
                Address = "22 Carington Square, Dubbo NSW"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.False(isMatch.Result);
        }
        [Fact()]
        public void Venues_with_same_details_different_case_should_be_valid()
        {
            Venue venue = new Venue()
            {
                Name = "Good Times Venue, Dubbo",
                Address = "22 Carrington Square, Dubbo NSW"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "good times Venue, dubbo",
                Address = "22 carrington square, Dubbo NSW"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
    }
}