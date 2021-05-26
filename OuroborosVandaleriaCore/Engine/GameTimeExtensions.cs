using Microsoft.Xna.Framework;

namespace OuroborosVandaleriaCore.Engine
{
    public static class GameTimeExtensions
    {
        public static float GetEleapsedSeconds(this GameTime gameTime)
        {
            return (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
