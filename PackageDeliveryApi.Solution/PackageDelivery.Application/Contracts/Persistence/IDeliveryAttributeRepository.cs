using PackageDelivery.Domain;

namespace PackageDelivery.Application.Contracts.Persistence
{
    public interface IDeliveryAttributeRepository : IGenericRepository<DeliveryAttribute, DeliveryAttributeDto>
    {
    }
}