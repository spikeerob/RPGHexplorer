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

    }
}