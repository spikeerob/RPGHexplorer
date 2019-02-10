namespace RPGHexplorer.Common.TileMaps
{
    public class TerrainType
    {
        public static TerrainType[] All = new[]
        {
            new TerrainType
            {
                Id = "grass",
                Name = "Grass",
                ColorHex = "#50f442"
            },
            new TerrainType
            {
                Id = "forest",
                Name = "Forest",
                ColorHex = "#257025"
            },
            new TerrainType
            {
                Id = "sand",
                Name = "Sand",
                ColorHex = "#cfdb6f"
            },
            new TerrainType
            {
                Id = "water",
                Name = "Water",
                ColorHex = "#4e5eb7"
            },
        };
        
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string ColorHex { get; set; }
    }
}