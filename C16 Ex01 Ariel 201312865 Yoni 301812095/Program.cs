using System;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
#if WINDOWS || LINUX

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameInvaders())
            {
                game.Run();
            }
        }
    }
#endif
}
