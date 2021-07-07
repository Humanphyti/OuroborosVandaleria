using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.GameObjects;

namespace OuroborosVandaleriaCore.Engine.UI
{
    public abstract class Control : BaseGameObject
    {
        protected string name;
        //protected Texture2D texture;
        protected Rectangle size;
        protected object value;
        protected bool hasFocus;
        protected bool enabled;
        protected bool visible;
        protected bool tabStop;
        protected Color color;
        protected string type;
        protected Sprite.Sprite sprite;
        protected SpriteFont font;
        protected BaseTextObject textObject;
        protected BaseGameObject baseGameObject;


        public event EventHandler Selected;

        //Setters and Getters for values
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public BaseTextObject TextObject
        {
            get { return textObject; }
            set { textObject = value; }
        }
        public Rectangle Size
        {
            get { return size; }
            set { size = value; }
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
            get { return font; }
            set { font = value; }
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

        public BaseGameObject BaseGameObject
        {
            get { return baseGameObject; }
            set { baseGameObject = value; }
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
