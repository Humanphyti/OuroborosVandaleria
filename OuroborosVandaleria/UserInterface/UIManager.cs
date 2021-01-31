using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OuroborosVandaleria.UserInterface
{
    class UIManager
    {
        private static UIManager instance;
        public ContentManager Content { private set; get; }
        UIState currentState;

        public static UIManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new UIManager();

                return instance;
            }
        }

        public UIManager()
        {
            
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }

    }
}
