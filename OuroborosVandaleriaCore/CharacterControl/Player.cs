using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaGame;

using MonoGame.Extended.Tiled;
//using MonoGame.Extended.Tiled.Serialization;
//using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.CharacterControl
{
    public class Player : Actor
    {
        private const float PLAYER_SPEED = 10.0f;

        public Sprite Sprite
        {
            get { return _sprite; }
            protected set { _sprite = value; }
        }

        public Player(Sprite sprite)
        {
            Sprite = sprite;
        }

        public Player(Texture2D texture)
        {
            Sprite.Texture = texture;
        }

        public void MoveLeft()
        {
            Sprite.Position = new Vector2(Sprite.Position.X - PLAYER_SPEED, Sprite.Position.Y);
        }

        public void MoveRight()
        {
            Sprite.Position = new Vector2(Sprite.Position.X + PLAYER_SPEED, Sprite.Position.Y);
        }

        public void MoveUp()
        {
            Sprite.Position = new Vector2(Sprite.Position.X, Sprite.Position.Y - PLAYER_SPEED);
        }

        public void MoveDown()
        {
            Sprite.Position = new Vector2(Sprite.Position.X, Sprite.Position.Y + PLAYER_SPEED);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

    }
}
