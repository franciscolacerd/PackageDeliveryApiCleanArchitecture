using FluentValidation;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Persistence;

namespace PackageDelivery.Application.Validation.Delivery
{
    public class DetailsValidator : AbstractValidator<DetailsModel>
    {
        private readonly PackageDeliveryDbContext _context;

        public DetailsValidator(PackageDeliveryDbContext context)
        {
            this._context = context;

            RuleFor(x => x.ClientReference).MaximumLength(50).WithName(p => $"Details.ClientReference");
            RuleFor(x => x.NumberOfVolumes).NotNull().GreaterThan(1).LessThanOrEqualTo(200).WithName(p => $"Details.NumberOfVolumes");
            RuleFor(x => x.TotalWeightOfVolumes).NotNull().GreaterThan(0.0001m).LessThanOrEqualTo(99999).WithName(p => $"Details.TotalWeightOfVolumes");
            RuleFor(x => x.Amount).LessThanOrEqualTo(9999999.99m).WithName(p => $"Details.Amount");
            RuleFor(x => x.Instructions).MaximumLength(250).WithName(p => $"Details.Instructions");
            RuleFor(x => x.PreferentialPeriod).MaximumLength(23).WithName(p => $"Details.PreferentialPeriod");
        }
    }
}