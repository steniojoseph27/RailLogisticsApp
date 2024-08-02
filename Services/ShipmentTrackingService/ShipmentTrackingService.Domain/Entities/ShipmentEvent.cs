namespace ShipmentTrackingService.Domain.Entities
{
    public class ShipmentEvent
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public string Location { get; set; }
        public Shipment Shipment { get; set; }
    }
}