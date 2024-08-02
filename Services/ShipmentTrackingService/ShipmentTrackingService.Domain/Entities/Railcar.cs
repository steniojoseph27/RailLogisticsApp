namespace ShipmentTrackingService.Domain.Entities 
{
	public class Railcar
	{
		public int Id { get; set; }
		public string RailcarNumber { get; set; } = string.Empty;
		public string RailcarType { get; set; } = string.Empty;

		public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
	}
} 