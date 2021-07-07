using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects
{
    public class BackgroundImage : BaseGameObject
    {
        public BackgroundImage(Texture2D texture)
        {
            Texture = texture;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var viewport = spriteBatch.GraphicsDevice.Viewport;

            var sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            var destinationRectangle = new Rectangle(0,0,viewport.Width, viewport.Height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0.0f, new Vector2(viewport.Width, viewport.Height), SpriteEffects.None, 0.0f);
        }
    }
}
