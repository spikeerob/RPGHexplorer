using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.DataBases;
using RPGHexplorer.Lib.TileMaps.Repositories;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public class DbMapRepository : BaseDbRepository<Map>, IMapRepository
    {
        public DbMapRepository(LiteDbFactory factory) : base(factory)
        {
            
        }

        protected override string TableName => LiteDbTables.Maps;

        public Task<List<Map>> GetMapsAsync()
        {
            return GetAllAsync();
        }

        public Task<Map> GetMapAsync(string mapId)
        {
            return GetAsync(mapId);
        }

        public Task SaveMapAsync(Map map)
        {
            return SaveAsync(map);
        }

        public Task DeleteMapAsync(Map map)
        {
            return DeleteAsync(map);
        }
    }
}