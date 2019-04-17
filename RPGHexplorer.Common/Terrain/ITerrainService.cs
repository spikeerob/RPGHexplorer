using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGHexplorer.Common.Terrain
{
    public interface ITerrainService
    {
        Task<List<TerrainType>> ListTerrainTypesAsync();
        Task<TerrainType> GetTerrainTypeAsync(string terrainTypeId);
        Task<TerrainType> SaveTerrainTypeAsync(TerrainType terrainType);
        Task DeleteTerrainTypeAsync(string terrainTypeId);
    }
}