using System;
using System.Collections.Generic;
using System.Text;
using OuroborosVandaleriaGame;
using OuroborosVandaleriaCore.Engine.Controls;
using OuroborosVandaleriaCore.Engine.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.Engine.State
{
    public abstract partial class BaseGameState : GameState
    {
        protected OuroborosVandaleria GameRef;

        protected ControlManager ControlManager;

        protected PlayerIndex playerIndexInControl;

        public BaseGameState (Game game, GameStateManager manager) : base (game, manager)
        {
            GameRef = (OuroborosVandaleria)game;

            playerIndexInControl = PlayerIndex.One;
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;

            SpriteFont gameFont = Content.Load<SpriteFont>(@"RuinedKing");
            ControlManager = new ControlManager(gameFont);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime); 
        }
    }
}
