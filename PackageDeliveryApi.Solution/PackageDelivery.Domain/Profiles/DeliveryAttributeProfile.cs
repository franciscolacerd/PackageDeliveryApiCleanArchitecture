using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Domain.Profiles
{
    public partial class DeliveryAttributeProfile : AutoMapper.Profile
    {
        public DeliveryAttributeProfile()
        {
            CreateMap<DeliveryAttribute, DeliveryAttributeDto>().ReverseMap();
        }
    }
}