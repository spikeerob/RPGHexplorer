using System.Collections.Generic;
using System.Threading.Tasks;
using Common.TileMaps;
using RPGHexplorer.Lib.DataBases;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public class DbTileRepository : BaseDbRepository<Tile>, ITileRepository
    {
        public DbTileRepository(MapDbContext context) : base(context)
        {
        }

        public Task<List<Tile>> GetTilesAsync(string mapId)
        {
            return GetAllAsync(t => t.MapId == mapId);
        }

        public Task<Tile> GetTileAsync(string mapId, string tileId)
        {
            return GetAsync(mapId, tileId);
        }

        public Task SaveTileAsync(Tile tile)
        {
            return SaveAsync(tile);
        }

        public Task SaveTilesAsync(IEnumerable<Tile> tiles)
        {
            return SaveAsync(tiles);
        }

        public Task DeleteTileAsync(Tile tile)
        {
            return DeleteAsync(tile);
        }
    }
}