using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

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