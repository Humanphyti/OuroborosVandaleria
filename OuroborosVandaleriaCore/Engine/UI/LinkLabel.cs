using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OuroborosVandaleriaCore.Engine.UI
{
    public class LinkLabel : Control
    {
        Color selectedColor = new Color(Color.Gray, 1f);

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        //constructor
        public LinkLabel()
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        //abstract implementations from Control
        public override void Update(GameTime gameTime)
        {
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            if (hasFocus)
                spriteBatch.Draw(Sprite.Texture, Position, null, selectedColor, 0.0f, sprite.Origin, sprite.ScaleFactor, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(Sprite.Texture, Position, null, Color, 0.0f, sprite.Origin, sprite.ScaleFactor, SpriteEffects.None, 0f);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.KeyReleased(Keys.Enter) || InputHandler.ButtonReleased(Buttons.A, playerIndex))
                base.OnSelected(null);
        }
    }
}
