using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OuroborosVandaleriaCore.GameObjects;
using System;
using System.Collections.Generic;

namespace OuroborosVandaleriaCore.Spawners
{
    public class WolfGenerator
    {
        private bool _generateLeft = true;
        private Vector2 _leftVector = new Vector2(-1, 0);
        private Vector2 _downLeftVector = new Vector2(-1, 1);
        private Vector2 _rightVector = new Vector2(1, 0);
        private Vector2 _downRightVector = new Vector2(1, 1);

        private Texture2D _texture;
        private System.Timers.Timer _timer;
        private Action<Wolf> _wolfHandler;
        private int _maxWolves = 0;
        private int _wolvesGenerated = 0;
        private bool _generating = false;

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<(int, Vector2)> path;
            if (_generateLeft)
            {
                path = new List<(int, Vector2)>
                {
                    (0, _rightVector), (2*60, _downRightVector),
                };

                var wolf = new Wolf(_texture, path);
                wolf.Position = new Vector2(-200, 100);
                _wolfHandler(wolf);
            }
            else
            {
                path = new List<(int, Vector2)> { (0, _leftVector), (2 * 60, _downLeftVector), };

                var wolf = new Wolf(_texture, path);
                wolf.Position = new Vector2(1500, 100);
                _wolfHandler(wolf);
            }

            _generateLeft = !_generateLeft;

            _wolvesGenerated++;
            if (_wolvesGenerated == _maxWolves)
                StopGenerating();
        }

        public WolfGenerator(Texture2D texture, int nbWolves, Action<Wolf> handler)
        {
            _texture = texture;
            _wolfHandler = handler;

            _downLeftVector.Normalize();
            _downRightVector.Normalize();

            _maxWolves = nbWolves;

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;
        }

        public void GenerateWolves()
        {
            if (_generating)
            {
                return;
            }

            _wolvesGenerated = 0;
            _timer.Start();
        }

        public void StopGenerating()
        {
            _timer.Stop();
            _generating = false;
        }
    }
}
