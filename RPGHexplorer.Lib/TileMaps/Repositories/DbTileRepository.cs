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

        public Task<List<Tile>> GetAllAsync(string mapId)
        {
            return GetAllAsync(t => t.MapId == mapId);
        }

        public Task<Tile> GetAsync(string mapId, string tileKey)
        {
            return base.GetAsync(Tile.BuildId(mapId, tileKey));
        }
    }
}