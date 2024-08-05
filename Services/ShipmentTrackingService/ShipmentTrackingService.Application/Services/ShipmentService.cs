using ShipmentTrackingService.Application.Interfaces;
using ShipmentTrackingService.Application.Requests;
using ShipmentTrackingService.Domain.Entities;

namespace ShipmentTrackingService.Application.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<Shipment> CreateShipmentAsync(CreateShipmentRequest request)
        {
            var shipment = new Shipment
            {
                Origin = request.Origin,
                Destination = request.Destination,
                EstimatedArrivalTime = request.EstimatedArrivalTime,
                CurrentLocation = request.CurrentLocation,
                Status = request.Status,
                RailcarId = request.RailcarId
            };

            await _shipmentRepository.AddShipmentAsync(shipment);

            return shipment;
        }
        
        public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
        {
            return await _shipmentRepository.GetAllShipmentsAsync();
        }

        public async Task<Shipment> GetShipmentByIdAsync(int id)
        {
            return await _shipmentRepository.GetShipmentByIdAsync(id);
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            await _shipmentRepository.UpdateShipmentAsync(shipment!);
        }

        public async Task DeleteShipmentAsync(int shipmentId)
        {
            var shipment = await _shipmentRepository.GetShipmentByIdAsync(shipmentId);
            if (shipment != null)
            {
                await _shipmentRepository.DeleteShipmentAsync(shipmentId!);
            }
        }
    }
}
