using Xunit;

namespace VenueMatcherLibrary.Providers.ProviderTypes.Tests
{
    public class ThereaboutsTests
    {
        private readonly Thereabouts _sut;
        public ThereaboutsTests()
        {
            _sut = new Thereabouts();
        }
        [Fact()]
        public void Venues_with_same_code_in_range_should_be_valid()
        {
            var venue = new Venue()
            {
                VenueCode = "ABC",
                Latitude = 32.148M,
                Longitude = 148.6144M
            };
            var supplierVenue = new SupplierVenue()
            {
                VenueCode = "ABC",
                Latitude = 32.273M,
                Longitude = 148.586M
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Venues_with_diff_code_in_range_should_be_invalid()
        {
            var venue = new Venue()
            {
                VenueCode = "ABC",
                Latitude = 32.148M,
                Longitude = 148.6144M
            };
            var supplierVenue = new SupplierVenue()
            {
                VenueCode = "XYZ",
                Latitude = 32.273M,
                Longitude = 148.586M
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.False(isMatch.Result);
        }
        [Fact()]
        public void Venues_with_same_code_out_range_should_be_invalid()
        {
            var venue = new Venue()
            {
                VenueCode = "ABC",
                Latitude = 32.148M,
                Longitude = 148.6144M
            };
            var supplierVenue = new SupplierVenue()
            {
                VenueCode = "ABC",
                Latitude = 34.273M,
                Longitude = 159.586M
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.False(isMatch.Result);
        }
        [Fact()]
        public void Venues_with_diff_case_same_code_in_range_should_be_valid()
        {
            var venue = new Venue()
            {
                VenueCode = "ABC",
                Latitude = 32.148M,
                Longitude = 148.6144M
            };
            var supplierVenue = new SupplierVenue()
            {
                VenueCode = "abc",
                Latitude = 32.273M,
                Longitude = 148.586M
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
    }
}