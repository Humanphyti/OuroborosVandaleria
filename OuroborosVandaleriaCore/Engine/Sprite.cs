using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OuroborosVandaleriaCore.Engine
{
    class Sprite
    {
        private Texture2D texture;
        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
        }

        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }

        public float Rotation;

        private Vector2 origin;
        public Vector2 Origin
        {
            get
            {
                return this.origin;
            }
        }

        private Rectangle rect;
        public Rectangle Rect
        {
            get
            {
                return this.rect;
            }
        }

        private Vector2 scaleFactor;
        public Vector2 ScaleFactor
        {
            get
            {
                return this.scaleFactor;
            }
        }

        public Sprite()
        {
            //this.texture = texture;
            position = Vector2.Zero;
            Rotation = 0.0f;
            origin = Vector2.Zero;
            rect = new Rectangle(0, 0, texture.Width, texture.Height);
            scaleFactor = Vector2.One;
        }

        public void SetPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        public void Move(float deltaX, float deltaY)
        {
            position.X += deltaX;
            position.Y += deltaY;
        }

        public void Move(Vector2 deltaPos)
        {
            position += deltaPos;
        }

        public void SetOrigin(float x, float y)
        {
            origin.X += x;
            origin.Y += y;
        }

        public void SetOrigin(Vector2 origin)
        {
            this.origin = origin;
        }

        public void SetRect(int x, int y, int width, int height)
        {
            rect.X = x;
            rect.Y = y;
            rect.Width = width;
            rect.Height = height;
        }

        public void SetRect(Rectangle newRect)
        {
            rect = newRect;
        }

        public void SetScale(float x, float y)
        {
            scaleFactor.X = x;
            scaleFactor.Y = y;
        }

        public void SetScale(float factor)
        {
            scaleFactor.X = factor;
            scaleFactor.Y = factor;
        }

        public void SetScale(Vector2 factor)
        {
            scaleFactor = factor;
        }

        public void Scale(float x, float y)
        {
            scaleFactor.X = x;
            scaleFactor.Y = y;
        }

        public void Scale(float factor)
        {
            scaleFactor.X = factor;
            scaleFactor.Y = factor;
        }

        public void Scale(Vector2 factor)
        {
            scaleFactor = factor;
        }

        public void LoadContent(ContentManager contentManager, string assetName)
        {
            texture = contentManager.Load<Texture2D>(assetName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, rect, Color.White, Rotation, origin, scaleFactor, SpriteEffects.None, 0.0f);
            spriteBatch.End();
        }


    }
}
