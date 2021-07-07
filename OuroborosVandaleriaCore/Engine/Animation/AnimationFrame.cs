using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace OuroborosVandaleriaCore.Engine.Animation
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; private set; }
        public int Lifespan { get; private set; }

        public AnimationFrame(Rectangle sourceRectangle, int lifespan)
        {
            SourceRectangle = sourceRectangle;
            Lifespan = lifespan;
        }

  
    }
}
