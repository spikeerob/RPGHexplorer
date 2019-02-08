using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.DataBases;
using RPGHexplorer.Lib.TileMaps.Repositories;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public class DbTileRepository : BaseDbRepository<Tile>, ITileRepository
    {
        public DbTileRepository(LiteDbFactory factory) : base(factory)
        {
        }

        protected override string TableName => LiteDbTables.Tiles;

        public Task<List<Tile>> GetTilesAsync(string mapId)
        {
            return GetAllAsync(t => t.MapId == mapId);
        }

        public Task<Tile> GetTileAsync(string mapId, string tileId)
        {
            return GetAsync(t => t.MapId == mapId && t.TileId == tileId);
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