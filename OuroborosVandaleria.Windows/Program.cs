using System;
using OuroborosVandaleriaGame;

namespace OuroborosVandaleriaGame.Windows
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new OuroborosVandaleria())
                game.Run();
        }
    }
}
