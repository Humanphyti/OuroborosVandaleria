using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Engine.Input
{
    public class MenuInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<MenuInputCommand>();

            if (state.IsKeyDown(Keys.Enter))
            {
                commands.Add(new MenuInputCommand.ItemSelect());
            }

            if (state.IsKeyDown(Keys.Escape))
            {
                commands.Add(new MenuInputCommand.UniversalBack());
            }

            if (state.IsKeyDown(Keys.W))
            {
                commands.Add(new MenuInputCommand.NavigateUp());
            }

            if (state.IsKeyDown(Keys.S))
            {
                commands.Add(new MenuInputCommand.NavigateDown());
            }

            if (state.IsKeyDown(Keys.A))
            {
                commands.Add(new MenuInputCommand.NavgiateLeft());
            }

            if (state.IsKeyDown(Keys.D))
            {
                commands.Add(new MenuInputCommand.NavigateRight());
            }

            if (state.IsKeyDown(Keys.Q))
            {
                commands.Add(new MenuInputCommand.ScreenLeft());
            }

            if (state.IsKeyDown(Keys.E))
            {
                commands.Add(new MenuInputCommand.ScreenRight());
            }

            if (state.IsKeyDown(Keys.Z))
            {
                commands.Add(new MenuInputCommand.BankLeft());
            }

            if (state.IsKeyDown(Keys.X))
            {
                commands.Add(new MenuInputCommand.BankRight());
            }

            /*if (state.IsKeyDown(Keys.A))
            {
                commands.Add(new MenuInputCommand.)
            }

            if (state.IsKeyDown(Keys.A))
            {
                commands.Add(new MenuInputCommand.)
            }*/
            return commands;
        }

        public override IEnumerable<BaseInputCommand> GetGamePadState(GamePadState state)
        {
            var commands = new List<MenuInputCommand>();

            if (state.IsButtonDown(Buttons.A) || state.IsButtonDown(Buttons.Start))
            {
                commands.Add(new MenuInputCommand.ItemSelect());
            }

            if (state.IsButtonDown(Buttons.B))
            {
                commands.Add(new MenuInputCommand.UniversalBack());
            }

            if (state.IsButtonDown(Buttons.DPadUp) || state.ThumbSticks.Left.Y < -0.5f)
            {
                commands.Add(new MenuInputCommand.NavigateUp());
            }

            if (state.IsButtonDown(Buttons.DPadDown) || state.ThumbSticks.Left.Y > 0.5f)
            {
                commands.Add(new MenuInputCommand.NavigateDown());
            }

            if (state.IsButtonDown(Buttons.DPadLeft) || state.ThumbSticks.Left.X < -0.5f)
            {
                commands.Add(new MenuInputCommand.NavgiateLeft());
            }

            if (state.IsButtonDown(Buttons.DPadRight) || state.ThumbSticks.Left.X < 0.5f)
            {
                commands.Add(new MenuInputCommand.NavigateRight());
            }

            if (state.IsButtonDown(Buttons.LeftShoulder))
            {
                commands.Add(new MenuInputCommand.ScreenLeft());
            }

            if (state.IsButtonDown(Buttons.RightShoulder))
            {
                commands.Add(new MenuInputCommand.ScreenRight());
            }

            if (state.IsButtonDown(Buttons.X))
            {
                commands.Add(new MenuInputCommand.BankLeft());
            }

            if (state.IsButtonDown(Buttons.Y))
            {
                commands.Add(new MenuInputCommand.BankRight());
            }

            return commands;
        }
    }
}
