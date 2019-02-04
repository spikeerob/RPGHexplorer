using RPGHexplorer.Common.Hexes;

namespace RPGHexplorer.Common.TileMaps
{
    public class Tile
    {
        public string Id { get; private set; }
        
        public string MapId { get; set; }

        public int Q => int.Parse(Id.Split('-')[0]);

        public int R => int.Parse(Id.Split('-')[1]);

        public Hex Hex => Hex.FromAxialCoords(Q, R);

        public static Tile From(int Q, int R)
        {
            return new Tile
            {
                Id = $"{Q}-{R}",
            };
        }

        public static Tile From(Hex hex)
        {
            return From(hex.Q, hex.R);
        }
    }
}