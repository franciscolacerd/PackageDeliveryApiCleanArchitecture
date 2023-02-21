using FluentValidation;
using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Application.Validation.Delivery
{
    public class ContactValidator : AbstractValidator<ContactModel>
    {
        public ContactValidator(string field)
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(200).WithName(p => $"{field}.Contact.Name");
            RuleFor(x => x.PhoneNumber).NotNull().MaximumLength(100).WithName(p => $"{field}.Contact.PhoneNumber");
            RuleFor(x => x.Email).MaximumLength(100).EmailAddress().WithName(p => $"{field}.Contact.Email");
        }
    }
}