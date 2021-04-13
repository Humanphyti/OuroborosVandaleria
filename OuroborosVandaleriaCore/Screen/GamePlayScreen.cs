using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.Controls;
using OuroborosVandaleriaCore.Engine.State;
using OuroborosVandaleriaCore.CharacterControl;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.Screen
{
    public class GamePlayScreen : BaseGameState
    {
        ContentManager Content;
        Player player;

        //constructor
        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            player = new Player(game);
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
            
            player.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            player.Camera.TiledMapRenderer.Draw();
            base.Draw(gameTime);
        }
    }
}
