// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Localisation;
using osu.Game.Configuration;

namespace osu.Game.Rulesets.Mods
{
    /// <summary>
    /// Mod that colours hitobjects based on the musical division they are on
    /// </summary>
    public class ModSnapColour : Mod
    {
        public override string Name => "Snap Colour";
        public override string Acronym => "SC";
        public override LocalisableString Description => "Colours hit objects based on the rhythm.";
        public override double ScoreMultiplier => 1;
        public override ModType Type => ModType.Conversion;

        [SettingSource("Whole note colour", "Change the initial size of the approach circle, relative to hit circles.", 0)]
        public BindableColour4 wholeColour { get; } = new BindableColour4(Colour4.White);
    }
}
