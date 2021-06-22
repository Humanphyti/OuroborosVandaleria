using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

using OuroborosVandaleriaCore.Engine.Sprite;
using OuroborosVandaleriaCore.GameObjects;

namespace OuroborosVandaleriaCore.Maps
{
    public class GameMap : BaseGameObject
    {
        protected TiledMap _tiledMap;

        public GameMap(TiledMap tiledmap, GraphicsDevice graphicsDevice)
        {
            Position = new Vector2(0, 0);
            _tiledMap = tiledmap;
            
        }

        public void Render(SpriteBatch spriteBatch, TiledMapRenderer tiledMapRenderer)
        {
            var viewport = spriteBatch.GraphicsDevice.Viewport;
            //var sourceRectangle = new Rectangle();
        }
        
    }
}
