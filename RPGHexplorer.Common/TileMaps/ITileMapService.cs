using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.Api;

namespace RPGHexplorer.Common.TileMaps
{
    public interface ITileMapService
    {
        Task<List<Map>> ListMapsAsync();
        Task<Map> CreateMapAsync(CreateMapRequest request);
        Task<Map> GetMapAsync(string mapId);
        Task DeleteMapAsync(string mapId);
        Task<List<Tile>> GetTilesAsync(string mapId);
        Task SaveTileAsync(Tile tile);
    }
}