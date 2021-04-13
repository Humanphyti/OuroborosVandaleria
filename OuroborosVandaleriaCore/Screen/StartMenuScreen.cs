using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using OuroborosVandaleriaCore.Engine.State;
using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.Controls;

namespace OuroborosVandaleriaCore.Screen
{
    public class StartMenuScreen : BaseGameState
    {
        PictureBox backgroundImage;
        PictureBox ouroborosText;
        PictureBox vandaleriaText;
        LinkLabel startGame;
        Sprite startGamePrompt;
        LinkLabel options;
        Sprite optionsPrompt;
        float maxItemWidth = 0f;

        //Constructor
        public StartMenuScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            backgroundImage = new PictureBox(Content.Load<Texture2D>(@"TitleScreen/SPR_titlescreen_bg"), GameRef.ScreenRectangle);
            

            Texture2D startGameTexture = Content.Load<Texture2D>(@"StartMenuScreen\spr_play_demo");
            Texture2D optionsTexture = Content.Load<Texture2D>(@"StartMenuScreen\spr_options");
            //Add the Pictureboxes for the "Ouroboros Vandaleria Demo" and Scroll Background

            startGamePrompt = new Sprite(startGameTexture, startGameTexture.Width / 2, startGameTexture.Height / 2, 1f);

            startGame = new LinkLabel();
            startGame.Sprite = startGamePrompt;
            startGame.Size = startGame.Sprite.Rect;
            startGame.Selected += new EventHandler(menuItem_Selected);

            optionsPrompt = new Sprite(optionsTexture, optionsTexture.Width / 2, optionsTexture.Height / 2, 1f);

            options = new LinkLabel();
            options.Sprite = optionsPrompt;
            options.Size = options.Sprite.Rect;
            options.Selected += new EventHandler(menuItem_Selected);

            base.LoadContent();
            ControlManager.Add(backgroundImage);
            ControlManager.Add(startGame);
            ControlManager.Add(options);
            
            ControlManager.NextControl();

            ControlManager.focusChanged += new EventHandler(ControlManager_FocusChanged);
            Vector2 position = new Vector2(350, 500);

            foreach (Control c in ControlManager)
            {
                if(c is LinkLabel)
                {
                    if (c.Size.X > maxItemWidth)
                        maxItemWidth = c.Size.X;

                    c.Position = position;
                    position.Y += c.Size.Y + 5f;

                }
            }

            ControlManager_FocusChanged(startGame, null);
        }

        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {
            if (sender == startGame)
                StateManager.PushState(GameRef.GamePlayScreen);
            else if (sender  == options)
                StateManager.PushState(GameRef.OptionsScreen);

            /*switch (startGameCheck)
            {
                case true:
                    StateManager.PushState(GameRef.GamePlayScreen);
                    break;
                case false:
                    StateManager.PushState(GameRef.OptionsScreen);
                    break;
            }*/
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef._spriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef._spriteBatch);

            GameRef._spriteBatch.End();
        }
    }
}
