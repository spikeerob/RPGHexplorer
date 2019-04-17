using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGHexplorer.Common.Api;
using RPGHexplorer.Common.Terrain;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Web.Services
{
    public class MapState
    {
        private readonly ITileMapService _tileMapService;
        private readonly ITerrainService _terrainService;

        public MapState(ITileMapService tileMapService, ITerrainService terrainService)
        {
            _tileMapService = tileMapService;
            _terrainService = terrainService;
        }

        public Map Map { get; private set; }

        public Dictionary<string, Tile> Tiles { get; private set; }
        
        public List<TerrainType> TerrainTypes { get; private set; }
        
        public bool IsLoaded { get; private set; }

        public event Action OnMapChange;

        public event Action OnTilesChange;

        public async Task LoadMapAsync(string mapId)
        {
            IsLoaded = false;
            
            Map = await _tileMapService.GetMapAsync(mapId);
            
            var tiles = await _tileMapService.GetTilesAsync(mapId);
            Tiles = tiles.ToDictionary(t => t.TileKey, t => t);

            TerrainTypes = await _terrainService.ListTerrainTypesAsync();

            IsLoaded = true;
            
            OnMapChange?.Invoke();
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