using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using RPGHexplorer.Common.Api;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Web.Services
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public Task<List<Map>> ListMapsAsync()
        {
            return _client.GetJsonAsync<List<Map>>("/api/maps");
        }
        
        public Task<Map> CreateMapAsync(string name)
        {
            return _client.PostJsonAsync<Map>("/api/maps", new CreateMapRequest
            {
                Name = name,
            });
        }

        public Task<List<Tile>> GetTiles(string mapId)
        {
            return _client.GetJsonAsync<List<Tile>>($"/api/maps/{mapId}/tiles");
        }
        
        public Task<Tile> EditTileAsync(Tile tile)
        {
            var request = new EditTileRequest
            {
                TerrainTypeId = tile.TerrainTypeId,
            };
            
            return _client.PutJsonAsync<Tile>($"/api/maps/{tile.MapId}/tiles/{tile.TileKey}", request);
        }

        public Task DeleteMapAsync(string mapId)
        {
            return _client.DeleteAsync($"/api/maps/{mapId}");
        }
    }
}