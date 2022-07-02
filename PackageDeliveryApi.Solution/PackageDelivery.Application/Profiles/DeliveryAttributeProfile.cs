using PackageDelivery.Domain;

namespace PackageDelivery.Application.Profiles
{
    public partial class DeliveryAttributeProfile : AutoMapper.Profile
    {
        public DeliveryAttributeProfile()
        {
            CreateMap<DeliveryAttribute, DeliveryAttributeDto>().ReverseMap();
        }
    }
}