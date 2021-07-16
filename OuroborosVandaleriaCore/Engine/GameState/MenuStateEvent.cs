using System;
using System.Collections.Generic;
using System.Text;

using OuroborosVandaleriaCore.Engine.UI;

namespace OuroborosVandaleriaCore.Engine.GameState
{
    class MenuStateEvent : BaseGameStateEvent
    {
        public class ItemSelected : MenuStateEvent
        {
            public Control buttonSelected { get; private set; }
            public ItemSelected(Control uiElement)
            {
                buttonSelected = uiElement;
            }
        }
    }
}
