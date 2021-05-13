using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace OuroborosVandaleriaCore.Engine.Sprite
{
    /*
     * For each animation type (walking, running, standing, attack1, attack2, attack3, and damage) there should be an animation obgject that contains
     * an array of sprites that sum the animation. The Animations will then be run through a finite state machine that will determine
     * the appropriate version of the animation to be playing (up, down, left right) and then play that animation. For diaganols I will need to check
     * Link to the Past to determine whether the first or last input determines animation version.
     * 
     * This means that each animation type will have 4 associated animation versions. Each frame will be extracted from a sprite sheet constructed by
     * by row in order to ensure that the type animation each animation's bounding boxes are appropriately constrained and maybe easier to extract.
     * This will take some workshopping. Each Frame is a Sprite, Each animation is a collection of Frames, Each AnimationVariant is a collection of
     * Animations, Each AnimationType is a collection of AnimationVariants. The Largest object is the AnimationType.
     *  Ideally this is done during the initialization phase on startup of the game that way the game is only ever pulling from various RAM.
     */
    public enum AnimationKey
    {
        Down,
        Left,
        Right,
        Up
    }
    public class Animation : ICloneable
    {
        Rectangle[] frames;
        int framesPerSecond;
        TimeSpan frameLength;
        TimeSpan frameTimer;
        int currentFrame;
        int frameWidth;
        int frameHeight;

        public int FramesPerSecond
        {
            get { return framesPerSecond; }
            set
            {
                if (value < 1)
                    framesPerSecond = 1;
                else if (value > 60)
                    framesPerSecond = 60;
                else
                    framesPerSecond = value;
                frameLength = TimeSpan.FromSeconds(1 / (double)framesPerSecond);
            }
        }

        public Rectangle CurrentFrameRect
        {
            get { return frames[currentFrame]; }
        }

        public int CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                currentFrame = (int)MathHelper.Clamp(value, 0, frames.Length - 1);
            }
        }

        public int FrameWidth
        {
            get { return frameWidth; }
        }

        public int FrameHeight
        {
            get { return frameHeight; }
        }

        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime;

            if(frameTimer >= frameLength)
            {
                frameTimer = TimeSpan.Zero;
                currentFrame = (currentFrame + 1) % frames.Length;
            }
        }

        public void Reset()
        {
            currentFrame = 0;
            frameTimer = TimeSpan.Zero;
        }

        public Animation(int frameCount, int frameWidth, int frameHeight, int xOffset, int yOffset)
        {
            frames = new Rectangle[frameCount];
            this.frameWidth = frameWidth;
            this.frameHeight = FrameHeight;

            for (int i = 0; i < frameCount; i++)
            {
                frames[i] = new Rectangle(xOffset + (frameWidth * i), yOffset, frameWidth, frameHeight);
            }
            FramesPerSecond = 8;
            Reset();
        }

        private Animation(Animation animation)
        {
            this.frames = animation.frames;
            FramesPerSecond = 8;
        }

        public object Clone()
        {
            Animation animationClone = new Animation(this);

            animationClone.frameWidth = this.frameWidth;
            animationClone.frameHeight = this.frameHeight;
            animationClone.Reset();

            return animationClone;
        }

    }
}
