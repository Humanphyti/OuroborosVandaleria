using System;
using System.Collections.Generic;
using System.Text;

using OuroborosVandaleriaCore.Engine.Sprite;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.GameObjects
{
    public class RangedSpell : BaseGameObject, IGameObjectWithDamage
    {
        private const float SPELL_SPEED = 10.0f;

        public int Damage => 0;

        public RangedSpell(Sprite sprite)
        {
            Texture = sprite.Texture;
        }

        public RangedSpell(Texture2D texture)
        {
            Texture = texture;
        }

        public void MoveUp()
        {
            //_sprite.Position = new Vector2(_sprite.Position.X, _sprite.Position.Y - SPELL_SPEED);
        }
    }
}
