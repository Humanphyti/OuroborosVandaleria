using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.Engine.Visuals;
using OuroborosVandaleriaGame;

using MonoGame.Extended.Tiled;
//using MonoGame.Extended.Tiled.Serialization;
//using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.CharacterControl
{
    class Player
    {
        Camera camera;
        OuroborosVandaleria gameRef;

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public Player(Game game)
        {
            gameRef = (OuroborosVandaleria)game;
            camera = new Camera(gameRef.ScreenRectangle);
        }

        public void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

    }
}
