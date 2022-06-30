﻿using PackageDelivery.Application.DTOs;
using PackageDelivery.Domain;

namespace PackageDelivery.Application.Contracts.Persistence
{
    public interface IPackageRepository : IGenericRepository<Package, PackageDto>
    {
    }
}