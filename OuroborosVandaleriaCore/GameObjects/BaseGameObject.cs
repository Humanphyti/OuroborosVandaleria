using System;
using System.Collections.Generic;

using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.Engine.GameState;
using BoundingBox = OuroborosVandaleriaCore.Engine.Collisions.BoundingBox;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.GameObjects
{
    public class BaseGameObject
    {
        protected Sprite _sprite;

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        protected Vector2 _position;
        protected Texture2D boundingBoxTexture;

        protected List<BoundingBox> _boundingBoxes = new List<BoundingBox>();
        public List<BoundingBox> BoundingBoxes
        {
            get
            {
                return _boundingBoxes;
            }
        }

        public virtual Vector2 Position
        {
            get { return _position; }
            set
            {
                var deltaX = value.X - _position.X;
                var deltaY = value.Y - _position.Y;
                _position = value;

                foreach (var bb in _boundingBoxes)
                {
                    bb.Position = new Vector2(bb.Position.X + deltaX, bb.Position.Y + deltaY);
                }
            }
        }

        public int zIndex;
        public event EventHandler<BaseGameStateEvent> OnObjectChanged;

        public bool Destroyed { get; private set; }
         
        public int Width { get { return _sprite.Texture.Width; } }
        public int Height { get { return _sprite.Texture.Height; } }

        public virtual void OnNotify(BaseGameStateEvent eventType) { }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.Texture, Position, null, Color.White, 0.0f, _sprite.Origin, _sprite.ScaleFactor, SpriteEffects.None, 0f);
        }

        public void SendEvent(BaseGameStateEvent e)
        {
            OnObjectChanged?.Invoke(this, e);
        }

        public void Destroy()
        {
            Destroyed = true;
        }

        public void AddBoundingBox(BoundingBox bb)
        {
            _boundingBoxes.Add(bb);
        }

        public void RenderBoundingBoxes(SpriteBatch spriteBatch)
        {
            if (boundingBoxTexture == null)
            {
                CreateBoundingBoxTexture(spriteBatch.GraphicsDevice);
            }

            foreach(var bb in _boundingBoxes)
            {
                spriteBatch.Draw(boundingBoxTexture, bb.Rectangle, Color.Red);
            }
        }

        private void CreateBoundingBoxTexture(GraphicsDevice graphicsDevice)
        {
            boundingBoxTexture = new Texture2D(graphicsDevice, 1, 2);
            boundingBoxTexture.SetData<Color>(new Color[] { Color.White });
        }
    }
}
