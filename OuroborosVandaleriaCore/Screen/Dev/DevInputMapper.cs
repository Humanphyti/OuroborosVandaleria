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
    }
}
