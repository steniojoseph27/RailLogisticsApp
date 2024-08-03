using Dapper;
using ShipmentTrackingService.Application.Interfaces;
using ShipmentTrackingService.Domain.Entities;
using System.Data;

namespace ShipmentTrackingService.Infrastructure.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly IDbConnection _dbConnection;

        public ShipmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Shipment> GetShipmentByIdAsync(int id)
        {
            var query = "SELECT * FROM Shipments WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Shipment>(query, new { Id = id });
        }

        public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
        {
            var query = "SELECT * FROM Shipments";
            return await _dbConnection.QueryAsync<Shipment>(query);
        }

        public async Task AddShipmentAsync(Shipment shipment)
        {
            var query = "INSERT INTO Shipments (Origin, Destination, EstimatedArrivalTime, CurrentLocation, Status, RailcarId) VALUES (@Origin, @Destination, @EstimatedArrivalTime, @CurrentLocation, @Status, @RailcarId)";
            await _dbConnection.ExecuteAsync(query, shipment);
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            var query = "UPDATE Shipments SET Origin = @Origin, Destination = @Destination, EstimatedArrivalTime = @EstimatedArrivalTime, CurrentLocation = @CurrentLocation, Status = @Status, RailcarId = @RailcarId WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, shipment);
        }

        public async Task DeleteShipmentAsync(int id)
        {
            var query = "DELETE FROM Shipments WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }

    // Implement ShipmentEventRepository and RailcarRepository similarly
}
