using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.State;
using OuroborosVandaleriaCore.Engine.Visuals;
using OuroborosVandaleriaGame;

using MonoGame.Extended.Tiled;
//using MonoGame.Extended.Tiled.Serialization;
//using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.CharacterControl
{
    public class Player : Actor
    {
        OuroborosVandaleria gameRef;

        Vector2 position;
        Sprite sprite;

        public Sprite Sprite
        {
            get { return sprite; }
            protected set { sprite = value; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public Player(Game game)
        {
            gameRef = (OuroborosVandaleria)game;

        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

    }
}
