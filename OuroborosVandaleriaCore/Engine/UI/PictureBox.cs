using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OuroborosVandaleriaCore.Engine.UI
{
    public class PictureBox : Control
    {
        Texture2D image;
        Rectangle sourceRect;
        Rectangle destRect;

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

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
        public PictureBox(Texture2D image, Rectangle destination)
        {
            Image = image;
            DestRect = destination;
            SourceRect = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            Image = image;
            DestRect = destination;
            SourceRect = source;
            Color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, destRect, sourceRect, Color);
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
