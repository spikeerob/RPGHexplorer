namespace RPGHexplorer.Common.Api
{
    public class EditTileRequest
    {
        public string MapId { get; set; }

        public string TileKey { get; set; }
        
        public string TerrainTypeId { get; set; }
    }
}