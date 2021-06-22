using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Engine.GameState
{
    public class BaseGameStateEvent
    {
        public class GameQuit : BaseGameStateEvent { }

        public class GamePause : BaseGameStateEvent { }
    }
}
