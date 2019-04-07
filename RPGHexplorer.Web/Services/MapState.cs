using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGHexplorer.Common.Api;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Web.Services
{
    public class MapState
    {
        private readonly ITileMapService _tileMapService;

        public MapState(ITileMapService tileMapService)
        {
            _tileMapService = tileMapService;
        }

        public Map Map { get; private set; }

        public Dictionary<string, Tile> Tiles { get; private set; }

        public event Action OnMapChange;

        public event Action OnTilesChange;

        public void SetMap(Map map, List<Tile> tiles)
        {
            Map = map;
            Tiles = tiles.ToDictionary(t => t.TileKey, t => t);
            OnMapChange?.Invoke();
            OnTilesChange?.Invoke();
        }

        public async Task LoadMapAsync(string mapId)
        {
            var map = await _tileMapService.GetMapAsync(mapId);
            var tiles = await _tileMapService.GetTilesAsync(mapId);
            
            SetMap(map, tiles);
        }

        public async Task MutateTileAsync(string tileKey, Action<Tile> mutator)
        {
            if (!Tiles.TryGetValue(tileKey, out var tile))
            {
                return;
            }
            
            mutator.Invoke(tile);

            await _tileMapService.SaveTileAsync(tile);
            
            OnTilesChange?.Invoke();
        }

        public Tile GetTile(string tileKey)
        {
            return Tiles.TryGetValue(tileKey, out var tile) ? tile : null;
        }
    }
}