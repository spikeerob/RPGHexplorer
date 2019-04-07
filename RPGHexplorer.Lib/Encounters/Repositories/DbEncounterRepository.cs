using System.Collections.Generic;
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

    }
}