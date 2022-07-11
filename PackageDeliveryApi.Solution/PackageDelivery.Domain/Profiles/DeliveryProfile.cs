using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

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