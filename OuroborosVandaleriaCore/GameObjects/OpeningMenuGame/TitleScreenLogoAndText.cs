using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OuroborosVandaleriaCore.Engine.Sprite;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects.OpeningMenuGame
{
    class TitleScreenLogoAndText : BaseCompositeObject
    {
        private Sprite _logo;
        private Sprite _ouroboros;
        private Sprite _vandaleria;
        private List<Sprite> _sprites;
        private Matrix _localTransofrm
        {
            get
            {
                return Matrix.CreateTranslation(-_sprite.Origin.X, -_sprite.Origin.Y, 0f) * Matrix.CreateScale(_sprite.ScaleFactor.X, _sprite.ScaleFactor.Y, 1f) * Matrix.CreateRotationZ(_sprite.Rotation) * Matrix.CreateTranslation(Position.X, Position.Y, 0f);
            }
        }

        public TitleScreenLogoAndText(Sprite logo, Sprite ouroboros, Sprite vandaleria)
        {
            _logo = logo;
            _ouroboros = ouroboros;
            _vandaleria = vandaleria;
        }

        public static void DecomposeMatrix(ref Matrix matrix, out Vector2 position, out float rotation, out Vector2 scale)
        {
            Vector3 position3, scale3;
            Quaternion rotationQ;
            matrix.Decompose(out scale3, out rotationQ, out position3);
            Vector2 direction = Vector2.Transform(Vector2.UnitX, rotationQ);
            rotation = (float)Math.Atan2(direction.Y, direction.X);
            position = new Vector2(position3.X, position3.Y);
            scale = new Vector2(scale3.X, scale3.Y);
        }
    }
}
