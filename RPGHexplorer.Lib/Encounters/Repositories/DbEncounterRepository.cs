using System.Threading.Tasks;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Lib.DataBases;

namespace RPGHexplorer.Lib.Encounters.Repositories
{
    public class DbEncounterRepository : BaseDbRepository<Encounter>, IEncounterRepository
    {
        protected override string TableName => LiteDbTables.Encounters;
        
        public DbEncounterRepository(LiteDbFactory factory) : base(factory)
        {
        }

        public Task<Encounter> GetEncounterAsync(string encounterId)
        {
            return GetAsync(encounterId);
        }

        public Task SaveEncounterAsync(Encounter encounter)
        {
            return SaveAsync(encounter);
        }
    }
}