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

        public Task<Shipment> UpdateShipmentAsync(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public async Task<Shipment> UpdateShipmentAsync(UpdateShipmentRequest request)
        {
            var shipment = await _shipmentRepository.GetShipmentByIdAsync(request.Id);
            if (shipment == null)
            {
                return null;
            }

            shipment.Origin = request.Origin;
            shipment.Destination = request.Destination;
            shipment.EstimatedArrivalTime = request.EstimatedArrivalTime;
            shipment.CurrentLocation = request.CurrentLocation;
            shipment.Status = request.Status;
            shipment.RailcarId = request.RailcarId;

            await _shipmentRepository.UpdateShipmentAsync(shipment);
            return shipment;
        }

        public async Task<bool> DeleteShipmentAsync(int shipmentId)
        {
            var shipment = await _shipmentRepository.GetShipmentByIdAsync(shipmentId);
            if (shipment == null)
            {
                return false;
            }
            
            await _shipmentRepository.DeleteShipmentAsync(shipmentId!);
            return true;
        }
    }
}
