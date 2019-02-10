using RPGHexplorer.Common.Hexes;

namespace RPGHexplorer.Common.TileMaps
{
    public class Tile
    {
        public string Id { get; set; }
        
        public string MapId { get; set; }
        
        public string TileKey { get; set; }
        
        public int Q { get; set; }

        public int R { get; set; }

        public Hex Hex => Hex.FromAxialCoords(Q, R);
        
        public string TerrainTypeId { get; set; }

        public static Tile From(string mapId, int q, int r)
        {
            var tileKey = BuildTileKey(q, r);
            
            return new Tile
            {
                Id = BuildId(mapId, tileKey),
                MapId = mapId,
                TileKey = tileKey,
                Q = q,
                R = r,
            };
        }

        public static Tile From(string mapId, Hex hex)
        {
            return From(mapId, hex.Q, hex.R);
        }

        public static string BuildId(string mapId, string tileKey) => $"{mapId}.{tileKey}";

        public static string BuildTileKey(int q, int r) => $"{q}^{r}";
    }
}