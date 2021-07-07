using System;

using OuroborosVandaleriaCore.Screen;
using OuroborosVandaleriaCore.Screen.Dev;
using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaGame;

namespace OuroborosVandaleriaGame.Windows
{
    public static class Program
    {
        private const int WIDTH = 1920;
        private const int HEIGHT = 1080;
        [STAThread]
        static void Main()
        {
            using (var game = new OuroborosVandaleria(WIDTH, HEIGHT, new TitleScreen()))
                game.Run();
        }
    }
}
