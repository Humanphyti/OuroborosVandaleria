using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.GameObjects
{
    class DebugText : BaseTextObject
    {
        public DebugText(SpriteFont font, string text)
        {
            _font = font;
            Text = text;
        }

        public DebugText(SpriteFont font)
        {
            _font = font;
        }
    }
}
