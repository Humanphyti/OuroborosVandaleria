using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.Engine.UI;
using OuroborosVandaleriaCore.GameObjects;
using OuroborosVandaleriaCore.Engine.Input;

namespace OuroborosVandaleriaCore.Screen
{
    public class StartMenuScreen : BaseGameState
    {
        private const string BackgroundImage = "TitleScreen/SPR_titlescreen_bg";
        private const string OuroborosText = "TitleScreen/SPR_titlescreen_ouroboros";
        private const string VandaleriaText = "TitleScreen/SPR_titlescreen_vandaleria";
        private const string OvLogo = "TitleScreen/SPR_titlescreen_logo";
        private const string Options = "StartMenuScreen/spr_options";
        private const string StartGame = "StartMenuScreen/spr_play_demo";

        Sprite _backgroundImage;
        Sprite _ouroborosText;
        Sprite _vandaleriaText;
        Sprite _ovLogo;
        Sprite _options;
        Sprite _startGame;

        BackgroundImage backgroundImage;
        PictureBox ouroborosText;
        PictureBox vandaleriaText;
        PictureBox ovLogo;
        LinkLabel options;
        LinkLabel startGame;

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                switch (cmd)
                {
                    case MenuInputCommand.ItemSelect:
                        NotifyEvent(new MenuStateEvent.ItemSelected());                        
                        break;
                }
            });
        }

        //Constructor

        public override void LoadContent()
        {
            _backgroundImage = new Sprite(LoadTexture(BackgroundImage));
            _ouroborosText = new Sprite(LoadTexture(OuroborosText));
            _vandaleriaText = new Sprite(LoadTexture(VandaleriaText));
            _ovLogo = new Sprite(LoadTexture(OvLogo));
            _options = new Sprite(LoadTexture(Options));
            _startGame = new Sprite(LoadTexture(StartGame));

            backgroundImage = new BackgroundImage();
            backgroundImage.Position = new Vector2(0, 0);
            backgroundImage.Sprite = _backgroundImage;
            backgroundImage.Sprite.ScaleFactor = new Vector2(6, 6);
            backgroundImage.zIndex = 0;

            ovLogo = new PictureBox();
            ovLogo.Position = new Vector2(_viewportWidth / 3, _viewportHeight / 7);
            ovLogo.Sprite = _ovLogo;
            ovLogo.Sprite.ScaleFactor = new Vector2(3, 3);
            ovLogo.Color = Color.White;
            ovLogo.Size = ovLogo.Sprite.Rect;
            ovLogo.zIndex = 1;

            ouroborosText = new PictureBox();
            ouroborosText.Position = new Vector2(_viewportWidth / 3, _viewportHeight / 7);
            ouroborosText.Sprite = _ouroborosText;
            ouroborosText.Sprite.ScaleFactor = new Vector2(3, 3);
            ouroborosText.Color = Color.White;
            ouroborosText.Size = ouroborosText.Sprite.Rect;
            ouroborosText.zIndex = 1;

            vandaleriaText = new PictureBox();
            vandaleriaText.Position = new Vector2(_viewportWidth / 3, _viewportHeight / 7);
            vandaleriaText.Sprite = _vandaleriaText;
            vandaleriaText.Sprite.ScaleFactor = new Vector2(3, 3);
            vandaleriaText.Color = Color.White;
            vandaleriaText.Size = vandaleriaText.Sprite.Rect;
            vandaleriaText.zIndex = 1;

            options = new LinkLabel();
            options.Name = "Options";
            options.Position = new Vector2(_viewportWidth / 3, _viewportHeight / 4);
            options.Sprite = _options;
            options.Sprite.ScaleFactor = new Vector2(3, 3);
            options.Color = Color.White;
            options.Size = options.Sprite.Rect;
            options.zIndex = 2;

            startGame = new LinkLabel();
            startGame.Name = "StartGame";
            startGame.Position = new Vector2(_viewportWidth / 3, _viewportHeight / 5);
            startGame.Sprite = _startGame;
            startGame.Sprite.ScaleFactor = new Vector2(3, 3);
            startGame.Color = Color.White;
            startGame.Size = startGame.Sprite.Rect;
            startGame.Selected += Item_Selected;
            startGame.zIndex = 2;

            AddGameObject(backgroundImage);
            AddGameObject(ovLogo);
            AddGameObject(ouroborosText);
            AddGameObject(vandaleriaText);
            AddGameObject(startGame);
            AddGameObject(options);

            ControlManager.Add(startGame);
            ControlManager.Add(options);


            /*backgroundImage = new PictureBox(Content.Load<Texture2D>(@"TitleScreen/SPR_titlescreen_bg"), GameRef.ScreenRectangle);
            

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

        private void ItemSelected()
        {

        }

        public override void UpdateGameState(GameTime gameTime)
        {
            
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new MenuInputMapper());
        }
    }
}
