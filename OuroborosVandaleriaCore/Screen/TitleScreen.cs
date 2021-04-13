using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.State;
using OuroborosVandaleriaCore.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen
{
    public class TitleScreen : BaseGameState
    {
        Texture2D backgroundImage;
        LinkLabel startLabel;
        Sprite pressStartPrompt;

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {

        }

        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"TitleScreen\SPR_titlescreen_bg");
            Texture2D pressStartTexture = Content.Load<Texture2D>(@"TitleScreen\SPR_titlescreen_button");
            base.LoadContent();

            pressStartPrompt = new Sprite(pressStartTexture, pressStartTexture.Width / 2, pressStartTexture.Height / 2, 3f);

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(GameRef.ScreenRectangle.Width / 2f, GameRef.ScreenRectangle.Height / 1.5f);
            startLabel.Sprite = pressStartPrompt;
            startLabel.Color = Color.White;
            startLabel.Size = startLabel.Sprite.Rect;
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(startLabel_Selected);

            ControlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef._spriteBatch.Begin(default, null, SamplerState.PointClamp);
            base.Draw(gameTime);

            GameRef._spriteBatch.Draw(backgroundImage, GameRef.ScreenRectangle, Color.White);
            ControlManager.Draw(GameRef._spriteBatch);

            GameRef._spriteBatch.End();
        }

        private void startLabel_Selected(object sender, EventArgs e)
        {
            StateManager.PushState(GameRef.StartMenuScreen);
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
