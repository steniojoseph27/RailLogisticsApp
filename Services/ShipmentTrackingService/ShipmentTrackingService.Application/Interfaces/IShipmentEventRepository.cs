using ShipmentTrackingService.Domain.Entities;

namespace ShipmentTrackingService.Application.Interfaces
{
    public interface IShipmentEventRepository
    {
        Task<IEnumerable<ShipmentEvent>> GetShipmentEventsByShipmentIdAsync(int shipmentId);
        Task AddShipmentEventAsync(ShipmentEvent shipmentEvent);
    }
}
