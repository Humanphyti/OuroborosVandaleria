using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace OuroborosVandaleriaCore.Engine.Input
{
    public class GameplayInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<GameplayInputCommand>();

            if (state.IsKeyDown(Keys.OemTilde))
            {
                commands.Add(new GameplayInputCommand.ExitGame());
            }

            if (state.IsKeyDown(Keys.Escape))
            {
                commands.Add(new GameplayInputCommand.PauseGame());
            }

            if (state.IsKeyDown(Keys.Tab))
            {
                commands.Add(new GameplayInputCommand.Inventory());
            }

            if (state.IsKeyDown(Keys.E))
            {
                commands.Add(new GameplayInputCommand.Interact());
            }

            if (state.IsKeyDown(Keys.Space))
            {
                commands.Add(new GameplayInputCommand.MeleeAttack());
            }

            if (state.IsKeyDown(Keys.S))
            {
                commands.Add(new GameplayInputCommand.MoveDown());
            }

            if (state.IsKeyDown(Keys.A))
            {
                commands.Add(new GameplayInputCommand.MoveLeft());
            }

            if (state.IsKeyDown(Keys.D))
            {
                commands.Add(new GameplayInputCommand.MoveRight());
            }

            if (state.IsKeyDown(Keys.W))
            {
                commands.Add(new GameplayInputCommand.MoveUp());
            }

            if (state.IsKeyDown(Keys.Q))
            {
                commands.Add(new GameplayInputCommand.SpellAttack());
            }

            if (state.IsKeyDown(Keys.LeftShift))
            {
                commands.Add(new GameplayInputCommand.Sprint());
            }
            
            return commands;
        }
    }
}
