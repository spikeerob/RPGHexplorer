using System;
using System.Collections.Generic;
using System.Linq;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Common.RollTables;
using RPGHexplorer.Common.Terrain;

namespace RPGHexplorer.Lib.RollTables
{
    public class EncounterRollTableBuilder
    {
        private readonly List<EncounterItem> _encounterItems = new List<EncounterItem>();
        
        public void AddEncounter(EncounterChance encounterChance, EncounterSource source, string sourceId)
        {
            _encounterItems.Add(new EncounterItem
            {
                EncounterId = encounterChance.EncounterId,
                Weight = (int) encounterChance.ChanceLevel,
                EncounterSource = source,
                EncounterSourceId = sourceId,
            });
        }

        public void AddTerrainEncounters(TerrainType terrainType)
        {
            foreach (var encounterChance in terrainType.EncounterChances)
            {
                AddEncounter(encounterChance, EncounterSource.Terrain, terrainType.Id);
            }
        }

        public List<EncounterRollTableItem> Build()
        {
            if (_encounterItems.Count < 1)
            {
                return new List<EncounterRollTableItem>();
            }
            
            var encounterItems = _encounterItems.OrderBy(i => i.Weight).ToList();

            const int rollTotal = 100;
            var weightTotal = encounterItems.Sum(i => i.Weight);
            
            var rollLeft = rollTotal;
            foreach (var item in encounterItems)
            {
                var roll = Math.Max(1, (int) (rollTotal * item.Weight / weightTotal));
                item.EndRoll = rollLeft - 1;
                
                rollLeft = rollLeft - roll;
                item.StartRoll = rollLeft;
            }

            var finalItems = encounterItems
                .Select(i => (EncounterRollTableItem) i)
                .OrderBy(e => e.EndRoll)
                .ToList();

            // hide rounding inaccuracy by ensuring start roll always 0 
            finalItems[0].StartRoll = 0;

            return finalItems;
        }
        
        private class EncounterItem : EncounterRollTableItem
        {
            public double Weight { get; set; }
        }
    }
}