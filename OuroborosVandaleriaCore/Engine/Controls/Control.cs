using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using OuroborosVandaleriaCore.Engine;

namespace OuroborosVandaleriaCore.Engine.Controls
{
    public abstract class Control
    {
        protected string name;
        protected string text;
        //protected Texture2D texture;
        protected Rectangle size;
        protected Vector2 position;
        protected object value;
        protected bool hasFocus;
        protected bool enabled;
        protected bool visible;
        protected bool tabStop;
        protected SpriteFont spriteFont;
        protected Color color;
        protected string type;
        protected Sprite sprite;


        public event EventHandler Selected;

        //Setters and Getters for values
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /*public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        */
        public Rectangle Size
        {
            get { return size; }
            set { size = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                position.Y = (int)position.Y;
            }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public bool HasFocus
        {
            get { return hasFocus; }
            set { hasFocus = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public bool TabStop
        {
            get { return tabStop; }
            set { tabStop = value; }
        }

        public SpriteFont SpriteFont
        {
            get { return spriteFont; }
            set { spriteFont = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        //constructor
        public Control()
        {
            Color = Color.White;
            Enabled = true;
            Visible = true;
            SpriteFont = ControlManager.SpriteFont;
        }

        //abstract methods
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);

        protected virtual void OnSelected(EventArgs e)
        {
            if(Selected != null)
            {
                Selected(this, e);
            }
        }
    }
}
