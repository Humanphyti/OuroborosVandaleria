using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace OuroborosVandaleriaCore.Engine.Particles
{
    public class Particle : Sprite.Sprite
    {
        public float Opacity
        {
            get; private set;
        }

        private int _lifespan;
        private int _age;
        private Vector2 _direction;
        private Vector2 _gravity;
        private float _velocity;
        private float _acceleration;
        private float _opacityFadingRate;

        public Particle() { }

        public void Activate(int lifespan, Vector2 position, Vector2 direction, Vector2 gravity, float velocity, float acceleration, float scale, float rotation, float opacity, float opacityFadingRate)
        {
            _lifespan = lifespan;
            _direction = direction;
            _velocity = velocity;
            _gravity = gravity;
            _acceleration = acceleration;
            Rotation = rotation;
            _opacityFadingRate = opacityFadingRate;
            _age = 0;

            Position = position;
            Opacity = opacity;
            ScaleFactor = scale;
        }

        public bool Update(GameTime gameTime)
        {
            _velocity *= _acceleration;
            _direction += _gravity;

            var positionDelta = _direction * _velocity;

            Position += positionDelta;

            Opacity *= _opacityFadingRate;

            _age++;
            return _age < _lifespan;
        }
    }
}
