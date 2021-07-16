using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OuroborosVandaleriaCore.Engine.Events;
using OuroborosVandaleriaCore.Engine.GameState;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects
{
    public class Wolf : BaseGameObject
    {
        private int BBPosX = -16;
        private int BBPosY = -63;
        private int BBWidth = 34;
        private int BBHeight = 98;

        private const int WolfStartX = 0;
        private const int WolfStartY = 0;
        private const int WolfWidth = 44;
        private const int WolfHeight = 98;

        private int _hitAt = 0;
        private const float Speed = 4.0f;
        private Vector2 _direction = new Vector2(0, 0);
        private int _age = 0;

        private List<(int, Vector2)> _path;

        protected int _life = 40;

        public Wolf(Texture2D texture, List<(int, Vector2)> path)
        {
            _sprite.Texture = texture;
            _path = path;
            AddBoundingBox(new Engine.Collisions.BoundingBox(new Vector2(BBPosX, BBPosY), BBWidth, BBHeight));
        }

        public override void OnNotify(BaseGameStateEvent gameEvent)
        {
            switch (gameEvent)
            {
                case GamePlayEvents.ActorHitBy m:
                    JustHit(m.HitBy);
                    SendEvent(new GamePlayEvents.EnemyDie(_life));
                    break;
            }
        }

        public void JustHit(IGameObjectWithDamage o)
        {
            _hitAt = 0;
            _life -= o.Damage;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var wolfRect = new Rectangle(WolfStartX, WolfStartY, WolfWidth, WolfHeight);
            var wolfDestRect = new Rectangle(Position.ToPoint(), new Point(WolfWidth, WolfHeight));

            var color = Color.White;
            spriteBatch.Draw(_sprite.Texture, wolfDestRect, wolfRect, color, MathHelper.Pi, _sprite.Origin, SpriteEffects.None, 0f);
        }

        public void Update()
        {
            foreach(var p in _path)
            {
                int pAge = p.Item1;
                Vector2 pDirection = p.Item2;

                if(_age > pAge)
                {
                    _direction = pDirection;
                }
            }

            Position = Position + (_direction * Speed);

            _age++; 
        }

        public void _wolf_OnObjectChanged(object sender, BaseGameStateEvent e)
        {
            var wolf = (Wolf)sender;
            switch (e)
            {
                case GamePlayEvents.EnemyDie ge:
                    if (ge.CurrentLife <= 0)
                        wolf.Destroy();
                    break;
                    
            }
        }
    }
}
