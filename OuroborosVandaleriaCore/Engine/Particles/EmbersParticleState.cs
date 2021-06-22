using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OuroborosVandaleriaCore.Engine.Emitters;

using System;
using System.Collections.Generic;
using System.Text;



namespace OuroborosVandaleriaCore.Engine.Particles
{
    public class EmbersParticleState : EmitterParticleState
    {
        public override int MinLifespan => 60;

        public override int MaxLifespan => 90;

        public override float Velocity => 4.0f;

        public override float VelocityDeviation => 1.0f;

        public override float Acceleration => 0.8f;

        public override Vector2 Gravity => new Vector2(0, 0);

        public override float Opacity => 0.4f;

        public override float OpacityDeviation => 0.1f;

        public override float OpactiyFadingRate => 0.86f;

        public override float Rotation => 0.0f;

        public override float RotationDeviation => 0.0f;

        public override float Scale => 0.1f;

        public override float ScaleDeviation => 0.05f;
    }

    public class EmbersEmitter : Emitter
    {
        private const int NbParticles = 10;
        private const int MaxParticles = 1000;
        private static Vector2 Direction = new Vector2(0.0f, 1.0f);
        private const float Spread = 1.5f;

        public EmbersEmitter(Texture2D texture, Vector2 position) : base(texture, position, new EmbersParticleState(), new ConeEmitterType(Direction, Spread), NbParticles, MaxParticles)
        {
        }
    }
}
