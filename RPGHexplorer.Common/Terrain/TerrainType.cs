using System.Collections.Generic;
using RPGHexplorer.Common.RollTables;

namespace RPGHexplorer.Common.Terrain
{
    public class TerrainType
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string BackgroundColorHex { get; set; }
        
        public string ForegroundColorHex { get; set; }

        public List<EncounterChance> EncounterChances { get; set; }
    }
}