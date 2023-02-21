using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Profiles
{
    public partial class DeliveryDeliveryAttributeProfile : AutoMapper.Profile
    {
        public DeliveryDeliveryAttributeProfile()
        {
            CreateMap<DeliveryDeliveryAttribute, DeliveryDeliveryAttributeDto>().ReverseMap();
        }
    }
}