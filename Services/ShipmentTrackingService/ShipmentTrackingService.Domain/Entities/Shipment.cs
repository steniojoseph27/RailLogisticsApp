namespace ShipmentTrackingService.Domain.Entities
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime EstimatedArrivalTime { get; set; }
        public string CurrentLocation { get; set; } = string.Empty; 
        public string Status { get; set; } = "Pending"; 
        public int RailcarId { get; set; }
        public Railcar? Railcar { get; set; } 
        public ICollection<ShipmentEvent> ShipmentEvents { get; set; } = new List<ShipmentEvent>(); 
    }
}