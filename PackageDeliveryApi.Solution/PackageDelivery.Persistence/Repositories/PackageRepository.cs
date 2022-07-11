﻿using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class PackageRepository : GenericRepository<Package, PackageDto>, IPackageRepository
    {
        public PackageRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}