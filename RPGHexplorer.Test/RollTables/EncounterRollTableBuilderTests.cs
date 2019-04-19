using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Common.RollTables;
using RPGHexplorer.Lib.RollTables;

namespace RPGHexplorer.Test.RollTables
{
    public class EncounterRollTableBuilderTests : BaseFixture
    {
        private const string TestSourceId = "TestSource";
        
        private EncounterRollTableBuilder _builder;
        

        protected override void SetUp()
        {
            _builder = new EncounterRollTableBuilder();
        }

        private void AddEncounter(string encounterId, ChanceLevel chance)
        {
            var encounterChance = new EncounterChance {EncounterId = encounterId, ChanceLevel = chance};
            _builder.AddEncounter(encounterChance, EncounterSource.Unknown, TestSourceId);
        }

        private void CheckResultMatches(params EncounterRollTableItem[] expectedItems)
        {
            var result = _builder.Build();

            result.Should().BeEquivalentTo(expectedItems.ToList());
        }

        private EncounterRollTableItem EncounterItem(string id, int start, int end) => new EncounterRollTableItem
        {
            EncounterId = id,
            StartRoll = start,
            EndRoll = end,
            EncounterSourceId = TestSourceId,
        };
        
        [Test]
        public void TestSingleItemFillsTable()
        {
            AddEncounter("1", ChanceLevel.NearlyNever1);

            CheckResultMatches(
                EncounterItem("1", 0, 99)
            );
        }

        [Test]
        public void TestTwoEqualItems()
        {
            AddEncounter("1", ChanceLevel.NearlyNever1);
            AddEncounter("2", ChanceLevel.NearlyNever1);

            CheckResultMatches(
                EncounterItem("2", 0, 49),
                EncounterItem("1", 50, 99)
            );
        }
        
        [Test]
        public void TestTwoUnequalItems()
        {
            AddEncounter("1", ChanceLevel.Rarely25);
            AddEncounter("2", ChanceLevel.Likely75);

            CheckResultMatches(
                EncounterItem("2", 0, 74),
                EncounterItem("1", 75, 99)
            );
        }
        
        [Test]
        public void TestMultipleItems()
        {
            AddEncounter("1", ChanceLevel.NearlyNever1);
            AddEncounter("2", ChanceLevel.Improbable5);
            AddEncounter("3", ChanceLevel.Rarely25);
            AddEncounter("4", ChanceLevel.Occasionally50);
            AddEncounter("5", ChanceLevel.Likely75);
            AddEncounter("6", ChanceLevel.Expected95);
            AddEncounter("7", ChanceLevel.AlmostCertain99);

            CheckResultMatches(
                EncounterItem("7", 0, 28),
                EncounterItem("6", 29, 55),
                EncounterItem("5", 56, 76),
                EncounterItem("4", 77, 90),
                EncounterItem("3", 91, 97),
                EncounterItem("2", 98, 98),
                EncounterItem("1", 99, 99)
            );
        }
    }
}