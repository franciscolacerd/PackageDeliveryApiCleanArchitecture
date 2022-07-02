﻿using PackageDelivery.Application.DTOs.Common;

namespace PackageDelivery.Domain
{
    public partial class DeliveryAttributeDto : BaseDto
    {
        public DeliveryAttributeDto()
        {
            DeliveryDeliveryAttributes = new HashSet<DeliveryDeliveryAttributeDto>();
        }

        public string DeliveryAttributeENG { get; set; } = null!;
        public string DeliveryAttributeES { get; set; } = null!;
        public string DeliveryAttributePT { get; set; } = null!;
        public virtual ICollection<DeliveryDeliveryAttributeDto> DeliveryDeliveryAttributes { get; set; }
    }
}