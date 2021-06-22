using System;
using System.Collections.Generic;
using System.Text;

using OuroborosVandaleriaCore.Engine.GameState;

namespace OuroborosVandaleriaCore.Engine.Events
{
    class GamePlayEvents : BaseGameStateEvent
    {
        public class PlayerCasts : GamePlayEvents { }
        public class PlayerAttacks : GamePlayEvents { }
        public class PlayerPasues : GamePlayEvents { }
        public class PlayerOpenInventory : GamePlayEvents { }
    }
}
