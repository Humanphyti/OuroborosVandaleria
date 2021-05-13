using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OuroborosVandaleriaCore.Engine.Visuals;

using MonoGame.Extended.Tiled;

namespace OuroborosVandaleriaCore.Engine.Sprite
{
    public class AnimatedSprite : Sprite
    {
        Dictionary<AnimationKey, Animation> animations;
        AnimationKey currentAnimation;
        bool isAnimating;
        Sprite sprite;
        Vector2 velocity;
        float speed = 2.0f;

        public AnimationKey CurrentAnimation
        {
            get { return currentAnimation; }
            set { currentAnimation = value; }
        }

        public bool IsAnimating
        {
            get { return isAnimating; }
            set { isAnimating = value; }
        }

        public int Width
        {
            get { return animations[currentAnimation].FrameWidth; }
        }

        public int Height
        {
            get { return animations[currentAnimation].FrameHeight; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(speed, 1.0f, 16.0f); }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                    velocity.Normalize();
            }
        }

        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public AnimatedSprite(Sprite sprite, Dictionary<AnimationKey, Animation> animation)
        {
            animations = new Dictionary<AnimationKey, Animation>();

            foreach (AnimationKey key in animation.Keys)
                animations.Add(key, (Animation)animation[key].Clone());
        }

        public void Update(GameTime gameTime)
        {
            if (isAnimating)
                animations[currentAnimation].Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(sprite.Texture, sprite.Position - camera.Position, animations[currentAnimation].CurrentFrameRect, Color.White);
        }

        public override void LockToMap()
        {
            base.LockToMap();
        }
    }
}

/*
Something about how this animated sprite is acting like a controller class feels wrong. It shouldn't need to know the position of the
sprite it really only needs to know the rotation/Facing direction of the player object. The Controller classes should be the only classes that have
a reference to a position. The camera and eventual projectile classes are also the only things that need to know active positions to keep
themselves within the bounds of a map. I also don't believe that the Animated Sprite needs to know the speed and velocity of a character.
That should be triggered via a state passed from a controller class to the animated sprite to change the current animation state.
*/