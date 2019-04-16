namespace RPGHexplorer.Common.Terrain
{
    public class TerrainType
    {
        public static TerrainType[] All = new[]
        {
            new TerrainType
            {
                Id = "grass",
                Name = "Grass",
                BackgroundColorHex = "#50f442"
            },
            new TerrainType
            {
                Id = "forest",
                Name = "Forest",
                BackgroundColorHex = "#257025",
                ForegroundColorHex = "#459045",
            },
            new TerrainType
            {
                Id = "mountain",
                Name = "Mountain",
                BackgroundColorHex = "#555555",
                ForegroundColorHex = "#999999",
            },
            new TerrainType
            {
                Id = "sand",
                Name = "Sand",
                BackgroundColorHex = "#cfdb6f"
            },
            new TerrainType
            {
                Id = "water",
                Name = "Water",
                BackgroundColorHex = "#4e5eb7"
            },
        };
        
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string BackgroundColorHex { get; set; }
        
        public string ForegroundColorHex { get; set; }
    }
}