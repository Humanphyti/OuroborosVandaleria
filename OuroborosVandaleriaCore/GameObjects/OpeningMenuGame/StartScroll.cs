using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OuroborosVandaleriaCore.Engine.Animation;
using OuroborosVandaleriaCore.Engine.Sprite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects.OpeningMenuGame
{
    class StartScroll : BaseGameObject
    {
        
        private Animation unfurlScroll = new Animation(false);
        private const int AnimationSpeed = 3;
        private const int frameWidth = 208;
        private int frameHeight;
        private Animation _currentAnimation;

        private Rectangle _startingSprite;

        private bool isAnimating;
        public bool IsAnimating
        {
            get;
            set;
        }



        public StartScroll(Texture2D texture)
        {
            frameHeight = texture.Height;
            isAnimating = false;
            _startingSprite = new Rectangle(208, 0, frameWidth, frameHeight);
            unfurlScroll.AddFrames(texture, frameWidth, frameHeight, AnimationSpeed);
        }

        public void PlayAnimation()
        {
            if(isAnimating)
                _currentAnimation = unfurlScroll;
        }

        public void Update(GameTime gameTime)
        {
            if(_currentAnimation != null)
            {
                _currentAnimation.Update(gameTime);
            }
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, frameWidth, frameHeight);
            var sourceRectangle = _startingSprite;
            if(_currentAnimation != null)
            {
                var currentFrame = _currentAnimation.CurrentFrame;
                if(currentFrame != null)
                {
                    sourceRectangle = currentFrame.SourceRectangle;
                }
            }

            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
