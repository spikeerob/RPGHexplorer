using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public interface ITileRepository
    {
        Task<List<Tile>> GetAllAsync(string mapId);

        Task<Tile> GetAsync(string mapId, string tileKey);

        Task SaveAsync(Tile tile);
        
        Task SaveAsync(IEnumerable<Tile> tiles);
    }
}