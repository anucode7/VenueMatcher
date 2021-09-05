using Xunit;
using VenueMatcherLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using VenueMatcherLibrary.Enums;

namespace VenueMatcherLibrary.Services.Tests
{
    public class MatchServiceTests
    {
        private readonly Mock<IMatchFactory> _mockMatchFactory = new Mock<IMatchFactory>();
        private MatchService _sut;
        public MatchServiceTests()
        {
            _sut = new MatchService(_mockMatchFactory.Object);
        }
        [Fact()]
        public void When_code_matches_returns_valid_result()
        {
            Venue venue = new Venue()
            {
                Name = "Race Country Mayhew’s Ralph Lord"
            };
            SupplierVenue supplierVenue = new SupplierVenue()
            {
                Name = "Lord Ralph Mayhew’s Country Race"
            };
            _mockMatchFactory.Setup(s => s.IsMatch(It.IsAny<SupplierVenue>(), It.IsAny<Venue>(), It.IsAny<SupplierCode>())).Returns(Task.FromResult(true));
            var response = _sut.Match(supplierVenue,venue,"GCC");
            Assert.True(response.Result);
        }
    }
}