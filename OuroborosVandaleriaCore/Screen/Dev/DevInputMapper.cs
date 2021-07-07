using OuroborosVandaleriaCore.Engine.Input;

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace OuroborosVandaleriaCore.Screen.Dev
{
    public class DevInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<DevInputCommand>();
            if (state.IsKeyDown(Keys.Escape))
                commands.Add(new DevInputCommand.DevQuit());

            if (state.IsKeyDown(Keys.Space))
                commands.Add(new DevInputCommand.DevCast());

            return commands;
        }

        public override IEnumerable<BaseInputCommand> GetGamePadState(GamePadState state)
        {
            var commands = new List<DevInputCommand>();
            if (state.IsButtonDown(Buttons.Start))
                commands.Add(new DevInputCommand.DevQuit());

            if (state.IsButtonDown(Buttons.Back))
                commands.Add(new DevInputCommand.DevPause());

            if (state.IsButtonDown(Buttons.DPadUp) || state.IsButtonDown(Buttons.LeftThumbstickUp))
                commands.Add(new DevInputCommand.DevMoveUp());

            if (state.IsButtonDown(Buttons.DPadDown) || state.IsButtonDown(Buttons.LeftThumbstickDown))
                commands.Add(new DevInputCommand.DevMoveDown());

            if (state.IsButtonDown(Buttons.DPadLeft) || state.IsButtonDown(Buttons.LeftThumbstickLeft))
                commands.Add(new DevInputCommand.DevMoveLeft());

            if (state.IsButtonDown(Buttons.DPadRight) || state.IsButtonDown(Buttons.LeftThumbstickRight))
                commands.Add(new DevInputCommand.DevMoveRight());

            if (state.IsButtonDown(Buttons.X))
                commands.Add(new DevInputCommand.DevStab());

            if (state.IsButtonDown(Buttons.Y))
                commands.Add(new DevInputCommand.DevCast());

            //if(state.IsButtonDown(Buttons.A))
                //commands.Add(new DevInputCommand.DevInteract());
            return commands;
        }
    }
}
