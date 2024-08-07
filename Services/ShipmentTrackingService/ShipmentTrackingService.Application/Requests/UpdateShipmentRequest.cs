using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTrackingService.Application.Requests
{
    public class UpdateShipmentRequest
    {
        public int Id { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime EstimatedArrivalTime { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int RailcarId { get; set; }
    }
}
