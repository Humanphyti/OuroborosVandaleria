using System;

using OuroborosVandaleriaCore.Screen;
using OuroborosVandaleriaCore.CharacterControl;
using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine.Events;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OuroborosVandaleriaGame
{
    public class OuroborosVandaleria : Game
    {
        private RenderTarget2D _renderTarget;
        private Rectangle _renderScaleRectangle;
        private BaseGameState _currentGameState;


        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        //TiledMapRenderer tiledMapRenderer;

        private int _DesignedResolutionWidth;
        private int _DesignedResolutioHeight;
        private float _designedResolutionAspectRatio;

        private BaseGameState _firstGameState;


        public OuroborosVandaleria(int width, int height, BaseGameState firstGameState)
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager(this);


            _firstGameState = firstGameState;
            _DesignedResolutionWidth = width;
            _DesignedResolutioHeight = height;
            _designedResolutionAspectRatio = width / (float)height;

            //ScreenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            

            //Components.Add(new InputHandler(this));

            //stateManager = new GameStateManager(this);
            //Components.Add(stateManager);

            //TitleScreen = new TitleScreen(this, stateManager);
            //StartMenuScreen = new StartMenuScreen(this, stateManager);
            //GamePlayScreen = new GamePlayScreen(this, stateManager);
            //OptionsScreen = new OptionsScreen(this, stateManager);

            //stateManager.ChangeState(TitleScreen);
        }

        private void SwitchGameState(BaseGameState gameState)
        {
           if(_currentGameState != null)
           {
                _currentGameState.OnStateSwitched -= CurrentGameState_OnStateSwitched;
                _currentGameState.OnEventNotification -= _currentGameState_OnEventNotification;
                _currentGameState.UnloadContent();
           }

            _currentGameState = gameState;

            _currentGameState.Initialize(Content, _graphics.GraphicsDevice.Viewport.Width, _graphics.GraphicsDevice.Viewport.Height);

            _currentGameState.LoadContent();

            _currentGameState.OnStateSwitched += CurrentGameState_OnStateSwitched;
            _currentGameState.OnEventNotification += _currentGameState_OnEventNotification;
        }

        private void CurrentGameState_OnStateSwitched(object sender, BaseGameState e)
        {
            SwitchGameState(e);
        }

        private void _currentGameState_OnEventNotification(object sender, BaseGameStateEvent e)
        {
            switch (e)
            {
                case BaseGameStateEvent.GameQuit _:
                    Exit();
                    break;
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = _DesignedResolutionWidth;
            _graphics.PreferredBackBufferHeight = _DesignedResolutioHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            _renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, _DesignedResolutionWidth, _DesignedResolutioHeight, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
            //_renderScaleRectangle = GetScaleRectangle();

            base.Initialize();
        }

        private Rectangle GetScaleRectangle()
        {
            var variance = 0.5;
            var actualAspectRatio = Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
            
            Rectangle scaleRectangle;

            if(actualAspectRatio <= _designedResolutionAspectRatio)
            {
                var presentHeight = (int)(Window.ClientBounds.Width / _designedResolutionAspectRatio + variance);
                var barHeight = (Window.ClientBounds.Height - presentHeight) / 2;

                scaleRectangle = new Rectangle(0, barHeight, Window.ClientBounds.Height, presentHeight);
            }
            else
            {
                var presentWidth = (int)(Window.ClientBounds.Height * _designedResolutionAspectRatio + variance);
                var barWidth = (Window.ClientBounds.Width - presentWidth) / 2;

                scaleRectangle = new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
            }

            return scaleRectangle;
        }
        //Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            SwitchGameState(_firstGameState);
        }

        protected override void UnloadContent()
        {
            _currentGameState?.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _currentGameState.HandleInput(gameTime);
            // TODO: Add your update logic here
            _currentGameState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_renderTarget);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _currentGameState.Render(_spriteBatch);
            _spriteBatch.End();

            _graphics.GraphicsDevice.SetRenderTarget(null);
            //_graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 1.0f, 0);

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            _spriteBatch.Draw(_renderTarget, Vector2.Zero, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}