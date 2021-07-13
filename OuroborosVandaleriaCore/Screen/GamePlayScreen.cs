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
using OuroborosVandaleriaCore.Engine.Particles;
using OuroborosVandaleriaCore.Engine.Collisions;

using OuroborosVandaleriaCore.Spawners;
using OuroborosVandaleriaCore.Maps;
using OuroborosVandaleriaCore.CharacterControl;
using OuroborosVandaleriaCore.GameObjects;

using OuroborosVandaleriaGame;

using System.Threading.Tasks;


namespace OuroborosVandaleriaCore.Screen
{
    public class GamePlayScreen : BaseGameState
    {
        //Asset Names
        private const string PlayerCharacter = "Player";
        private const string BackgroundTexture = "Map";
        private const string StabTexture = "Stab";
        private const string SpellTexture = "Spell";
        private const string ExplosionTexture = "Explosion";
        private const string EmbersTexture = "Embers";
        private const string WolfTexture = "Wolf";

        private const int MaxExplosionAge = 600;
        private const int ExplosionActiveLength = 75;

        private Texture2D _stabTexture;
        private Texture2D _spellTexture;
        private Texture2D _embersTexture;
        private Texture2D _explosionTexture;
        private Texture2D _wolfTexture;
        
        private Player _player;
        private bool _playerDead;

        private bool _isCasting;
        private bool _isStabbing;
        private TimeSpan _lastCastAt;
        private TimeSpan _lastStabAt;

        private List<RangedSpell> _rangedSpells = new List<RangedSpell>();
        private List<ExplosionEmitter> _explosionList = new List<ExplosionEmitter>();
        private List<Wolf> _wolfList = new List<Wolf>();
        private List<StabAttack> _stabAttacks = new List<StabAttack>();

        private StabAttack _stabAttack;
        private RangedSpell _rangedSpell;
        private WolfGenerator _wolfGenerator;

        public override void LoadContent()
        {
            _stabTexture = LoadTexture(StabTexture);
            _explosionTexture = LoadTexture(PlayerCharacter);
            _spellTexture = LoadTexture(SpellTexture);
            _embersTexture = LoadTexture(EmbersTexture);
            _wolfTexture = LoadTexture(WolfTexture);

            _player = new Player(LoadTexture(PlayerCharacter));

            //AddGameObject(new GameMap());

            //var playerXPos = _viewportWidth / 2 - _player.Texture.Width / 2;
            //var playerYPos = _viewportHeight / 2 - _player.Texture.Height - 30;
            //_player.Position = new Vector2(playerXPos, playerYPos);

            var spellSound = LoadSound("TestAudio/1-Dark Fantasy Studio- Before the dawn (seamless)");
            var attackSound = LoadSound("TestAudio / 3 - Dark Fantasy Studio - Over the world(seamless)");
            _soundManager.RegisterSound(new GamePlayEvents.PlayerCasts(), spellSound);
            _soundManager.RegisterSound(new GamePlayEvents.PlayerAttacks(), attackSound);

            var track1 = LoadSound("TestAudio/3-Dark Fantasy Studio- Over the world (seamless)").CreateInstance();
            _soundManager.SetSoundtrack(new List<SoundEffectInstance>() { track1 });

            ResetGame();
        }

        public override void UpdateGameState(GameTime gameTime)
        {
            foreach (var spell in _rangedSpells)
            {
                spell.MoveUp();
            }

            foreach(var wolf in _wolfList)
            {
                wolf.Update();
            }

            UpdateExplosions(gameTime);
            RegulateAttackingRate(gameTime);
            DetectCollisions();

            _rangedSpells = CleanObjects(_rangedSpells);
            _wolfList = CleanObjects(_wolfList);
        }

        private void RegulateAttackingRate(GameTime gameTime)
        {
            if (_lastCastAt != null && gameTime.TotalGameTime - _lastCastAt > TimeSpan.FromSeconds(1.0))
            {
                _isCasting = false;
            }

            if (_lastStabAt != null && gameTime.TotalGameTime - _lastStabAt > TimeSpan.FromSeconds(0.2))
            {
                _isStabbing = false;
            }
        }

        private void DetectCollisions()
        {
            var rangedSpellCollisionDetector = new AABBCollisionDetector<RangedSpell, Wolf>(_rangedSpells);
            //var aoeSpellCollisionDetector = new AABBCollisionDetector<AoeSpell, Wolf>(_aoeSpells);
            var stabCollisionDetector = new AABBCollisionDetector<StabAttack, Wolf>(_stabAttacks);
            var playerCollisionDetector = new AABBCollisionDetector<Wolf, Player>(_wolfList);

            rangedSpellCollisionDetector.DetectCollisions(_wolfList, (spell, wolf) =>
            {
                var hitEvent = new GamePlayEvents.ActorHitBy(spell);
                wolf.OnNotify(hitEvent);
                _soundManager.OnNotify(hitEvent);
                wolf.Destroy();
            });

            stabCollisionDetector.DetectCollisions(_wolfList, (stab, wolf) =>
            {
                var hitEvent = new GamePlayEvents.ActorHitBy(stab);
                wolf.OnNotify(hitEvent);
                wolf.Destroy();
            });

            /*aoeSpellCollisionDetector.DetectCollisions(_wolfList, (spell, wolf) =>
            {
                var hitEvent = new GamePlayEvents.ActorHitBy(spell);
                wolf.OnNotify(wolf);
                _soundManager.OnNotify(hitEvent);
                wolf.Destroy();
            });*/

            if (!_playerDead)
            {
                playerCollisionDetector.DetectCollisions(_player, (wolf, player) =>
                {
                    KillPlayer();
                });
            }
        }

