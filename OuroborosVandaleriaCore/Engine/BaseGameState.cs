using System;
using System.Collections.Generic;
using System.Text;
using OuroborosVandaleriaGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.Engine
{
    public abstract partial class BaseGameState : GameState
    {
        protected OuroborosVandaleria GameRef;
        public BaseGameState (Game game, GameStateManager manager) : base (game, manager)
        {
            GameRef = (OuroborosVandaleria)game;
        }
    }
}
