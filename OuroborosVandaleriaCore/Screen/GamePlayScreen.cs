using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using OuroborosVandaleriaCore.Engine;
using OuroborosVandaleriaCore.Engine.Controls;
using OuroborosVandaleriaCore.Engine.State;
using OuroborosVandaleriaCore.Engine.Visuals;
using OuroborosVandaleriaCore.Maps;
using OuroborosVandaleriaCore.CharacterControl;
using OuroborosVandaleriaGame;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.Screen
{
    public class GamePlayScreen : BaseGameState
    {
        Player player;
        Camera camera;
        //OuroborosVandaleria Game => (OuroborosVandaleria)base.Game;

        TiledMap map;
        TiledMapRenderer mapRenderer;

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        //constructor
        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            player = new Player(game);
            
        }

        //override methods
        public override void Initialize()
        {
            var viewport = new WindowedViewport(Game.Window, GraphicsDevice, 640, 360);
            camera = new Camera(viewport, map);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;
            map = Content.Load<TiledMap>("testVillage/testVillage");
            mapRenderer = new TiledMapRenderer(GraphicsDevice, map);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            mapRenderer.Update(gameTime);
            player.Update(gameTime);
            camera.Update(gameTime, player);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            mapRenderer.Draw();
            //player.Camera.Draw();
            base.Draw(gameTime);
        }
    }
}
