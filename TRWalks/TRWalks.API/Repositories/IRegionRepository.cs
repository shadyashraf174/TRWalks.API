using TRWalks.API.Models.Domain;

namespace TRWalks.API.Repositories {
    public interface IRegionRepository {
        Task<List<Region>> GetAllAsync();

    }
}
