using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen
{
    class SplashScreen : GameScreen
    {
        Texture2D image;
        string path;
        private SpriteFont font;

        public override void LoadContent()
        {
            base.LoadContent();

            path = "IntroScreen/SPR_titlescreen_bg";
            image = content.Load<Texture2D>(path);
            path = "Village/LonglivetheKing";
            font = content.Load<SpriteFont>(path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Vector2.Zero, Color.White);
            spriteBatch.DrawString(font, "Hello, Sailor", new Vector2(100, 100), Color.Black);

            base.Draw(spriteBatch);
        }
    }
}
