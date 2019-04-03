using System.Collections.Generic;

namespace RPGHexplorer.Common.Encounters
{
    public class Encounter
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public List<EncounterMonster> EncounterMonsters { get; set; }
    }
}