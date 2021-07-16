using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine.UI;
using OuroborosVandaleriaCore.Engine.Input;
using OuroborosVandaleriaCore.Engine.Sprite;

using OuroborosVandaleriaCore.GameObjects;
using OuroborosVandaleriaCore.GameObjects.OpeningMenuGame;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen
{
    public class TitleScreen : BaseGameState
    {
        private const string BackgroundImageLoc = "TitleScreen/SPR_titlescreen_bg";
        private const string PressStartAnimationSheet = "TitleScreen/SPR_title_open_sheet";
        private const string PressStartStatic = "TitleScreen/SPR_titlescreen_button";
        private const string OuroborosLogo = "TitleScreen/SPR_titlescreen_logo";
        private const string Ouroboros = "TitleScreen/SPR_titlescreen_ouroboros";
        private const string Vandaleria = "TitleScreen/SPR_titlescreen_vandaleria";
        private const string RuinedKing = "RuinedKing";

        private Sprite pressStartStatic;
        private Sprite ouroborosLogo;
        private Sprite ouroboros;
        private Sprite vandaleria;
        private Sprite backgroundImageLoc;

        private ControlManager controls;

        private LinkLabel startLabel;
        private PictureBox logoPicture;
        private PictureBox ouroborosText;
        private PictureBox vandaleriaText;
        private StartScroll _startScroll;
        private BackgroundImage bgImage;

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                switch (cmd)
                {
                    case MenuInputCommand.ItemSelect:
                        _startScroll.PlayAnimation();
                        //Add a fade to black for the final product
                        SwitchState(new StartMenuScreen());
                        break;
                }
            });
        }

        public override void LoadContent()
        {
            controls = new ControlManager(LoadFont(RuinedKing));
            backgroundImageLoc = new Sprite(LoadTexture(BackgroundImageLoc));
            _startScroll = new StartScroll(LoadTexture(PressStartAnimationSheet));
            pressStartStatic = new Sprite(LoadTexture(PressStartStatic));
            ouroborosLogo = new Sprite(LoadTexture(OuroborosLogo));
            ouroboros = new Sprite(LoadTexture(Ouroboros));
            vandaleria = new Sprite(LoadTexture(Vandaleria));

            bgImage = new BackgroundImage();
            bgImage.Position = new Vector2(0, 0);
            bgImage.Sprite = backgroundImageLoc;
            bgImage.Sprite.ScaleFactor = new Vector2(6, 6);
            bgImage.zIndex = 0;


            logoPicture = new PictureBox();
            logoPicture.Position = new Vector2(_viewportWidth / 3, _viewportHeight / 6.5f);
            logoPicture.Name = "Logo";
            logoPicture.Sprite = ouroborosLogo;
            logoPicture.Sprite.ScaleFactor = new Vector2(6, 6);
            logoPicture.Color = Color.White;
            logoPicture.Size = logoPicture.Sprite.Rect;
            logoPicture.zIndex = 1;

            ouroborosText = new PictureBox();
            ouroborosText.Position = new Vector2(_viewportWidth / 6.4f, _viewportHeight / 5.5f);
            ouroborosText.Name = "Ouroboros";
            ouroborosText.Sprite = ouroboros;
            ouroborosText.Sprite.ScaleFactor = new Vector2(6f, 6f);
            ouroborosText.Color = Color.White;
            ouroborosText.Size = ouroborosText.Sprite.Rect;
            ouroborosText.zIndex = 2;

            vandaleriaText = new PictureBox();
            vandaleriaText.Position = new Vector2(_viewportWidth / 3.5f, _viewportHeight / 1.45f);
            vandaleriaText.Name = "Vandaleria";
            vandaleriaText.Sprite = vandaleria;
            vandaleriaText.Sprite.ScaleFactor = new Vector2(6.5f, 6.5f);
            vandaleriaText.Color = Color.White;
            vandaleriaText.Size = vandaleriaText.Sprite.Rect;
            vandaleriaText.zIndex = 2;

            startLabel = new LinkLabel();
            startLabel.Name = "PressStartButton";
            startLabel.Position = new Vector2(_viewportWidth / 5.3f, _viewportHeight / 1.8f);
            startLabel.Sprite = pressStartStatic;
            startLabel.Color = Color.White;
            startLabel.Size = startLabel.Sprite.Rect;
            startLabel.Sprite.ScaleFactor = new Vector2(6, 6);
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.zIndex = 1;

            //controls.Add(startLabel);
            //controls.Add(logoAndText);

            AddGameObject(bgImage);
            AddGameObject(ouroborosText);
            AddGameObject(logoPicture);
            AddGameObject(startLabel);
            AddGameObject(vandaleriaText);
        }

        public override void UpdateGameState(GameTime gameTime)
        {
            _startScroll.Update(gameTime);
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new MenuInputMapper());
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            base.Render(spriteBatch);
        }


        //Sprite pressStartPrompt;



        /*public TitleScreen(Game game, GameStateManager manager)
        {

        }

        protected override void LoadContent(ContentManager contentManager)
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
        }*/
    }
}
