using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGHexplorer.Common.Api;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.TileMaps.Services;

namespace RPGHexplorer.Api.Controllers
{
    [Route("api/maps")]
    [ApiController]
    public class TileMapController : ControllerBase
    {
        private readonly TileMapService _tileMapService;

        public TileMapController(TileMapService tileMapService)
        {
            _tileMapService = tileMapService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Map>>> List()
        {
            return await _tileMapService.ListMapsAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<Map>> Create(CreateMapRequest request)
        {
            return await _tileMapService.CreateNewTileMap(request.Name);
        }
        
        [HttpGet("{mapId}")]
        public async Task<ActionResult<Map>> GetMap(string mapId)
        {
            return await _tileMapService.GetMapAsync(mapId);
        }
        
        [HttpDelete("{mapId}")]
        public async Task DeleteMap(string mapId)
        {
            await _tileMapService.DeleteMapAsync(mapId);
        }
        
        [HttpGet("{mapId}/tiles")]
        public async Task<ActionResult<List<Tile>>> GetTiles(string mapId)
        {
            return await _tileMapService.GetTilesAsync(mapId);
        }
        
        [HttpPut("{mapId}/tiles/{tileKey}")]
        public async Task SetTile(string mapId, string tileKey, EditTileRequest request)
        {
            await _tileMapService.EditTileAsync(mapId, tileKey, request);
        }
    }
}