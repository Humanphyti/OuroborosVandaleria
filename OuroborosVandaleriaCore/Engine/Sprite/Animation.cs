using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

using OuroborosVandaleriaCore.Engine;

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
    /*public enum AnimationKey
    {
        Down,
        Left,
        Right,
        Up
    }*/
    public abstract class Animation : IDisposable
    {

        private readonly bool disposeOnComplete;
        private readonly Action onCompleteAction;
        private bool isComplete;

        public bool IsComplete
        {
            get { return isComplete; }
            protected set
            {
                if (isComplete != value)
                {
                    isComplete = value;

                    if (isComplete)
                    {
                        onCompleteAction?.Invoke();

                        if (disposeOnComplete)
                            Dispose();
                    }
                }
            }
        }

        public bool IsDisposed { get; protected set; }
        public bool IsPaused { get; private set; }
        public bool IsPlaying => !IsPaused && !isComplete;
        public float CurrentTime { get; protected set; }
        
        protected Animation(Action onCompAction, bool disposeOnComp)
        {
            onCompleteAction = onCompAction;
            disposeOnComplete = disposeOnComp;
            IsPaused = false;
        }

        public virtual void Dispose()
        {
            IsDisposed = true;
        }

        public void Play()
        {
            IsPaused = false;
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Stop()
        {
            Pause();
            Rewind();
        }

        public void Rewind()
        {
            CurrentTime = 0;
        }

        protected abstract bool OnUpdate(float delatTime);

        public void Update(float deltaTime)
        {
            if (!IsPlaying)
                return;
            CurrentTime += deltaTime;
            IsComplete = OnUpdate(deltaTime);
        }

        public void Update(GameTime gameTime)
        {
            Update(gameTime.GetEleapsedSeconds());
        }
    }
}
