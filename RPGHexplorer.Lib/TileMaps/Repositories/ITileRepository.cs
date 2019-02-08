using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public interface ITileRepository
    {
        Task<List<Tile>> GetTilesAsync(string mapId);

        Task<Tile> GetTileAsync(string mapId, string tileId);

        Task SaveTileAsync(Tile tile);
        
        Task SaveTilesAsync(IEnumerable<Tile> tiles);

        Task DeleteTileAsync(Tile tile);
    }
}