using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.Terrain;

namespace RPGHexplorer.Lib.Terrain.Repositories
{
    public interface ITerrainTypeRepository
    {
        Task<List<TerrainType>> GetAllAsync();
        
        Task<TerrainType> GetAsync(string terrainTypeId);

        Task SaveAsync(TerrainType terrainType);

        Task DeleteAsync(string terrainTypeId);
    }
}