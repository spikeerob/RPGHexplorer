using System.Linq;
using System.Threading.Tasks;
using RPGHexplorer.Lib.Hexes;
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

        public async Task CreateNewTileMap(string name)
        {
            await _mapRepository.SaveMapAsync(new Map
            {
                Id = "test",
                Name = name,
            });

            var tiles = HexMap.FromHexagon(4).Hexes.Select(Tile.From);
            await _tileRepository.SaveTilesAsync(tiles);
        }

        public async Task<TileMap> GetTileMap(string id)
        {
            var map = await _mapRepository.GetMapAsync(id);

            if (map == null)
            {
                return null;
            }

            var tiles = await _tileRepository.GetTilesAsync(id);

            var tileMap = new TileMap
            {
                Map = map,
                Tiles = tiles,
            };

            return tileMap;
        }
    }
}