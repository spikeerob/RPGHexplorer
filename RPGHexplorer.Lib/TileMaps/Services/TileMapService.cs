using System.Linq;
using System.Threading.Tasks;
using RPGHexplorer.Common.Hexes;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.TileMaps.Repositories;

namespace RPGHexplorer.Lib.TileMaps.Services
{
    public class TileMapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly ITileRepository _tileRepository;

        public TileMapService(IMapRepository mapRepository, ITileRepository tileRepository)
        {
            _mapRepository = mapRepository;
            _tileRepository = tileRepository;
        }

        public async Task<TileMap> CreateNewTileMap(string name)
        {
            var map = new Map
            {
                Id = "test",
                Name = name,
            };
            
            await _mapRepository.SaveMapAsync(map);

            var tiles = HexMap.FromHexagon(4).Hexes.Select(Tile.From).ToList();
            await _tileRepository.SaveTilesAsync(tiles);
            
            return TileMap.From(map, tiles);
        }

        public async Task<TileMap> GetTileMap(string id)
        {
            var map = await _mapRepository.GetMapAsync(id);

            if (map == null)
            {
                return null;
            }

            var tiles = await _tileRepository.GetTilesAsync(id);

            return TileMap.From(map, tiles);
        }
    }
}