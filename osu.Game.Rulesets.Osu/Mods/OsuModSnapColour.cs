// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Extensions.ObjectExtensions;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Screens.Edit;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Osu.Mods
{
    /// <summary>
    /// Mod that colours <see cref="HitObject"/>s based on the musical division they are on
    /// </summary>
    public class OsuModSnapColour : ModSnapColour, IApplicableToBeatmap, IApplicableToDrawableHitObject
    {
        private readonly OsuColour colours = new OsuColour();

        private IBeatmap? currentBeatmap { get; set; }

        public void ApplyToBeatmap(IBeatmap beatmap)
        {
            //Store a reference to the current beatmap to look up the beat divisor when notes are drawn
            if (currentBeatmap != beatmap)
                currentBeatmap = beatmap;
        }

        public void ApplyToDrawableHitObject(DrawableHitObject drawable)
        {
            if (currentBeatmap.IsNull() || drawable.IsNull()) return;

            drawable.ApplyCustomUpdateState += (drawableObject, state) =>
            {
                //drawableObject.EnableComboColour = false;

                int snapDivisor = currentBeatmap.ControlPointInfo.GetClosestBeatDivisor(drawableObject.HitObject.StartTime);
                Color4 snapColour = BindableBeatDivisor.GetColourFor(snapDivisor, colours);

                //The default white is too bright for kiai to be visible, so set it to a light grey
                if (snapColour.Equals(Color4.White))
                    snapColour = colours.GrayD;

                drawableObject.AccentColour.Value = snapColour;
            };
        }
    }
}
