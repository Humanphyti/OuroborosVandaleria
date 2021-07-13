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
        public int zIndex;
        public event EventHandler<BaseGameStateEvent> OnObjectChanged;

        public bool Destroyed { get; private set; }
         
        public int Width { get { return _texture.Width; } }
        public int Height { get { return _texture.Height; } }

        public virtual void OnNotify(BaseGameStateEvent eventType) { }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
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
