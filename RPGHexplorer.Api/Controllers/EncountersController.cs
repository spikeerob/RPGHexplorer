using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGHexplorer.Common.Encounters;

namespace RPGHexplorer.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class EncountersController : ControllerBase
    {
        private readonly IEncounterService _encounterService;

        public EncountersController(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        [HttpGet("encounters")]
        public async Task<ActionResult<List<Encounter>>> List()
        {
            return await _encounterService.ListEncountersAsync();
        }
        
        [HttpGet("encounters/{encounterId}")]
        public async Task<ActionResult<Encounter>> Get(string encounterId)
        {
            return await _encounterService.GetEncounterAsync(encounterId);
        }
        
        [HttpPost("encounters")]
        public async Task<ActionResult<Encounter>> Save(Encounter encounter)
        {
            return await _encounterService.SaveEncounterAsync(encounter);
        }
        
        [HttpDelete("encounters/{encounterId}")]
        public async Task Save(string encounterId)
        {
            await _encounterService.DeleteEncounterAsync(encounterId);
        }
    }
}