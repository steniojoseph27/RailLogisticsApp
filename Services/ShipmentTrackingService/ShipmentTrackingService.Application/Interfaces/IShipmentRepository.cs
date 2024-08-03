using ShipmentTrackingService.Domain.Entities;

namespace ShipmentTrackingService.Application.Interfaces
{
    public interface IShipmentRepository
    {
        Task<Shipment> GetShipmentByIdAsync(int id);
        Task<IEnumerable<Shipment>> GetAllShipmentsAsync();
        Task AddShipmentAsync(Shipment shipment);
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(int id);
    }
}
