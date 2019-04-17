using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using RPGHexplorer.Common.Api;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Web.Services
{
    public class TileMapApiClient : ITileMapService
    {
        private readonly HttpClient _client;

        public TileMapApiClient(HttpClient client)
        {
            _client = client;
        }

        public Task<List<Map>> ListMapsAsync()
        {
            return _client.GetJsonAsync<List<Map>>("/api/maps");
        }
        
        public Task<Map> CreateMapAsync(CreateMapRequest request)
        {
            return _client.PostJsonAsync<Map>("/api/create-map", request);
        }

        public Task<Map> GetMapAsync(string mapId)
        {
            return _client.GetJsonAsync<Map>($"/api/maps/{mapId}");
        }

        public Task<List<Tile>> GetTilesAsync(string mapId)
        {
            return _client.GetJsonAsync<List<Tile>>($"/api/maps/{mapId}/tiles");
        }
        
        public Task SaveTileAsync(Tile tile)
        {
            return _client.PostJsonAsync($"/api/tiles", tile);
        }

        public Task DeleteMapAsync(string mapId)
        {
            return _client.DeleteAsync($"/api/maps/{mapId}");
        }
    }
}