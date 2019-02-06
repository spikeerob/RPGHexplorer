using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.Services;

namespace RPGHexplorer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TileMapController : ControllerBase
    {
        private readonly TileMapService _tileMapService;

        public TileMapController(TileMapService tileMapService)
        {
            _tileMapService = tileMapService;
        }

        [HttpPost]
        public async Task<ActionResult<TileMap>> Create(/*[FromBody] string value*/)
        {
            return await _tileMapService.CreateNewTileMap("test");
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TileMap>> Get(string id = "test")
        {
            return await _tileMapService.GetTileMap(id);
        }
    }
}