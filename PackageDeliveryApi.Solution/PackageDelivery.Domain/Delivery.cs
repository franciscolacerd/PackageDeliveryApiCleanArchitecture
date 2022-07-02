﻿using PackageDelivery.Domain.Common;

namespace PackageDelivery.Domain
{
    public partial class Delivery : BaseDomainEntity
    {
        public Delivery()
        {
            Packages = new HashSet<Package>();
        }

        public string? ClientReference { get; set; }
        public int NumberOfVolumes { get; set; }
        public decimal TotalWeightOfVolumes { get; set; }
        public decimal? Amount { get; set; }
        public string? Instructions { get; set; }
        public string? PreferentialPeriod { get; set; }
        public string? SenderClientCode { get; set; }
        public string SenderName { get; set; } = null!;
        public string? SenderContactName { get; set; }
        public string? SenderContactPhoneNumber { get; set; }
        public string? SenderContactEmail { get; set; }
        public string SenderAddress { get; set; } = null!;
        public string? SenderAddressPlace { get; set; }
        public string SenderAddressZipCode { get; set; } = null!;
        public string SenderAddressZipCodePlace { get; set; } = null!;
        public string? SenderAddressCountryCode { get; set; }
        public string? ReceiverClientCode { get; set; }
        public string ReceiverName { get; set; } = null!;
        public string? ReceiverContactName { get; set; }
        public string? ReceiverContactPhoneNumber { get; set; }
        public string? ReceiverContactEmail { get; set; }
        public string ReceiverAddress { get; set; } = null!;
        public string? ReceiverAddressPlace { get; set; }
        public string ReceiverAddressZipCode { get; set; } = null!;
        public string ReceiverAddressZipCodePlace { get; set; } = null!;
        public string? ReceiverAddressCountryCode { get; set; }
        public string? ReceiverFixedInstructions { get; set; }
        public string BarCode { get; set; } = null!;
        public string? PinNumber { get; set; }
        public string? Eta { get; set; }
        public DateTime? PickingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public virtual ICollection<Package> Packages { get; set; } = null!;
        public virtual ICollection<DeliveryDeliveryAttribute> DeliveryDeliveryAttributes { get; set; }
    }
}