using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OuroborosVandaleriaCore.Engine.UI
{
    public class ControlManager : List<Control>
    {
        int selectedControl = 0;

        static SpriteFont spriteFont;

        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
        }

        //constructors
        public ControlManager(SpriteFont spriteFont) : base()
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity) : base(capacity)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collections) : base(collections)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (Count == 0)
                return;

            foreach (Control c in this)
            {
                if (c.Enabled)
                    c.Update(gameTime);
                if (c.HasFocus)
                    c.HandleInput(playerIndex);
            }

            if (InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex) || InputHandler.KeyPressed(Keys.Up) || InputHandler.KeyPressed(Keys.W))
                PreviousControl();
            if (InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex) || InputHandler.KeyPressed(Keys.Down) || InputHandler.KeyPressed(Keys.S))
                NextControl();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control c in this)
            {
                if (c.Visible)
                    c.Draw(spriteBatch);
            }
        }

        //Events
        public event EventHandler focusChanged;

        public void NextControl()
        {
            if (Count == 0)
                return;

            int currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl++;

                if (selectedControl == Count)
                    selectedControl = 0;

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if (focusChanged != null)
                        focusChanged(this[selectedControl], null);
                    break;
                }
            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (Count == 0)
                return;

            int currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl--;

                if (selectedControl < 0)
                    selectedControl = Count - 1;

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if (focusChanged != null)
                        focusChanged(this[selectedControl], null);
                    break;
                }

            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }
    }
}
