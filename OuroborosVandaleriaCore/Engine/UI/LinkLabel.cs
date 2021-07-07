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
            Position = Vector2.One;
        }

        //abstract implementations from Control
        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hasFocus)
                spriteBatch.Draw(Texture, Position, null, selectedColor, 0.0f, Origin, ScaleFactor, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(Texture, Position, null, Color, 0.0f, Origin, ScaleFactor, SpriteEffects.None, 0f);
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
