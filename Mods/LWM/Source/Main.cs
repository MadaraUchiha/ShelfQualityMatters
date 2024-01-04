using System.Linq;
using UnityEngine;
using Verse;

namespace ShelfQualityMatters
{
    public class Main : Mod
    {
        public ShelfQualityMattersSettings settings;

        public override string SettingsCategory() => "Shelf Quality Matters";

        public Main(ModContentPack content) : base(content)
        {
            settings = GetSettings<ShelfQualityMattersSettings>();
            var harmony = new HarmonyLib.Harmony($"MadaraUchiha.{nameof(ShelfQualityMatters)}");
            harmony.PatchAll();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var titleRect = inRect;
            Widgets.Label(titleRect, "SQM_Settings_Description".Translate());

            var listingRect = titleRect;
            listingRect.yMin += 30f;

            var listing = new Listing_Standard
            {
                ColumnWidth = 250f
            };
            listing.Begin(listingRect);

            foreach (var (key, value) in settings.qualityToItemsPerCell.ToList())
            {
                var label = $"QualityCategory_{key}".Translate();
                label += ":      ";

                var currentValue = value;
                var currentValueBuffer = value.ToString();
                listing.TextFieldNumericLabeled(label, ref currentValue, ref currentValueBuffer);
                settings.qualityToItemsPerCell[key] = currentValue;
            }

            listing.End();

            settings.Write();
        }
    }
}