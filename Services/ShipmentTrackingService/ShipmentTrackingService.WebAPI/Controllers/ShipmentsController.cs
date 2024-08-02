using Microsoft.AspNetCore.Mvc;
using ShipmentTrackingService.Application.UseCases;
using ShipmentTrackingService.Domain.Entities;
using System.Threading.Tasks;
namespace ShipmentTrackingService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly GetShipmentDetailsUseCase _getShipmentDetailsUseCase;
        private readonly CreateShipmentUseCase _createShipmentUseCase;

        public ShipmentsController(GetShipmentDetailsUseCase getShipmentDetailsUseCase, CreateShipmentUseCase createShipmentUseCase)
        {
            _getShipmentDetailsUseCase = getShipmentDetailsUseCase;
            _createShipmentUseCase = createShipmentUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentById(int id)
        {
            var shipment = await _getShipmentDetailsUseCase.ExecuteAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            return Ok(shipment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipment([FromBody] Shipment shipment)
        {
            await _createShipmentUseCase.ExecuteAsync(shipment);
            return CreatedAtAction(nameof(GetShipmentById), new { id = shipment.Id }, shipment);
        }

        // Additional endpoints for update, delete, etc.
    }
}
