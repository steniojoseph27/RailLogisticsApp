using ShipmentTrackingService.Application.Requests;
using ShipmentTrackingService.Domain.Entities;

namespace ShipmentTrackingService.Application.Services
{
    public interface IShipmentService
    {
        Task<Shipment> CreateShipmentAsync(CreateShipmentRequest request);
        Task<Shipment> GetShipmentByIdAsync(int shipmentId);
        Task<IEnumerable<Shipment>> GetAllShipmentsAsync();
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(int shipmentId);
    }
}
