using Xunit;

namespace VenueMatcherLibrary.Providers.ProviderTypes.Tests
{
    public class ContraryTests
    {
        private readonly Contrary _sut;
        public ContraryTests()
        {
            _sut = new Contrary();
        }
        [Fact()]
        public void Name_with_matching_reverse_string_should_be_valid()
        {            
            Venue venue = new Venue()
            {
                Name = "Race Country Mayhew’s Ralph Lord"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Lord Ralph Mayhew’s Country Race"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue); 
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Name_with_single_word_should_be_valid()
        {
            Venue venue = new Venue()
            {
                Name = "Race"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Race"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Name_with_matching_string_but_not_spacing_should_be_valid()
        {
            Venue venue = new Venue()
            {
                Name = "  Race Country Mayhew’s Ralph  Lord "
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name =  "Lord Ralph Mayhew’s Country Race"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Name_with_matching_string_different_punctuation_should_be_valid()
        {
            Venue venue = new Venue()
            {
                Name = "czechoslovakia"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "czechoslovakia!"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Name_with_matching_string_different_case_should_be_valid()
        {
            Venue venue = new Venue()
            {
                Name = "Race Country Mayhew’s Ralph Lord"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "lord ralph mayhew’s country race"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.True(isMatch.Result);
        }
        [Fact()]
        public void Name_with_not_matching_string_should_be_invalid()
        {
            Venue venue = new Venue()
            {
                Name = "czechoslovakia does not exist"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "czechoslovakia does exist"
            };
            var isMatch = _sut.IsMatch(supplierVenue, venue);
            Assert.False(isMatch.Result);
        }
    }
}