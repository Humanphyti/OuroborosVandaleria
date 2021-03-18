using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using OuroborosVandaleriaCore.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen
{
    public class TitleScreen : BaseGameState
    {
        Texture2D backgroundImage;

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {

        }

        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"TitleScreen\SPR_titlescreen_bg");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef._spriteBatch.Begin();
            base.Draw(gameTime);
            GameRef._spriteBatch.Draw(backgroundImage, GameRef.ScreenRectangle, Color.White);
            GameRef._spriteBatch.End();
        }
    }
}
        /*Texture2D image;
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
    }*/
