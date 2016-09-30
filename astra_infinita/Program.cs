using System;

namespace astra_infinita {
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program {
       public static Game1 game;
        public static string executingPath;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       
        static void Main() {
            game = new Game1();
            executingPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            executingPath = System.IO.Path.GetDirectoryName(executingPath);
            using (game)
                game.Run();
        }
    }
}
