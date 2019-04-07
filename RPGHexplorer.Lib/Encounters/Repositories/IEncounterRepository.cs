using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.Encounters;

namespace RPGHexplorer.Lib.Encounters.Repositories
{
    public interface IEncounterRepository
    {
        Task<List<Encounter>> GetAllAsync();
        
        Task<Encounter> GetAsync(string encounterId);

        Task SaveAsync(Encounter encounter);

        Task DeleteAsync(string encounterId);
    }
}