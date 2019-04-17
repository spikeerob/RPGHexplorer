using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.Terrain;
using RPGHexplorer.Lib.Terrain.Repositories;

namespace RPGHexplorer.Lib.Terrain
{
    public class TerrainService : ITerrainService
    {
        private ITerrainTypeRepository _terrainTypeRepository;

        public TerrainService(ITerrainTypeRepository terrainTypeRepository)
        {
            _terrainTypeRepository = terrainTypeRepository;
        }

        public Task<List<TerrainType>> ListTerrainTypesAsync()
        {
            return _terrainTypeRepository.GetAllAsync();
        }

        public Task<TerrainType> GetTerrainTypeAsync(string terrainTypeId)
        {
            return _terrainTypeRepository.GetAsync(terrainTypeId);
        }

        public async Task<TerrainType> SaveTerrainTypeAsync(TerrainType terrainType)
        {
            if (string.IsNullOrEmpty(terrainType.Id))
            {
                terrainType.Id = Guid.NewGuid().ToString();
            }
            
            await _terrainTypeRepository.SaveAsync(terrainType);

            return terrainType;
        }

        public Task DeleteTerrainTypeAsync(string terrainTypeId)
        {
            return _terrainTypeRepository.DeleteAsync(terrainTypeId);
        }
    }
}