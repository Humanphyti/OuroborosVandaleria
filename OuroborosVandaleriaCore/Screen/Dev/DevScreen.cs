using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OuroborosVandaleriaCore.CharacterControl;
using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine.Input;
using OuroborosVandaleriaCore.Engine.Particles;
using OuroborosVandaleriaCore.GameObjects;


using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen.Dev
{
    public class DevScreen : BaseGameState
    {
        private const string FireballTexture = "Fireball";
        private const string EmbersTexture = "Cloud";
        private const string Player = "Player";
        private const string DebugText = "Content/RuinedKing";

        private SpriteFont _font;

        //private EmbersEmitter _embersEmitter;
        //private Fireball _fireball;
        //private Player _player;
        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                switch (cmd)
                {
                    case DevInputCommand.DevQuit:
                        //NotifyEvent(new BaseGameStateEvent.GameQuit());
                        CreateDebugText("Quit");
                        break;
                    case DevInputCommand.DevCast:
                        //_fireball = new Fireball(LoadTexture(FireballTexture), LoadTexture(EmbersTexture));
                        //_fireball.Position = new Vector2(_player.Position.X, _player.Position.Y - 25);
                        //AddGameObject(_fireball);
                        CreateDebugText("Cast");
                        break;
                    case DevInputCommand.DevStab:
                        CreateDebugText("Stab");
                        break;

                    case DevInputCommand.DevPause:
                        CreateDebugText("Pause");
                        break;

                    case DevInputCommand.DevMoveUp:
                        CreateDebugText("Forward");
                        break;

                    case DevInputCommand.DevMoveDown:
                        CreateDebugText("Backward");
                        break;

                    case DevInputCommand.DevMoveLeft:
                        CreateDebugText("Left");
                        break;

                    case DevInputCommand.DevMoveRight:
                        CreateDebugText("Right");
                        break;
                }
            });
        }

        public override void LoadContent()
        {
            //var embersPosition = new Vector2(_viewportWidth / 2, _viewportHeight / 2);
            //_embersEmitter = new EmbersEmitter(LoadTexture(EmbersTexture), embersPosition);
            //AddGameObject(_embersEmitter);

            //_player = new Player(LoadTexture(Player));
            //_player.Position = new Vector2(500, 500);
            //AddGameObject(_player);

            _font = LoadFont(DebugText);
        }

        private void CreateDebugText(string input)
        {
            var debugText = new DebugText(_font)
            {
                Text = input,
                Position = new Vector2(40, 100)
            };

            AddGameObject(debugText);
        }

        public override void UpdateGameState(GameTime gameTime)
        {
            //_embersEmitter.Position = new Vector2(_embersEmitter.Position.X, _embersEmitter.Position.Y - 3f);
            //_embersEmitter.Update(gameTime);

            /*if(_fireball != null)
            {
                _fireball.Update(gameTime);

                if(_fireball.Position.Y < -100)
                {
                    RemoveGameObject(_fireball);
                }
            }*/

            //if(_embersEmitter.Position.Y < -200)
            //{
            //    RemoveGameObject(_embersEmitter);
            //}

        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}