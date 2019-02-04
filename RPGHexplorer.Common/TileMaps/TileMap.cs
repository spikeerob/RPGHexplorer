using System.Collections.Generic;

namespace RPGHexplorer.Common.TileMaps
{
    public class TileMap
    {
        public Map Map { get; set; }

        public List<Tile> Tiles { get; set; }

        public static TileMap From(Map map, List<Tile> tiles)
        {
            return new TileMap
            {
                Map = map,
                Tiles = tiles,
            };
        }
    }
}