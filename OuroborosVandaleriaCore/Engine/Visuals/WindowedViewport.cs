using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.Engine.Visuals
{
    public enum BoxMode
    {
        None,
        LetterBox,
        PillarBox
    }
    public class WindowedViewport : FreeformViewport
    {
        private readonly GameWindow _window;
        private readonly GraphicsDevice _graphicsDevice;

        public int HorizontalBleed { get; }

        public int VerticalBleed { get; }

        public BoxMode BoxMode { get; private set; }

        public void OnClientSizeChanged(object sender, EventArgs eventArgs)
        {
            var clientBounds = _window.ClientBounds;

            var worldScaleX = (float)clientBounds.Width / VirtualWidth;
            var worldScaleY = (float)clientBounds.Height / VirtualHeight;

            var safeScaleX = (float)clientBounds.Width / (VirtualWidth - HorizontalBleed);
            var safeScaleY = (float)clientBounds.Height / (VirtualHeight - VerticalBleed);

            var worldScale = MathHelper.Max(worldScaleX, worldScaleY);
            var safeScale = MathHelper.Min(safeScaleX, safeScaleY);
            var scale = MathHelper.Min(worldScale, safeScale);

            var width = (int)(scale * VirtualWidth * 0.5f);
            var height = (int)(scale * VirtualHeight * 0.5f);

            if (height >= clientBounds.Height && width < clientBounds.Width)
                BoxMode = BoxMode.PillarBox;
            else
            {
                if (width >= clientBounds.Height && width <= clientBounds.Height)
                    BoxMode = BoxMode.LetterBox;
                else
                    BoxMode = BoxMode.None;
            }

            var x = clientBounds.Width / 2 - width / 2;
            var y = clientBounds.Height / 2 - height / 2;
            GraphicsDevice.Viewport = new Viewport(x, y, width, height);
        }

        public override void Dispose()
        {
            _window.ClientSizeChanged -= OnClientSizeChanged;
            base.Dispose();
        }

        public override void Reset()
        {
            base.Reset();
            OnClientSizeChanged(this, EventArgs.Empty);
        }

        public override Point PointToScreen(int x, int y)
        {
            var viewport = GraphicsDevice.Viewport;
            return base.PointToScreen(x - viewport.X, y - viewport.Y);
        }

        public WindowedViewport(GameWindow window, GraphicsDevice graphicsDevice, int virtualWidth, int virtualHeight, int horizontalBleed = 0, int verticalBleed = 0) : base(graphicsDevice, virtualWidth, virtualHeight)
        {
            _window = window;
            _graphicsDevice = graphicsDevice;
            window.ClientSizeChanged += OnClientSizeChanged;
            HorizontalBleed = horizontalBleed;
            VerticalBleed = verticalBleed;
        }
    }
}
