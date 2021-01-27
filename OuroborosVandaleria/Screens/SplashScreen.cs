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

        public override void LoadContent()
        {
            base.LoadContent();
            path = "IntroScreen/SPR_titlescreen_bg";
            image = content.Load<Texture2D>(path);
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
            base.Draw(spriteBatch);
        }
    }
}
