using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects
{
    class BaseCompositeObject : BaseGameObject
    {
        public override Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
