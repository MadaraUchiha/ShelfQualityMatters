using System.Collections.Generic;
using RimWorld;
using Verse;

namespace ShelfQualityMatters
{
    public class ShelfQualityMattersSettings : ModSettings
    {
        public Dictionary<QualityCategory, int> qualityToItemsPerCell = new Dictionary<QualityCategory, int>
        {
            {QualityCategory.Awful, 1},
            {QualityCategory.Poor, 2},
            {QualityCategory.Normal, 3},
            {QualityCategory.Good, 4},
            {QualityCategory.Excellent, 5},
            {QualityCategory.Masterwork, 6},
            {QualityCategory.Legendary, 10},
        };

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref qualityToItemsPerCell, $"{nameof(qualityToItemsPerCell)}");
        }

    }
}