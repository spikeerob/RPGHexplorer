using RPGHexplorer.Common.Hexes;

namespace RPGHexplorer.Common.TileMaps
{
    public class Tile
    {
        public string TileId { get; private set; }
        
        public string MapId { get; set; }

        public int Q => int.Parse(TileId.Split('^')[0]);

        public int R => int.Parse(TileId.Split('^')[1]);

        public Hex Hex => Hex.FromAxialCoords(Q, R);

        public static Tile From(string mapId, int q, int r)
        {
            return new Tile
            {
                TileId = $"{q}^{r}",
                MapId = mapId,
            };
        }

        public static Tile From(string mapId, Hex hex)
        {
            return From(mapId, hex.Q, hex.R);
        }
    }
}