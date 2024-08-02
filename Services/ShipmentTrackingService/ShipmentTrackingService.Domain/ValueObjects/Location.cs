namespace ShipmentTrackingService.Domain.ValueObjects 
{ 
	public record Location(string Latitude, string Longitude)
	{
		// TODO - Validation logic to ensure valid coordinates can go here
	}
}

