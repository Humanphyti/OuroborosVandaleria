using System;
using System.Collections.Generic;
using System.Text;

using OuroborosVandaleriaCore.Engine.Input;

namespace OuroborosVandaleriaCore.Engine.Input
{
    public class GameplayInputCommand : BaseInputCommand
    {
        public class MoveLeft : GameplayInputCommand { }
        public class MoveRight : GameplayInputCommand { }
        public class MoveUp : GameplayInputCommand { }
        public class MoveDown : GameplayInputCommand { }
        public class MeleeAttack : GameplayInputCommand { }
        public class SpellAttack : GameplayInputCommand { }
        public class PauseGame : GameplayInputCommand { }
        public class ExitGame : GameplayInputCommand { }
        public class Interact : GameplayInputCommand { }
        public class Inventory : GameplayInputCommand { }
        public class Sprint : GameplayInputCommand { }
    }
}
