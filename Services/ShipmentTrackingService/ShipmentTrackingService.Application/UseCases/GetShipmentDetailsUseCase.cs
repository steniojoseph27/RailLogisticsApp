using ShipmentTrackingService.Application.Interfaces;
using ShipmentTrackingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTrackingService.Application.UseCases
{
    public class GetShipmentDetailsUseCase
    {
        private readonly IShipmentRepository _shipmentRepository;

        public GetShipmentDetailsUseCase(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<Shipment> ExecuteAsync(int id)
        {
            return await _shipmentRepository.GetShipmentByIdAsync(id);
        }

        // TODO - Implement logger, validations, error handling, and exception handling
    }
}
