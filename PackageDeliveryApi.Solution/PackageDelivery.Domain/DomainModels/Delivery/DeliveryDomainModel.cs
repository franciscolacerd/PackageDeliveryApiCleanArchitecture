﻿using PackageDelivery.Domain.Extensions;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Domain.SmartEnums;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.DomainModels.Delivery
{
    public class DeliveryDomainModel : IDeliveryDomainModel
    {
        private readonly DateTime _datetimeUtc = DateTime.UtcNow;
        private string _user = string.Empty;

        public void AddUser(string user)
        {
            this._user = user;
        }

        public void AddAttributes(Persistence.Entities.Delivery delivery, AttributesModel attributes)
        {
            if (attributes is null) return;

            var deliveryAttributes = new List<DeliveryDeliveryAttribute>();

            foreach (var attribute in Persistence.Common.Enumeration.GetAll<DeliveryAttributes>())
            {
                bool isMissingAttribute = false;

                switch (attribute.Id)
                {
                    case 1:
                        isMissingAttribute = attributes.Pod;
                        break;

                    case 2:
                        isMissingAttribute = attributes.SameDay;
                        break;

                    case 3:
                        isMissingAttribute = attributes.CashOnDelivery;
                        break;

                    default:
                        break;
                }

                if (isMissingAttribute)
                {
                    deliveryAttributes.Add(new DeliveryDeliveryAttribute
                    {
                        DeliveryAttributeId = attribute.Id,
                        CreatedBy = this._user,
                        CreatedDateUtc = this._datetimeUtc
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
            delivery.CreatedBy = this._user;
            delivery.CreatedDateUtc = this._datetimeUtc;
        }

        public void AddSender(Persistence.Entities.Delivery delivery, SenderModel sender)
        {
            if (sender is null) return;

            delivery.SenderName = sender.Name;

            if (sender?.Contact is null) return;

            delivery.SenderContactName = sender?.Contact?.Name;
            delivery.SenderContactPhoneNumber = sender?.Contact?.PhoneNumber;
            delivery.SenderContactEmail = sender?.Contact?.Email;

            if (sender?.Address == null) return;

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
                    CreatedBy = this._user,
                    CreatedDateUtc = this._datetimeUtc,
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
                    CreatedBy = this._user,
                    CreatedDateUtc = this._datetimeUtc,
                    EventTypeId = EventTypes.CreatedDelivery.Id
                }
            };
        }
    }
}