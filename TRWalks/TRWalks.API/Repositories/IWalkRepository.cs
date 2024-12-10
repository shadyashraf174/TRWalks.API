using TRWalks.API.Models.Domain;

namespace TRWalks.API.Repositories {
    public interface IWalkRepository {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
    }
}
