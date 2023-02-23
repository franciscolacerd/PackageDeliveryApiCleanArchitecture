﻿using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Contracts.Persistence
{
    public interface IApiLogRepository : IGenericRepository<ApiLog, ApiLogDto>
    {
    }
}