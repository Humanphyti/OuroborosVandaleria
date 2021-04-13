using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OuroborosVandaleriaCore.Engine
{
    public class Sprite
    {
        private Texture2D texture;
        public Texture2D Texture
        {
            get { return this.texture; }
            set { texture = value; }
        }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Rotation;

        private Vector2 origin;
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        private Rectangle rect;
        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        private Vector2 scaleFactor;
        public Vector2 ScaleFactor
        {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }

        //default constructor
        public Sprite()
        {
            position = Vector2.Zero;
            Rotation = 0.0f;
            origin = Vector2.Zero;
            rect = new Rectangle(0, 0, 0, 0);
            scaleFactor = Vector2.One;
        }

        //constructors
        public Sprite(Texture2D texture, Vector2 position, Vector2 origin, Vector2 scaleFactor)
        {
            Texture = texture;
            Position = position;
            Origin = origin;
            Rect = ScaleSprite(scaleFactor);
        }

        public Sprite(Texture2D texture, Vector2 origin, Vector2 scaleFactor)
        {
            Texture = texture;
            Position = position;
            Origin = origin;
            Rect = rect;
            ScaleFactor = scaleFactor;
        }

        public Sprite(Texture2D texture, Vector2 origin, float scaleFactor)
        {
            Texture = texture;
            Origin = origin;
            Rect = ScaleSprite(scaleFactor);
        }

        public Sprite(Texture2D texture, int originX, int originY, Vector2 scaleFactor)
        {
            Texture = texture;
            Origin = new Vector2(originX, originY);
            ScaleFactor = scaleFactor;
            Rect = ScaleSprite(scaleFactor);
        }

        public Sprite(Texture2D texture, int originX, int originY, float scaleFactor)
        {
            Texture = texture;
            Origin = new Vector2(originX, originY);
            ScaleFactor = new Vector2(scaleFactor, scaleFactor);
            Rect = ScaleSprite(scaleFactor);
        }

        private Rectangle ScaleSprite(Vector2 scaleFactor)
        {
            rect.X *= (int)scaleFactor.X;
            rect.Y *= (int)scaleFactor.Y;
            return rect;
        }

        private Rectangle ScaleSprite(int x, int y)
        {
            rect.X *= x;
            rect.Y *= y;
            
            return rect;
        }

        private Rectangle ScaleSprite(float scaleFactor)
        {
            rect.X *= (int)scaleFactor;
            rect.Y *= (int)scaleFactor;
            return rect;
        }
    }
}
