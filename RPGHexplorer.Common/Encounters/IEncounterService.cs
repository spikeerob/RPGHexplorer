using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGHexplorer.Common.Encounters
{
    public interface IEncounterService
    {
        Task<List<Encounter>> ListEncountersAsync();
        Task<Encounter> GetEncounterAsync(string encounterId);
        Task<Encounter> SaveEncounterAsync(Encounter encounter);
        Task DeleteEncounterAsync(string encounterId);
    }
}