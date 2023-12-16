using FluentValidation;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Persistence;
using System.Text.RegularExpressions;

namespace PackageDelivery.Application.Validation.Delivery
{
    public class AddressValidator : AbstractValidator<AddressModel>
    {
        private readonly PackageDeliveryDbContext _context;

        public AddressValidator(PackageDeliveryDbContext context, string field)
        {
            this._context = context;

            RuleFor(x => x.AddressLine).NotNull().MaximumLength(400).WithName(p => $"{field}.Address.AddressLine");
            RuleFor(x => x.Place).MaximumLength(100).WithName(p => $"{field}.Address.Place");
            RuleFor(x => x.ZipCode).NotNull().NotEmpty().MaximumLength(10).WithName(p => $"{field}.Address.ZipCode");
            RuleFor(x => x).Must((address) => ValidateZipCode(address))
                .WithMessage("'{PropertyName}' must be valid.").WithName(p => $"{field}.Address.ZipCode");
            RuleFor(x => x.ZipCodePlace).NotNull().MaximumLength(100).WithName(p => $"{field}.Address.ZipCodePlace");
            RuleFor(x => x.CountryCode).MaximumLength(3).WithName(p => $"{field}.Address.CountryCode");
        }

        private bool ValidateZipCode(AddressModel address)
        {
            if (address is null) { return false; }

            return string.IsNullOrEmpty(address?.CountryCode) || address?.CountryCode?.ToLower() == "pt" || address?.CountryCode?.ToLower() == "prt"
                ? Regex.IsMatch(address.ZipCode, "^[1-9]\\d{3}-\\d{3}$")
                : true;
        }
    }
}