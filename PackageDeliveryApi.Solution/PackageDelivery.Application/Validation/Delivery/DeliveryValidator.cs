using FluentValidation;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Persistence;

namespace PackageDelivery.Application.Validation.Delivery;

public class DeliveryValidator : AbstractValidator<DeliveryModel>
{
    private readonly PackageDeliveryDbContext _context;

    private readonly AttributesValidator _attributesValidator;

    private readonly DetailsValidator _detailsValidator;

    public DeliveryValidator(
        PackageDeliveryDbContext context,
        AttributesValidator attributesValidator,
        DetailsValidator detailsValidator)
    {
        this._context = context;
        this._attributesValidator = attributesValidator;
        this._detailsValidator = detailsValidator;

        RuleFor(x => x.Details).NotNull();
        RuleFor(x => x.Sender).NotNull();
        RuleFor(x => x.Receiver).NotNull();
        RuleFor(x => x.Attributes).NotNull();

        RuleFor(x => x.Details).SetValidator(this._detailsValidator).When(x => x.Details != null);

        RuleFor(x => x).Must((shipment) => shipment?.Details?.Amount > 0 ? shipment?.Attributes?.CashOnDelivery == true : true).WithMessage("If amount is not null, CashOnDelivery attribute must be selected.");

        RuleFor(x => x).Must((shipment) => shipment?.Attributes?.CashOnDelivery == true ? shipment?.Details?.Amount > 0 : true).WithMessage("If CashOnDelivery attribute is selected, amount must not be null.");

        RuleFor(x => x.Sender).SetValidator(new SenderValidator(this._context, "Sender")).When(x => x.Sender != null);

        RuleFor(x => x.Receiver).SetValidator(new ReceiverValidator(this._context, "Receiver")).When(x => x.Receiver != null);

        RuleFor(x => x.Attributes).SetValidator(this._attributesValidator).When(x => x.Attributes != null);
    }
}