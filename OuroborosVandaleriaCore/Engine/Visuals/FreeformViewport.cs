using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace OuroborosVandaleriaCore.Engine.Visuals
{
    public class FreeformViewport : ViewportAdapter
    {
        public override int VirtualWidth 
        { 
            get;
        }

        public override int VirtualHeight
        {
            get;
        }

        public override int ViewportWidth => GraphicsDevice.Viewport.Width;

        public override int ViewportHeight => GraphicsDevice.Viewport.Height;

        public override Matrix GetScaleMatrix()
        {
            var scaleX = (float)ViewportWidth / VirtualWidth;
            var scaleY = (float)ViewportHeight / VirtualHeight;
            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }

        public FreeformViewport(GraphicsDevice graphicsDevice, int virtualWidth, int virtualHeight) : base(graphicsDevice)
        {
            VirtualWidth = virtualWidth;
            VirtualHeight = virtualHeight;
        }
    }
}