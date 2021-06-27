using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using MonoGame.Extended.Tiled;

namespace OuroborosVandaleriaCore.Engine.Sprite
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
        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private float rotation;

        public float Rotation
        {
            get { return rotation; }
            protected set { rotation = value; }
        }

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

        private float scaleFactor;
        public float ScaleFactor
        {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }

        private Vector2 spriteMid;

        public Vector2 SpriteMid
        {
            get { return spriteMid; }
            set { spriteMid = value; }
        }

        //default constructor
        public Sprite()
        {
            position = Vector2.Zero;
            rotation = 0.0f;
            origin = Vector2.Zero;
            rect = new Rectangle(0, 0, 0, 0);
            scaleFactor = 1;
            SpriteMid = new Vector2(Rect.Width / 2, Rect.Height / 2);
        }

        //constructors
        public Sprite(Texture2D texture, Vector2 position, Vector2 origin, float scaleFactor)
        {
            Texture = texture;
            Position = position;
            Origin = origin;
            Rect = ScaleSprite(scaleFactor);
            SpriteMid = new Vector2(Rect.Width / 2, Rect.Height / 2);
        }

        public Sprite(Texture2D texture, Vector2 origin, float scaleFactor)
        {
            Texture = texture;
            Position = position;
            Origin = origin;
            Rect = rect;
            ScaleFactor = scaleFactor;
            SpriteMid = new Vector2(Rect.Width / 2, Rect.Height / 2);
        }

        public Sprite(Texture2D texture, int originX, int originY, float scaleFactor)
        {
            Texture = texture;
            Origin = new Vector2(originX, originY);
            ScaleFactor = scaleFactor;
            Rect = ScaleSprite(scaleFactor);
            SpriteMid = new Vector2(Rect.Width / 2, Rect.Height / 2);
        }

        public Sprite(Texture2D texture)
        {
            Texture = texture;
            position = Vector2.Zero;
            Rotation = 0.0f;
            origin = Vector2.Zero;
            rect = new Rectangle(0, 0, 0, 0);
            scaleFactor = 1;
            SpriteMid = new Vector2(Rect.Width / 2, Rect.Height / 2);
        }

        private Rectangle ScaleSprite(float scaleFactor)
        {
            rect.X *= (int)scaleFactor;
            rect.Y *= (int)scaleFactor;
            return rect;
        }

        private Rectangle ScaleSprite(int x, int y)
        {
            rect.X *= x;
            rect.Y *= y;
            
            return rect;
        }

        public virtual void LockToMap() { }
    }
}
