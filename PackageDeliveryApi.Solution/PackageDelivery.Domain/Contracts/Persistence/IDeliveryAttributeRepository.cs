using PackageDelivery.Domain.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Contracts.Persistence
{
    public interface IDeliveryAttributeRepository : IGenericRepository<DeliveryAttribute, DeliveryAttributeDto>
    {
    }
}