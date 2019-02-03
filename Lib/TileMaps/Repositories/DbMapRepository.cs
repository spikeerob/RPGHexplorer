using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Lib.DataBases;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public class DbMapRepository : BaseDbRepository<Map>, IMapRepository
    {
        public DbMapRepository(MapDbContext context) : base(context)
        {
        }

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