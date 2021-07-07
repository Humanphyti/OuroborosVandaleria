using System;
using System.Collections.Generic;

using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.Engine.GameState;
using BoundingBox = OuroborosVandaleriaCore.Engine.Collisions.BoundingBox;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.GameObjects
{
    public  class BaseGameObject : Sprite
    {
        protected List<BoundingBox> _boundingBoxes = new List<BoundingBox>();
        protected Texture2D _boundingBoxTexture;

        public int zIndex;
        public event EventHandler<BaseGameStateEvent> OnObjectChanged;

        public bool Destroyed { get; private set; }
         
        public int Width { get { return Texture.Width; } }
        public int Height { get { return Texture.Height; } }
        public override Vector2 Position
        {
            get { return Position; }
            set
            {
                var deltaX = value.X - Position.X;
                var deltaY = value.Y - Position.Y;
                Position = value;

                foreach(var bb in _boundingBoxes)
                {
                    bb.Position = new Vector2(bb.Position.X + deltaX, bb.Position.Y + deltaY);
                }
            }
        }
        public List<BoundingBox> BoundingBoxes
        {
            get { return _boundingBoxes; }
        }

        public virtual void OnNotify(BaseGameStateEvent eventType) { }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
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
            if (_boundingBoxTexture == null)
            {
                CreateBoundingBoxTexture(spriteBatch.GraphicsDevice);
            }

            foreach(var bb in _boundingBoxes)
            {
                spriteBatch.Draw(_boundingBoxTexture, bb.Rectangle, Color.Red);
            }
        }

        private void CreateBoundingBoxTexture(GraphicsDevice graphicsDevice)
        {
            _boundingBoxTexture = new Texture2D(graphicsDevice, 1, 2);
            _boundingBoxTexture.SetData<Color>(new Color[] { Color.White });
        }
    }
}
