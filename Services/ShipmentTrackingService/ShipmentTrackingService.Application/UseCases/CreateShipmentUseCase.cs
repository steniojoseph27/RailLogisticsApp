using ShipmentTrackingService.Application.Interfaces;
using ShipmentTrackingService.Domain.Entities;

namespace ShipmentTrackingService.Application.UseCases
{
    public class CreateShipmentUseCase
    {
        private readonly IShipmentRepository _shipmentRepository;

        public CreateShipmentUseCase(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task ExecuteAsync(Shipment shipment)
        {
            await _shipmentRepository.AddShipmentAsync(shipment);
        }

        // TODO - Implement use cases for update, delete, logger, validations, error handling, and exception handling
    }
}
