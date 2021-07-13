using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.Engine.Collisions;
using OuroborosVandaleriaCore.Engine.Animation;

using OuroborosVandaleriaGame;

using MonoGame.Extended.Tiled;

//using MonoGame.Extended.Tiled.Serialization;
//using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.CharacterControl
{
    public class Player : Actor
    {
        private Animation _idleAnimation = new Animation(true);

        private const int AnimationCellWidth = 116;
        private const int AnimationCellHeight = 116;
        private const int AnimationSpeed = 3;

        private const float PLAYER_SPEED = 10.0f;

        private const int BBPosX = 29;
        private const int BBPosY = 2;
        private const int BBWidth = 57;
        private const int BBHeight = 147;

        public Player(Texture2D texture)
        {
            _idleAnimation.AddFrames(texture, AnimationCellWidth, AnimationCellHeight, 3);
        }

        public void MoveLeft()
        {
            //Sprite.Position = new Vector2(Sprite.Position.X - PLAYER_SPEED, Sprite.Position.Y);
        }

        public void MoveRight()
        {
            //Sprite.Position = new Vector2(Sprite.Position.X + PLAYER_SPEED, Sprite.Position.Y);
        }

        public void MoveUp()
        {
            //Sprite.Position = new Vector2(Sprite.Position.X, Sprite.Position.Y - PLAYER_SPEED);
        }

        public void MoveDown()
        {
            //Sprite.Position = new Vector2(Sprite.Position.X, Sprite.Position.Y + PLAYER_SPEED);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

    }
}
