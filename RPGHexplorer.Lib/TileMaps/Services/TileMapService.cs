using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGHexplorer.Common.Api;
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

        public async Task<List<Map>> ListMapsAsync()
        {
            return await _mapRepository.GetMapsAsync();
        }
        
        public async Task<Map> CreateNewTileMap(string name)
        {
            var mapId = Guid.NewGuid().ToString();
            
            var map = new Map
            {
                Id = mapId,
                Name = name,
            };
            
            await _mapRepository.SaveMapAsync(map);

            var tiles = HexMap.FromHexagon(4).Hexes.Select(h => Tile.From(mapId, h)).ToList();
            await _tileRepository.SaveTilesAsync(tiles);

            return map;
        }

        public async Task<Map> GetMapAsync(string mapId)
        {
            var map = await _mapRepository.GetMapAsync(mapId);

            return map;
        }
        
        public async Task DeleteMapAsync(string mapId)
        {
            await _mapRepository.DeleteMapAsync(mapId);
        }

        public async Task<List<Tile>> GetTilesAsync(string mapId)
        {        
            var tiles = await _tileRepository.GetTilesAsync(mapId);

            return tiles;
        }

        public async Task EditTileAsync(string mapId, string tileKey, EditTileRequest request)
        {
            var tile = await _tileRepository.GetTileAsync(mapId, tileKey);

            tile.TerrainTypeId = request.TerrainTypeId;
            
            await _tileRepository.SaveTileAsync(tile);
        }
    }
}