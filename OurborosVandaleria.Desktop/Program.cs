using System;
using OuroborosVandaleriaGame;

namespace OurborosVandaleria.Desktop
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
