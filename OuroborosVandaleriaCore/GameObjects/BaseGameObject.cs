using System;
using System.Collections.Generic;
using System.Text;

using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.GameState;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace OuroborosVandaleriaCore.GameObjects
{
    public  class BaseGameObject : Sprite
    {
        protected Sprite _sprite;

        public int zIndex;

        public virtual void OnNotify(BaseGameStateEvent eventType) { }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite.Texture, _sprite.Position, Color.White);
        }
    }
}
