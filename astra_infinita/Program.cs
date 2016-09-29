using System;

namespace astra_infinita {
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program {
       public static Game1 game;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       
        static void Main() {
            game = new Game1();
            using (game)
                game.Run();
        }
    }
}
