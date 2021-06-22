using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.GameObjects;

namespace OuroborosVandaleriaCore.CharacterControl
{
    public abstract class Actor : BaseGameObject
    {
        protected float maxHealth;
        protected float mana;
    }
}
