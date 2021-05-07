using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using OuroborosVandaleriaCore.CharacterControl;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.Engine.Visuals
{
    public class Camera
    {
        public Matrix transform;
        Vector2 position;
        Vector2 focus;

        TiledMap _map;

        ViewportAdapter viewportRectangle;

        public Vector2 Position
        {
            get { return position; }
            private set { position = value; }
        }

        public Camera(ViewportAdapter viewportRect, TiledMap map)
        { 
            viewportRectangle = viewportRect;
            _map = map;
        }

        public Camera(ViewportAdapter viewportRect, TiledMap map, Vector2 position)
        {
            viewportRectangle = viewportRect;
            Position = position;
            _map = map;
        }

        //set the bounds of the camera to ensure it doesn't travel beyond the Map's ends
        private bool CameraLimits()
        {
            position.X = MathHelper.Clamp(position.X, 0, _map.WidthInPixels - viewportRectangle.BoundingRectangle.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, _map.HeightInPixels - viewportRectangle.BoundingRectangle.Height);
            if(position.X > viewportRectangle.BoundingRectangle.Right || position.X < viewportRectangle.BoundingRectangle.Left)
            {
                return false;
            } 
            else if (position.Y > viewportRectangle.BoundingRectangle.Top || position.Y < viewportRectangle.BoundingRectangle.Bottom)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FollowPlayer(Player player)
        {
            focus = new Vector2(player.Position.X + (player.Sprite.SpriteMid.X) - (viewportRectangle.Center.X), player.Position.Y + (player.Sprite.SpriteMid.Y) - (viewportRectangle.Center.Y));

            if (CameraLimits())
            {
                transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(focus.X, focus.Y, 0));
            }
            else
            {
                return;
            }
        }

        public void Update(GameTime gameTime, Player player)
        {
            FollowPlayer(player);

            /*Vector2 motion = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left))
                motion.X =- speed;
            else if (InputHandler.KeyDown(Keys.Right))
                motion.X = speed;

            if (InputHandler.KeyDown(Keys.Up))
                motion.Y =- speed;
            else if (InputHandler.KeyDown(Keys.Down))
                motion.Y = speed;

            if (motion != Vector2.Zero)
                motion.Normalize();

            position += motion * speed;*/


        }
    }
}
