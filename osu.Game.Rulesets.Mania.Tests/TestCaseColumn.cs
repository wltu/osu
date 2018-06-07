﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Allocation;
using osu.Game.Rulesets.Mania.UI;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Mania.Tests
{
    [TestFixture]
    public class TestCaseColumn : ManiaInputTestCase
    {
        public TestCaseColumn()
            : base(1)
        {
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Child = new ManiaInputManager(new ManiaRuleset().RulesetInfo, 1)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Height = 0.85f,
                Child = new Column
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    AccentColour = Color4.OrangeRed,
                    Action = ManiaAction.Special1
                }
            };
        }
    }
}
