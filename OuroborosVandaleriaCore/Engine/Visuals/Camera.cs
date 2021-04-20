﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace OuroborosVandaleriaCore.Engine.Visuals
{
    public class Camera
    {
        Vector2 position;
        float speed;

        Rectangle viewportRectangle;

        public Vector2 Position
        {
            get { return position; }
            private set { position = value; }
        } 
        
        public float Speed
        {
            get { return speed; }
            set { speed = (float)MathHelper.Clamp(speed, 1f, 16f); }
        }

        /*public int WidthInPixels
        {
            get { return mapWidth; }
            set { mapWidth = value; }
        }

        public int HeightInPixels
        {
            get { return mapHeight; }
            set { mapHeight = value; }
        }*/

        public Camera(Rectangle viewportRect)
        {
            speed = 4f;
            viewportRectangle = viewportRect;
        }

        public Camera(Rectangle viewportRect, Vector2 position)
        {
            speed = 4f;
            viewportRectangle = viewportRect;
            Position = position;
        }

        //set the bounds of the camera to ensure it doesn't travel beyond the 
        private void CameraLimits()
        {

        }

        public void Update(GameTime gameTime)
        {
            Vector2 motion = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left))
                motion.X = -speed;
            else if (InputHandler.KeyDown(Keys.Right))
                motion.X = speed;

            if (InputHandler.KeyDown(Keys.Up))
                motion.Y = -speed;
            else if (InputHandler.KeyDown(Keys.Down))
                motion.Y = speed;

            if (motion != Vector2.Zero)
                motion.Normalize();

            position += motion * speed;

            CameraLimits();
        }
    }
}