using Dapper;
using ShipmentTrackingService.Application.Interfaces;
using ShipmentTrackingService.Domain.Entities;
using System.Data;

namespace ShipmentTrackingService.Infrastructure.Data.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ShipmentDbContext _dbContext;

        public ShipmentRepository(ShipmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Shipment> GetShipmentByIdAsync(int shipmentId)
        {
            var query = @"SELECT * FROM Shipments WHERE Id = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Shipment>(query, new { Id = shipmentId });
            }           
        }

        public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
        {
            var query = "SELECT * FROM Shipments";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Shipment>(query);
            }
        }

        public async Task AddShipmentAsync(Shipment shipment)
        {
            var query = "INSERT INTO Shipments (Origin, Destination, EstimatedArrivalTime, CurrentLocation, Status, RailcarId) VALUES (@Origin, @Destination, @EstimatedArrivalTime, @CurrentLocation, @Status, @RailcarId)";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, shipment);
            }
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            var query = "UPDATE Shipments SET Origin = @Origin, Destination = @Destination, EstimatedArrivalTime = @EstimatedArrivalTime, CurrentLocation = @CurrentLocation, Status = @Status, RailcarId = @RailcarId WHERE Id = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, shipment);
            }
        }

        public async Task DeleteShipmentAsync(int shipmentId)
        {
            var query = "DELETE FROM Shipments WHERE Id = @shipmentId";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = shipmentId });
            }
        }
    }

    // TODO - Implement ShipmentEventRepository and RailcarRepository similarly
}
