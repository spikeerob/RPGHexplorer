using System.Collections.Generic;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Common.RollTables;

namespace RPGHexplorer.Common.TileDetails
{
    public class TileDetailResponse
    {
        public string TerrainTypeId { get; set; }

        public List<EncounterRollTableItem> PossibleEncounters { get; set; }
    }
}