using PackageDelivery.Application.DTOs;
using PackageDelivery.Domain;

namespace PackageDelivery.Application.Profiles
{
    public partial class DeliveryProfile : AutoMapper.Profile
    {
        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
        }
    }
}