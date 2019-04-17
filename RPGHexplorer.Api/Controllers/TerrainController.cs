using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGHexplorer.Common.Terrain;
using RPGHexplorer.Lib.Terrain;

namespace RPGHexplorer.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class TerrainController : ControllerBase
    {
        private readonly ITerrainService _terrainService;

        public TerrainController(ITerrainService terrainService)
        {
            _terrainService = terrainService;
        }
        
        [HttpGet("terrain-types")]
        public async Task<ActionResult<List<TerrainType>>> List()
        {
            return await _terrainService.ListTerrainTypesAsync();
        }
        
        [HttpGet("terrain-types/{encounterId}")]
        public async Task<ActionResult<TerrainType>> Get(string terrainTypeId)
        {
            return await _terrainService.GetTerrainTypeAsync(terrainTypeId);
        }
        
        [HttpPost("terrain-types")]
        public async Task<ActionResult<TerrainType>> Save(TerrainType terrainType)
        {
            return await _terrainService.SaveTerrainTypeAsync(terrainType);
        }
        
        [HttpDelete("terrain-types/{encounterId}")]
        public async Task Save(string terrainTypeId)
        {
            await _terrainService.DeleteTerrainTypeAsync(terrainTypeId);
        }
    }
}