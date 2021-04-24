using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

//this is a collection of maps which will contain either chunks of significantly larger maps or submaps navigated via doors
//features will be implemented as a base class
//to be extended into the various Maps of the Game. It will be handed to the camera to
//determine travel bounds
namespace OuroborosVandaleriaCore.Maps
{
    public class Area : Map
    {
        
        TiledMap map;
        TiledMapRenderer tiledMapRenderer;

        GraphicsDevice graphicsDevice;
        ContentManager Content;
        List<TiledMap> maps = new List<TiledMap>();

        protected void LoadContent()
        {

            map = Content.Load<TiledMap>("testVillage/testVillage");
            tiledMapRenderer = new TiledMapRenderer(graphicsDevice, map);
        }

        public Area LoadArea()
        {

            return 
        }
    }
}
