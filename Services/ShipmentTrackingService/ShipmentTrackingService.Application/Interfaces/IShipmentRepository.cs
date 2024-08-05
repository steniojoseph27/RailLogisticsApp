using ShipmentTrackingService.Domain.Entities;

namespace ShipmentTrackingService.Application.Interfaces
{
    public interface IShipmentRepository
    {
        Task AddShipmentAsync(Shipment shipment);
        Task<Shipment> GetShipmentByIdAsync(int shipmentId);
        Task<IEnumerable<Shipment>> GetAllShipmentsAsync();
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(int shipmentId);
    }
}
