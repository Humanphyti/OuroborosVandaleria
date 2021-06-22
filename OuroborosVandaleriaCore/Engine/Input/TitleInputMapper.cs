using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace OuroborosVandaleriaCore.Engine.Input
{
    public class TitleInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<TitleInputCommand>();

            if(state.GetPressedKeyCount() != 0)
            {
                commands.Add(new TitleInputCommand.GameSelect());
            }

            return commands;
        }
    }
}
