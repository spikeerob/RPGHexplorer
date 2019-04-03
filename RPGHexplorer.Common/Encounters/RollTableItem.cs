namespace RPGHexplorer.Common.Encounters
{
    public class RollTableItem
    {
        public string EncounterId { get; set; }

        public int StartRoll { get; set; }

        public int EndRoll { get; set; }

        public EncounterSource EncounterSource { get; set; }

        public string EncounterSourceId { get; set; }
    }
}