using ShipmentTrackingService.Domain.Entities;

namespace ShipmentTrackingService.Application.Interfaces
{
    public interface IRailcarRepository
    {
        Task<Railcar> GetRailcarByIdAsync(int id);
        Task<IEnumerable<Railcar>> GetAllRailcarsAsync();
    }
}
