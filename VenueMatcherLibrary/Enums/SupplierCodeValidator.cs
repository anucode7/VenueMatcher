using System;
using System.ComponentModel.DataAnnotations;

namespace VenueMatcherLibrary.Enums
{
    public class SupplierCodeValidator : ValidationAttribute
    {
        private readonly string[] _values;
        public SupplierCodeValidator(params string[] values)
        {
            _values = values;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && Enum.IsDefined(typeof(SupplierCode), value.ToString()?.Trim()?.ToUpperInvariant()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Not a valid value");
        }
    }
}
