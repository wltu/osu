// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Game.Overlays.Dialog;
using osu.Game.Scoring;
using System;
using System.Diagnostics;
using osu.Framework.Graphics.Sprites;

namespace osu.Game.Screens.Select
{
    public class LocalScoreDeleteDialog : PopupDialog
    {
        private ScoreManager scoreManager;

        public LocalScoreDeleteDialog(ScoreInfo score)
        {
            Debug.Assert(score != null);

            string accuracy = string.Format(score.Accuracy % 1 == 0 ? @"{0:P0}" : @"{0:P2}", score.Accuracy);

            BodyText = $@"{score} {Environment.NewLine} Rank: {score.Rank} - Max Combo: {score.MaxCombo} - {accuracy}";
            Icon = FontAwesome.Solid.Eraser;
            HeaderText = @"Deleting this local score. Are you sure?";
            Buttons = new PopupDialogButton[]
            {
                new PopupDialogOkButton
                {
                    Text = @"Yes. Please.",
                    Action = () => scoreManager.Delete(score)
                },
                new PopupDialogCancelButton
                {
                    Text = @"No, I'm still attached.",
                },
            };
        }

        [BackgroundDependencyLoader]
        private void load(ScoreManager scoreManager)
        {
            this.scoreManager = scoreManager;
        }
    }
}