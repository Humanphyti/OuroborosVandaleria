﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OuroborosVandaleriaCore.Engine.State;
using OuroborosVandaleriaCore.Engine;

namespace OuroborosVandaleriaCore.Screen
{
    public class StartMenuScreen : BaseGameState
    {
        //Constructor
        public StartMenuScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

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
            if (InputHandler.KeyReleased(Keys.Escape))
            {
                Game.Exit();
            }
            base.Draw(gameTime);
        }
    }
}
