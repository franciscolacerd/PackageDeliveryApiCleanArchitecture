using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Profiles
{
    public partial class PackageProfile : AutoMapper.Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageDto>().ReverseMap();
        }
    }
}