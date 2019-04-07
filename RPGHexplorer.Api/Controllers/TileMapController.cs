using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGHexplorer.Common.Api;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.TileMaps.Services;

namespace RPGHexplorer.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class TileMapController : ControllerBase
    {
        private readonly ITileMapService _tileMapService;

        public TileMapController(ITileMapService tileMapService)
        {
            _tileMapService = tileMapService;
        }

        [HttpGet("maps")]
        public async Task<ActionResult<List<Map>>> List()
        {
            return await _tileMapService.ListMapsAsync();
        }
        
        [HttpPost("create-map")]
        public async Task<ActionResult<Map>> Create(CreateMapRequest request)
        {
            return await _tileMapService.CreateMapAsync(request);
        }
        
        [HttpGet("maps/{mapId}")]
        public async Task<ActionResult<Map>> GetMap(string mapId)
        {
            return await _tileMapService.GetMapAsync(mapId);
        }
        
        [HttpDelete("maps/{mapId}")]
        public async Task DeleteMap(string mapId)
        {
            await _tileMapService.DeleteMapAsync(mapId);
        }
        
        [HttpGet("maps/{mapId}/tiles")]
        public async Task<ActionResult<List<Tile>>> GetTiles(string mapId)
        {
            return await _tileMapService.GetTilesAsync(mapId);
        }
        
        [HttpPost("tiles")]
        public async Task SetTile(Tile tile)
        {
            await _tileMapService.SaveTileAsync(tile);
        }
    }
}