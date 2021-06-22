using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.Engine.UI
{
    public class Label : Control
    {
        //constructor
        public Label()
        {
            tabStop = false;
        }

        //abstract implmentations
        public override void Update(GameTime gameTime) { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, text, Position, Color);
        }

        public override void HandleInput(PlayerIndex playerIndex) { }
    }
}
