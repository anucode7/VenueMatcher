using Xunit;

namespace VenueMatcherLibrary.Enums.Tests
{
    public class SupplierCodeValidatorTests
    {
        [Theory]
        [InlineData("GCC")]
        [InlineData("HUH")]
        [InlineData("SUP")]
        [InlineData("gcc")]
        [InlineData("huh")]
        [InlineData("sup")]
        public void When_enum_suppliercodes_valid_return_true(string code)
        {
            var validator = new SupplierCodeValidator();
            var result = validator.IsValid(code);
            Assert.True(result);
        }
        [Theory]
        [InlineData("xx")]
        [InlineData("vv")]
        [InlineData("SUPS")]
        public void When_enum_suppliercodes_invalid_return_false(string code)
        {
            var validator = new SupplierCodeValidator();
            var result = validator.IsValid(code);
            Assert.False(result);
        }
    }
}