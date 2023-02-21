using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Profiles
{
    public partial class DeliveryProfile : AutoMapper.Profile
    {
        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
        }
    }
}