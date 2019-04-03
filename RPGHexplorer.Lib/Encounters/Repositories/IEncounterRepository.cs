using System.Threading.Tasks;
using RPGHexplorer.Common.Encounters;

namespace RPGHexplorer.Lib.Encounters.Repositories
{
    public interface IEncounterRepository
    {
        Task<Encounter> GetEncounterAsync(string encounterId);

        Task SaveEncounterAsync(Encounter encounter);
    }
}