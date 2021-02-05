using System;
using OuroborosVandaleriaGame;

namespace OurborosVandaleriaDesktop
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
