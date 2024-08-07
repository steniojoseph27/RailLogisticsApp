using Microsoft.AspNetCore.Mvc;
using ShipmentTrackingService.Application.Requests;
using ShipmentTrackingService.Application.Services;
namespace ShipmentTrackingService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        // POST: api/Shipments
        [HttpPost]
        public async Task<IActionResult> CreateShipment(CreateShipmentRequest request)
        {
            var shipment = await _shipmentService.CreateShipmentAsync(request);
            return CreatedAtAction(nameof(GetShipmentById), new { id = shipment.Id }, shipment);
        }

        // GET: api/Shipments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentById(int id)
        {
            var shipment = await _shipmentService.GetShipmentByIdAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            return Ok(shipment);
        }

        // PUT: api/Shipments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment(int id, UpdateShipmentRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var updatedShipment = await _shipmentService.UpdateShipmentAsync(request);
            if (updatedShipment == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Shipments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int shipmentId)
        {
            var deleted = await _shipmentService.DeleteShipmentAsync(shipmentId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }        
    }
}
