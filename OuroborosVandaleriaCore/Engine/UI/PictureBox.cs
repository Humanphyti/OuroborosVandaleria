using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.Engine.Sprite;

namespace OuroborosVandaleriaCore.Engine.UI
{
    public class PictureBox : Control
    {
        Rectangle sourceRect;
        Rectangle destRect;

        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Rectangle DestRect
        {
            get { return destRect; }
            set { destRect = value; }
        }

        //constructors
        public PictureBox()
        {
            TabStop = false;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        public PictureBox(Sprite.Sprite sprite, Rectangle destination)
        {
            Sprite.Texture = sprite.Texture;
            DestRect = destination;
            SourceRect = new Rectangle(0, 0, Sprite.Texture.Width, Sprite.Texture.Height);
            Color = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            Sprite.Texture = image;
            DestRect = destination;
            SourceRect = source;
            Color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.Texture, Position, null, Color, 0.0f, Sprite.Origin, Sprite.ScaleFactor, SpriteEffects.None, 0f);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {

        }

        public void SetPosition(Vector2 newPosition)
        {
            destRect = new Rectangle((int)newPosition.X, (int)newPosition.Y, sourceRect.X, sourceRect.Y);
        }
    }
}
