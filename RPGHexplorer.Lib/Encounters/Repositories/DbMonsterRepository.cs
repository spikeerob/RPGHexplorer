using System.Threading.Tasks;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Lib.DataBases;

namespace RPGHexplorer.Lib.Encounters.Repositories
{
    public class DbMonsterRepository : BaseDbRepository<Monster>, IMonsterRepository
    {
        protected override string TableName => LiteDbTables.Monsters;

        public DbMonsterRepository(LiteDbFactory factory) : base(factory)
        {
        }

        public Task<Monster> GetMonsterAsync(string monsterId)
        {
            return GetAsync(monsterId);
        }

        public Task SaveMonsterAsync(Monster monster)
        {
            return SaveAsync(monster);
        }
    }
}