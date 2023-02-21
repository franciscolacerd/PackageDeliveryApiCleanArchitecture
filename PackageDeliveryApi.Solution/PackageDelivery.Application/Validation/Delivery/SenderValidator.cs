using FluentValidation;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Persistence;

namespace PackageDelivery.Application.Validation.Delivery
{
    public class SenderValidator : AbstractValidator<SenderModel>
    {
        private readonly PackageDeliveryDbContext _context;

        public SenderValidator(PackageDeliveryDbContext context, string field)
        {
            this._context = context;

            RuleFor(x => x.Name).NotNull().MaximumLength(100).WithName(p => $"{field}.Name");
            RuleFor(x => x.Contact).NotNull().WithName(p => $"{field}.Contact");
            RuleFor(x => x.Address).NotNull().WithName(p => $"{field}.Address");

            RuleFor(x => x.Contact).SetValidator(new ContactValidator(field)).When(x => x.Contact != null);

            RuleFor(x => x.Address).SetValidator(new AddressValidator(this._context, field)).When(x => x.Address != null);
        }
    }
}