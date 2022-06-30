using PackageDelivery.Application.DTOs;
using PackageDelivery.Domain;

namespace PackageDelivery.Application.Profiles
{
    public partial class PackageProfile : AutoMapper.Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageDto>().ReverseMap();
        }
    }
}