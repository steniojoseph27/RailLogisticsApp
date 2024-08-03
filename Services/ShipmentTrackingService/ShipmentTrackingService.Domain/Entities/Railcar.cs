namespace ShipmentTrackingService.Domain.Entities 
{
	public class Railcar
	{
		public int Id { get; set; }
        public string RailcarType { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
		public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
	}
} 