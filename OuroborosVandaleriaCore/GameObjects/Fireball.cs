using OuroborosVandaleriaCore.Engine.Particles;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects
{
    public class Fireball : BaseGameObject, IGameObjectWithDamage
    {
        //these need to be set to the appropriate numbers once the engine is complete
        private const int BBPosX = 9;
        private const int BBPosY = 4;
        private const int BBWidth = 10;
        private const int BBHeigt = 22;

        private const float StartSpeed = 0.5f;
        private const float Acceleration = 0.15f;
        private float _speed = StartSpeed;

        private int _fireballHeight;
        private int _fireballWidth;

        private EmbersEmitter _embersEmitter;

        public override Vector2 Position
        {
            set
            {
                Position = value;
                _embersEmitter.Position = new Vector2(Position.X + 18, Position.Y + _fireballHeight - 10);
            }
        }

        //implement a damage fall off system in the future.
        public int Damage => 40;

        public Fireball(Texture2D fireballTexture, Texture2D embersTexture)
        {
            _sprite.Texture = fireballTexture;
            _embersEmitter = new EmbersEmitter(embersTexture, Position);
            AddBoundingBox(new Engine.Collisions.BoundingBox(new Vector2(BBPosX, BBPosY), BBWidth, BBHeigt));

            var ratio = (float)_sprite.Texture.Height / (float)_sprite.Texture.Width;
            _fireballWidth = 50;
            _fireballHeight = (int)(_fireballWidth * ratio);
        }

        public void Update(GameTime gameTime)
        {
            _embersEmitter.Update(gameTime);

            Position = new Vector2(Position.X, Position.Y - _speed);
            _speed = _speed + Acceleration;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var destRectangle = new Rectangle((int)Position.X, (int)Position.Y, _fireballWidth, _fireballHeight);
            spriteBatch.Draw(_sprite.Texture, destRectangle, Color.White);

            _embersEmitter.Render(spriteBatch);
        }
    }
}
