using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Lib.Encounters.Repositories;

namespace RPGHexplorer.Lib.Encounters
{
    public class EncounterService : IEncounterService
    {
        private readonly IEncounterRepository _encounterRepository;

        public EncounterService(IEncounterRepository encounterRepository)
        {
            _encounterRepository = encounterRepository;
        }

        public async Task<List<Encounter>> ListEncountersAsync()
        {
            return await _encounterRepository.GetAllAsync();
        }

        public async Task<Encounter> GetEncounterAsync(string encounterId)
        {
            return await _encounterRepository.GetAsync(encounterId);
        }

        public async Task<Encounter> SaveEncounterAsync(Encounter encounter)
        {
            if (encounter.Id == null)
            {
                encounter.Id = Guid.NewGuid().ToString();
            }
            
            await _encounterRepository.SaveAsync(encounter);

            return encounter;
        }

        public async Task DeleteEncounterAsync(string encounterId)
        {
            await _encounterRepository.DeleteAsync(encounterId);
        }
    }
}