using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.UI;
using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.Engine.Events;
using OuroborosVandaleriaCore.Engine.Input;

using OuroborosVandaleriaCore.Maps;
using OuroborosVandaleriaCore.CharacterControl;
using OuroborosVandaleriaCore.GameObjects;

using OuroborosVandaleriaGame;


namespace OuroborosVandaleriaCore.Screen
{
    public class GamePlayScreen : BaseGameState
    {
        //Asset Names
        private const string PlayerCharacter = "Player";
        private const string BackgroundTexture = "Map";
        private const string SpellTexture = "Spell";

        //Object instantiation
        private Player _player;
        private RangedSpell _rangedSpell;

        private List<RangedSpell> _rangedSpells;
        private bool _isCasting;
        private TimeSpan _lastCastAt;

        public override void LoadContent()
        {
            _player = new Player(LoadTexture(PlayerCharacter));
            _rangedSpell = new RangedSpell(LoadTexture(SpellTexture));
            _rangedSpells = new List<RangedSpell>();

            var playerXPos = _viewportWidth / 2 - _player.Sprite.Texture.Width / 2;
            var playerYPos = _viewportHeight / 2 - _player.Sprite.Texture.Height - 30;
            _player.Sprite.Position = new Vector2(playerXPos, playerYPos);

            var track1 = LoadSound("TestAudio/1-Dark Fantasy Studio- Before the dawn (seamless)").CreateInstance();
            var track2 = LoadSound("TestAudio / 3 - Dark Fantasy Studio - Over the world(seamless)").CreateInstance();
            _soundManager.SetSoundtrack(new List<SoundEffectInstance>() { track1, track2 });

            var spellSound = LoadSound("TestAudio/3-Dark Fantasy Studio- Over the world (seamless)");
            _soundManager.RegisterSound(new GamePlayEvents.PlayerCasts(), spellSound);

            //AddGameObject(new GameMap());
        }

        public override void UpdateGameState(GameTime gameTime)
        {
            foreach (var spell in _rangedSpells)
            {
                spell.MoveUp();
            }

            if(_lastCastAt != null && gameTime.TotalGameTime - _lastCastAt > TimeSpan.FromSeconds(0.2))
            {
                _isCasting = false;
            }

            var newSpellList = new List<RangedSpell>();
            foreach(var spell in _rangedSpells)
            {
                var spellStillOnScreen = spell.Sprite.Position.Y > -30;
                if (spellStillOnScreen)
                {
                    newSpellList.Add(spell);
                }
                else
                {
                    RemoveGameObject(spell);
                }
            }
        }

        public override void HandleInput()
        {
            InputManager.GetCommands(cmd =>
            {
                switch (cmd)
                {
                    case GameplayInputCommand.ExitGame:
                        NotifyEvent(new BaseGameStateEvent.GameQuit());
                        break;
                    case GameplayInputCommand.PauseGame:
                        NotifyEvent(new BaseGameStateEvent.GamePause());
                        break;
                    case GameplayInputCommand.Inventory:
                        //_player.OpenInventory();
                        break;
                    case GameplayInputCommand.Interact:
                        //_player.Interact();
                        break;
                    case GameplayInputCommand.MeleeAttack:
                        //_player.Attack();
                        break;
                    case GameplayInputCommand.SpellAttack:
                        //_player.SpellAttack();
                        break;
                    case GameplayInputCommand.Sprint:
                        //_player.IsSprinting();
                        break;
                    case GameplayInputCommand.MoveUp:
                        _player.MoveUp();
                        KeepPlayerInBounds();
                        break;
                    case GameplayInputCommand.MoveDown:
                        _player.MoveDown();
                        KeepPlayerInBounds();
                        break;
                    case GameplayInputCommand.MoveLeft:
                        _player.MoveLeft();
                        KeepPlayerInBounds();
                        break;
                    case GameplayInputCommand.MoveRight:
                        _player.MoveRight();
                        KeepPlayerInBounds();
                        break;
                    default:
                        break;
                }
            });
        }
        protected override void SetInputManager()
        {
            InputManager = new InputManager(new GameplayInputMapper());
        }

        private void KeepPlayerInBounds()
        {
            if(_player.Position.X < 0)
            {
                _player.Sprite.Position = new Vector2(0, _player.Position.Y);
            }

            if(_player.Position.X > _viewportWidth - _player.Sprite.Texture.Width)
            {
                _player.Sprite.Position = new Vector2(_viewportWidth - _player.Sprite.Texture.Width, _player.Position.Y);
            }

            if(_player.Position.Y < 0)
            {
                _player.Sprite.Position = new Vector2(_player.Position.X, 0);
            }

            if(_player.Position.Y > _viewportHeight - _player.Sprite.Texture.Height)
            {
                _player.Sprite.Position = new Vector2(_player.Position.X, _viewportHeight - _player.Sprite.Texture.Height);
            }
        }

        private void Cast(GameTime gameTime)
        {
            CreateSpell();
            _isCasting = true;
            _lastCastAt = gameTime.TotalGameTime;

            NotifyEvent(new GamePlayEvents.PlayerCasts());
        }

        private void CreateSpell()
        {
            var spellSpriteLeft = new RangedSpell(_rangedSpell);
            var spellSpriteRight = new RangedSpell(_rangedSpell);

            //position bullets around the fighter's nose when they get fired
            var spellY = _player.Sprite.Position.Y + 30;
            var spellLeftX = _player.Sprite.Position.X + _player.Sprite.Texture.Width / 2 - 40;
            var spellRightX = _player.Sprite.Position.X + _player.Sprite.Texture.Width / 2 + 10;
            spellSpriteLeft.Sprite.Position = new Vector2(spellLeftX, spellY);
            spellSpriteRight.Sprite.Position = new Vector2(spellRightX, spellY);

            _rangedSpells.Add(spellSpriteLeft);
            _rangedSpells.Add(spellSpriteRight);
        }
    }
}