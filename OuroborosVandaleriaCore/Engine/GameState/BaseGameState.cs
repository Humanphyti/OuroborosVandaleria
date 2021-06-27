using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.Engine.Input;
using OuroborosVandaleriaCore.Engine.Audio;

using OuroborosVandaleriaCore.GameObjects;

namespace OuroborosVandaleriaCore.Engine.GameState
{
    public abstract class BaseGameState
    {
        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();

        private const string FallbackTexture = "BaseBackground";
        protected bool _debug = false;

        private ContentManager _contentManager;
        protected int _viewportWidth;
        protected int _viewportHeight;

        protected InputManager InputManager { get; set; }
        protected SoundManager _soundManager = new SoundManager();

        public abstract void LoadContent();
        public abstract void UpdateGameState(GameTime gameTime);

        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<BaseGameStateEvent> OnEventNotification;
        protected abstract void SetInputManager();
        public abstract void HandleInput();

        public void UnloadContent(ContentManager contentManager)
        {
            _contentManager.Unload();
        }

        public void UnloadContent()
        {
            _contentManager.Unload();
        }

        public void Initialize(ContentManager contentManager, int viewportWidth, int viewportHeight)
        {
            _contentManager = contentManager;
            _viewportHeight = viewportHeight;
            _viewportWidth = viewportWidth;

            SetInputManager();
        }

        public void Update(GameTime gameTime) 
        {
            UpdateGameState(gameTime);
            _soundManager.PlaySoundtrack();
        }

        protected Texture2D LoadTexture(string assetName)
        {
            return _contentManager.Load<Texture2D>(FallbackTexture);
        }

        public TiledMap LoadMap(string mapName, GraphicsDevice graphicsDevice)
        {
            var map = _contentManager.Load<TiledMap>(mapName);
            return map ?? _contentManager.Load<TiledMap>(FallbackTexture);
        }

        protected SoundEffect LoadSound(string soundName)
        {
            return _contentManager.Load<SoundEffect>(soundName);
        }

        protected void NotifyEvent(BaseGameStateEvent eventType)
        {
            OnEventNotification?.Invoke(this, eventType);

            foreach(var gameObject in _gameObjects)
            {
                gameObject.OnNotify(eventType);
            }

            _soundManager.OnNotify(eventType);
        }

        protected void SwitchState(BaseGameState gameState)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects.OrderBy(a => a.zIndex))
            {
                gameObject.Render(spriteBatch);

                if (_debug)
                    gameObject.RenderBoundingBoxes(spriteBatch);
            }
        }
    }
}
