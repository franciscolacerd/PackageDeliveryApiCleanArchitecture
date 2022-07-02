using PackageDelivery.Domain;

namespace PackageDelivery.Application.Profiles
{
    public partial class DeliveryDeliveryAttributeProfile : AutoMapper.Profile
    {
        public DeliveryDeliveryAttributeProfile()
        {
            CreateMap<DeliveryDeliveryAttribute, DeliveryDeliveryAttributeDto>().ReverseMap();
        }
    }
}