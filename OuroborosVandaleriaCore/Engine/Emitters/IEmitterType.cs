using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace OuroborosVandaleriaCore.Engine.Emitters
{
    public interface IEmitterType
    {
        Vector2 GetParticleDirection();
        Vector2 GetParticlePosition(Vector2 emitterPosition);
    }
}
