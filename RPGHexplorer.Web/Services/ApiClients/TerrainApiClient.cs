using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using RPGHexplorer.Common.Terrain;

namespace RPGHexplorer.Web.Services.ApiClients
{
    public class TerrainApiClient : ITerrainService
    {
        private readonly HttpClient _client;

        public TerrainApiClient(HttpClient client)
        {
            _client = client;
        }

        public Task<List<TerrainType>> ListTerrainTypesAsync()
        {
            return _client.GetJsonAsync<List<TerrainType>>("/api/terrain-types");
        }

        public Task<TerrainType> GetTerrainTypeAsync(string terrainTypeId)
        {
            return _client.GetJsonAsync<TerrainType>($"/api/terrain-types/{terrainTypeId}");
        }

        public Task<TerrainType> SaveTerrainTypeAsync(TerrainType terrainType)
        {
            return _client.PostJsonAsync<TerrainType>("/api/terrain-types", terrainType);
        }

        public Task DeleteTerrainTypeAsync(string terrainTypeId)
        {
            return _client.DeleteAsync($"/api/terrain-types/{terrainTypeId}");
        }
    }
}