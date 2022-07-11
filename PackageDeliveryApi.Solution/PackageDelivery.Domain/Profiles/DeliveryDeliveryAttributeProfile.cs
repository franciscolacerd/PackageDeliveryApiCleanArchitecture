using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

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