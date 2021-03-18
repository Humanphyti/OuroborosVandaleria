﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace OuroborosVandaleriaCore.Engine
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        //variables
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;

        //getters
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        //constructor
        public InputHandler(Game game) : base(game)
        {
            keyboardState = Keyboard.GetState();
        }

        //Monogame Methods
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            base.Update(gameTime);
        }

        //clear the input buffer
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }

        //is the key up, down, or just pressed.
        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

    }
}