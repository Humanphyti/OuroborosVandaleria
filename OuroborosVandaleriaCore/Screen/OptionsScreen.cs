using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.State;

namespace OuroborosVandaleriaCore.Screen
{
    public class OptionsScreen : BaseGameState
    {
        public OptionsScreen(Game game, GameStateManager manager) : base(game, manager)
        {

        }

        //override methods
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
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
