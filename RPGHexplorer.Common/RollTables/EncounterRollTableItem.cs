using RPGHexplorer.Common.Encounters;

namespace RPGHexplorer.Common.RollTables
{
    public class EncounterRollTableItem
    {
        public string EncounterId { get; set; }

        public int StartRoll { get; set; }

        public int EndRoll { get; set; }

        public EncounterSource EncounterSource { get; set; }

        public string EncounterSourceId { get; set; }
    }
}