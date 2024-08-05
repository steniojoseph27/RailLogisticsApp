using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTrackingService.Application.Requests
{
    public class CreateShipmentRequest
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime EstimatedArrivalTime { get; set; }
        public string CurrentLocation { get; set; }
        public string Status { get; set; }
        public int RailcarId { get; set; }
    }
}
