using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using RPGHexplorer.Common.Encounters;

namespace RPGHexplorer.Web.Services
{
    public class EncounterApiClient : IEncounterService
    {
        private readonly HttpClient _client;

        public EncounterApiClient(HttpClient client)
        {
            _client = client;
        }

        public Task<List<Encounter>> ListEncountersAsync()
        {
            return _client.GetJsonAsync<List<Encounter>>("/api/encounters");
        }

        public Task<Encounter> GetEncounterAsync(string encounterId)
        {
            return _client.GetJsonAsync<Encounter>($"/api/encounters/{encounterId}");
        }

        public Task<Encounter> SaveEncounterAsync(Encounter encounter)
        {
            return _client.PostJsonAsync<Encounter>($"/api/encounters", encounter);
        }

        public Task DeleteEncounterAsync(string encounterId)
        {
            return _client.DeleteAsync($"/api/encounters/{encounterId}");
        }
    }
}