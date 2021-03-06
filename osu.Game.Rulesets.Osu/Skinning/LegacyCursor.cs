// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Skinning;
using osu.Game.Rulesets.Osu.UI.Cursor;
using osuTK;

namespace osu.Game.Rulesets.Osu.Skinning
{
    public class LegacyCursor : OsuCursorSprite
    {
        private bool spin;

        public LegacyCursor()
        {
            Size = new Vector2(50);

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(ISkinSource skin)
        {
            spin = skin.GetConfig<OsuSkinConfiguration, bool>(OsuSkinConfiguration.CursorRotate)?.Value ?? true;

            InternalChildren = new[]
            {
                new NonPlayfieldSprite
                {
                    Texture = skin.GetTexture("cursormiddle"),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                },
                ExpandTarget = new NonPlayfieldSprite
                {
                    Texture = skin.GetTexture("cursor"),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
            };
        }

        protected override void LoadComplete()
        {
            if (spin)
                ExpandTarget.Spin(10000, RotationDirection.Clockwise);
        }
    }
}
