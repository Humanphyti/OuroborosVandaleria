using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

using OuroborosVandaleriaCore.Engine.Sprite;

namespace OuroborosVandaleriaCore.GameObjects
{
    public class StabAttack : BaseGameObject, IGameObjectWithDamage
    {
        //base attack
        //will take some editing to align properly on the player
        private const int BB1PosX = 0;
        private const int BB1PosY = 0;
        private const int BB1Width = 15;
        private const int BB1Height = 30;

        //combo 2
        private const int BB2PosX = 0;
        private const int BB2PosY = 0;
        private const int BB2Width = 15;
        private const int BB2Height = 30;

        //combo 3
        private const int BB3PosX = 0;
        private const int BB3PosY = 0;
        private const int BB3Width = 15;
        private const int BB3Height = 30;

        public int Damage => 10;

        public StabAttack(Sprite sprite)
        {
            //Texture = sprite.Texture;
        }

        public StabAttack(Texture2D texture)
        {
            _texture = texture;
        }
    }
}
