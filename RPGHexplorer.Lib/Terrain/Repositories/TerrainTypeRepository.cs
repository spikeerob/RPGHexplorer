using RPGHexplorer.Common.Terrain;
using RPGHexplorer.Lib.DataBases;

namespace RPGHexplorer.Lib.Terrain.Repositories
{
    public class TerrainTypeRepository : BaseDbRepository<TerrainType>, ITerrainTypeRepository
    {
        public TerrainTypeRepository(LiteDbFactory factory) : base(factory)
        {
        }

        protected override string TableName => LiteDbTables.TerrainTypes;
    }
}