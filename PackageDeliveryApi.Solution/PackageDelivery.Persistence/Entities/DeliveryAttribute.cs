﻿using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Persistence.Entities
{
    public partial class DeliveryAttribute : BaseDomainEntity
    {
        public DeliveryAttribute()
        {
            DeliveryDeliveryAttributes = new HashSet<DeliveryDeliveryAttribute>();
        }

        public string DeliveryAttributeENG { get; set; } = null!;
        public string DeliveryAttributeES { get; set; } = null!;
        public string DeliveryAttributePT { get; set; } = null!;
        public virtual ICollection<DeliveryDeliveryAttribute> DeliveryDeliveryAttributes { get; set; }
    }
}