using Microsoft.Xna.Framework;

using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine.Input;
using OuroborosVandaleriaCore.Engine.Particles;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen.Dev
{
    public class DevScreen : BaseGameState
    {
        private const string EmbersTexture = "Cloud";
        private EmbersEmitter _embersEmitter;
        public override void HandleInput()
        {
            InputManager.GetCommands(cmd =>
            {
                switch (cmd)
                {
                    case DevInputCommand.DevQuit:
                        NotifyEvent(new BaseGameStateEvent.GameQuit());
                        break;
                }
            });
        }

        public override void LoadContent()
        {
            var embersPosition = new Vector2(_viewportWidth / 2, _viewportHeight / 2);
            _embersEmitter = new EmbersEmitter(LoadTexture(EmbersTexture), embersPosition);

            AddGameObject(_embersEmitter);
        }

        public override void UpdateGameState(GameTime gameTime)
        {
            _embersEmitter.Update(gameTime);
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}