        public override void HandleInput(GameTime gameTime)
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
                        //Cast();
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
                _player.Position = new Vector2(0, _player.Position.Y);
            }

            if(_player.Position.X > _viewportWidth - _player.Width)
            {
                _player.Position = new Vector2(_viewportWidth - _player.Width, _player.Position.Y);
            }

            if(_player.Position.Y < 0)
            {
                _player.Position = new Vector2(_player.Position.X, 0);
            }

            if(_player.Position.Y > _viewportHeight - _player.Height)
            {
                _player.Position = new Vector2(_player.Position.X, _viewportHeight - _player.Height);
            }
        }

        private async void KillPlayer()
        {
            _playerDead = true;

            RemoveGameObject(_player);

            await Task.Delay(TimeSpan.FromSeconds(2));
            ResetGame();
        }

        private void Cast(GameTime gameTime)
        {
            if (!_isCasting)
            {
                CreateSpell();
                _isCasting = true;
                _lastCastAt = gameTime.TotalGameTime;

                NotifyEvent(new GamePlayEvents.PlayerCasts());
            }
        }

        private void Stab(GameTime gameTime)
        {
            if (!_isStabbing)
            {
                CreateStab();
                _isStabbing = true;
                _lastStabAt = gameTime.TotalGameTime;

                NotifyEvent(new GamePlayEvents.PlayerAttacks());
            }
        }

        private void CreateSpell()
        {
            var spellSpriteLeft = new RangedSpell(_rangedSpell);
            var spellSpriteRight = new RangedSpell(_rangedSpell);

            //position bullets around the fighter's nose when they get fired
            var spellY = _player.Position.Y + 30;
            var spellLeftX = _player.Position.X + _player.Width / 2 - 40;
            var spellRightX = _player.Position.X + _player.Width / 2 + 10;
            spellSpriteLeft.Position = new Vector2(spellLeftX, spellY);
            spellSpriteRight.Position = new Vector2(spellRightX, spellY);

            _rangedSpells.Add(spellSpriteLeft);
            _rangedSpells.Add(spellSpriteRight);
        }

        private void CreateStab()
        {
            var stabSpriteLeft = new StabAttack(_stabAttack);
            var stabSpriteRight = new StabAttack(_stabAttack);

            var stabY = _player.Position.Y + 30;
            var stabLeftX = _player.Position.X + _player.Width / 2 - 40;
            var stabRightX = _player.Position.X + _player.Width / 2 + 10;
            stabSpriteLeft.Position = new Vector2(stabLeftX, stabY);
            stabSpriteRight.Position = new Vector2(stabRightX, stabY);

            //probably the combo logic goes here
        }

        private void ResetGame()
        {
            if(_wolfGenerator != null)
            {
                _wolfGenerator.StopGenerating();
            }

            foreach(var spell in _rangedSpells)
            {
                RemoveGameObject(spell);
            }

            foreach(var wolf in _wolfList)
            {
                RemoveGameObject(wolf);
            }

            foreach(var explosion in _explosionList)
            {
                RemoveGameObject(explosion);
            }

            _rangedSpells = new List<RangedSpell>();
            _wolfList = new List<Wolf>();
            _explosionList = new List<ExplosionEmitter>();

            _wolfGenerator = new WolfGenerator(_wolfTexture, 4, AddWolf);
            _wolfGenerator.GenerateWolves();

            AddGameObject(_player);

            var playerXPos = _viewportWidth / 2 - _player.Width / 2;
            var playerYPos = _viewportHeight / 2 - _player.Height - 30;
            _player.Position = new Vector2(playerXPos, playerYPos);

            _playerDead = false;
        }

        private void AddWolf(Wolf wolf)
        {
            wolf.OnObjectChanged += _wolf_OnObjectChanged;
            _wolfList.Add(wolf);
            AddGameObject(wolf);
        }

        private void _wolf_OnObjectChanged(object sender, BaseGameStateEvent e)
        {
            var wolf = (Wolf)sender;
            switch (e)
            {
                case GamePlayEvents.EnemyDie ge:
                    if(ge.CurrentLife <= 0)
                    {
                        AddExplosion(new Vector2(wolf.Position.X - 40, wolf.Position.Y - 40));
                        wolf.Destroy();
                    }
                    break;
            }
        }

        private void AddExplosion(Vector2 position)
        {
            var explosion = new ExplosionEmitter(_explosionTexture, position);
            AddGameObject(explosion);
            _explosionList.Add(explosion);
        }

        private void UpdateExplosions(GameTime gameTime)
        {
            foreach (var explosion in _explosionList)
            {
                explosion.Update(gameTime);

                if (explosion.Age > ExplosionActiveLength)
                {
                    explosion.Deactivate();
                }

                if(explosion.Age > MaxExplosionAge)
                {
                    explosion.Deactivate();
                }
            }
        }

        private List<T> CleanObjects<T>(List<T> objectList) where T : BaseGameObject
        {
            List<T> listOfItemsToKeep = new List<T>();
            foreach(T item in objectList)
            {
                var offScreen = item.Position.Y < -50;

                if(offScreen || item.Destroyed)
                {
                    RemoveGameObject(item);
                }
                else
                {
                    listOfItemsToKeep.Add(item);
                }
            }

            return listOfItemsToKeep;
        }

    }
}