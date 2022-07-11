using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Domain.Contracts.Persistence
{
    public interface IDeliveryAttributeRepository : IGenericRepository<DeliveryAttribute, DeliveryAttributeDto>
    {
    }
}