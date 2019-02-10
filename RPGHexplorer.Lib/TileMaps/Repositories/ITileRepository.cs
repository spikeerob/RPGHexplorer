using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public interface ITileRepository
    {
        Task<List<Tile>> GetTilesAsync(string mapId);

        Task<Tile> GetTileAsync(string mapId, string tileKey);

        Task SaveTileAsync(Tile tile);
        
        Task SaveTilesAsync(IEnumerable<Tile> tiles);
    }
}