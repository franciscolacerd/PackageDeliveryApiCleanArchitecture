using Microsoft.AspNetCore.Http;
using PackageDelivery.Domain.Common;
using PackageDelivery.Domain.Extensions;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Domain.SmartEnums;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.DomainModels.Delivery
{
    public class DeliveryDomainModel : BaseIdentityProvider, IDeliveryDomainModel
    {
        //private readonly DateTime _datetimeUtc = DateTime.UtcNow;

        public DeliveryDomainModel(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public void AddAttributes(Persistence.Entities.Delivery delivery, AttributesModel attributes)
        {
            if (attributes is null) return;

            var deliveryAttributes = new List<DeliveryDeliveryAttribute>();

            foreach (var attributeId in Enumeration
                                        .GetAll<DeliveryAttributes>()
                                        .Select(attribute => attribute.Id))
            {
                bool isMissingAttribute = false;

                isMissingAttribute = attributeId switch
                {
                    1 => attributes.Pod,
                    2 => attributes.SameDay,
                    3 => attributes.CashOnDelivery,
                    _ => isMissingAttribute
                };

                if (isMissingAttribute)
                {
                    deliveryAttributes.Add(new DeliveryDeliveryAttribute
                    {
                        DeliveryAttributeId = attributeId,
                        //CreatedBy = this.Username,
                        //CreatedDateUtc = this._datetimeUtc
                    });
                }
            }

            delivery.DeliveryDeliveryAttributes = deliveryAttributes;
        }

        public void AddDetails(Persistence.Entities.Delivery delivery, DetailsModel details)
        {
            if (details is null) return;

            delivery.ClientReference = details.ClientReference;
            delivery.NumberOfVolumes =  details.NumberOfVolumes;
            delivery.TotalWeightOfVolumes =  details.TotalWeightOfVolumes;
            delivery.Amount =  details.Amount;
            delivery.Instructions =  details.Instructions;
            delivery.PreferentialPeriod =  details.PreferentialPeriod;
            //delivery.CreatedBy = this.Username;
            //delivery.CreatedDateUtc = this._datetimeUtc;
            delivery.UserId = this.UserId;
        }

        public void AddSender(Persistence.Entities.Delivery delivery, SenderModel sender)
        {
            if (sender is null) return;

            delivery.SenderName = sender.Name;

            if (sender?.Contact is null) return;

            delivery.SenderContactName = sender?.Contact?.Name;
            delivery.SenderContactPhoneNumber = sender?.Contact?.PhoneNumber;
            delivery.SenderContactEmail = sender?.Contact?.Email;

            if (sender?.Address is null) return;

            delivery.SenderAddress = sender?.Address?.AddressLine;
            delivery.SenderAddressPlace = sender?.Address?.Place;
            delivery.SenderAddressZipCode = sender?.Address?.ZipCode;
            delivery.SenderAddressZipCodePlace = sender?.Address?.ZipCodePlace;
            delivery.SenderAddressCountryCode = sender?.Address?.CountryCode;
        }

        public void AddReceiver(Persistence.Entities.Delivery delivery, ReceiverModel receiver)
        {
            if (receiver is null) return;

            delivery.ReceiverName = receiver.Name;

            if (receiver?.Contact is null) return;

            delivery.ReceiverContactName = receiver?.Contact?.Name;
            delivery.ReceiverContactPhoneNumber = receiver?.Contact?.PhoneNumber;
            delivery.ReceiverContactEmail = receiver?.Contact?.Email;

            if (receiver?.Address is null) return;

            delivery.ReceiverAddress = receiver?.Address?.AddressLine;
            delivery.ReceiverAddressPlace = receiver?.Address?.Place;
            delivery.ReceiverAddressZipCode = receiver?.Address?.ZipCode;
            delivery.ReceiverAddressZipCodePlace = receiver?.Address?.ZipCodePlace;
            delivery.ReceiverAddressCountryCode = receiver?.Address?.CountryCode;
        }

        public void AddBarcode(Persistence.Entities.Delivery delivery)
        {
            delivery.BarCode = 15.ToRandomStringOfInts();
        }

        public void AddVolumes(Persistence.Entities.Delivery delivery)
        {
            delivery.Packages = new List<Package>();

            var weight = delivery.TotalWeightOfVolumes / delivery.NumberOfVolumes;

            for (int i = 1; i <= delivery.NumberOfVolumes; i++)
            {
                delivery.Packages.Add(new Package
                {
                    //CreatedBy = this.Username,
                    //CreatedDateUtc = this._datetimeUtc,
                    Weight = weight,
                    PackageNumber = i,
                    PackageBarCode = $"{delivery.BarCode}{i.ToString().PadLeft(3, '0')}"
                });
            }
        }

        public void AddCreatedInSystemEvent(Persistence.Entities.Delivery delivery)
        {
            delivery.Events = new List<Event>
            {
                new Event
                {
                    //CreatedBy = this.Username,
                    //CreatedDateUtc = this._datetimeUtc,
                    EventTypeId = EventTypes.CreatedDelivery.Id
                }
            };
        }
    }
}