using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects
{
    public class BaseTextObject : BaseGameObject
    {
        protected SpriteFont _font;

        public string Text { get; set; }

        public override Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Text, Position, Color.Red);
        }
    }
}
