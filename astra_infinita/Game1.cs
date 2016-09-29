using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;

namespace astra_infinita {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        MusicPlayer musicPlayer;
        SpriteBatch spriteBatch;
        public static ContentManager content;

        public const int window_width = 800, window_height = 600;
        public const int world_width = 800 * 16, world_height = 600 * 16;

        public const int tile_length = 32;
        public static List<List<Tile>> tiles;

        public Player player;
        Camera camera;
        Grid grid;

        SpriteFont myFont;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // Add your initialization logic here
            this.IsMouseVisible = true;
            content = new ContentManager(base.Content.ServiceProvider, "Content");
            musicPlayer = new MusicPlayer();
            graphics.PreferredBackBufferWidth = window_width;
            graphics.PreferredBackBufferHeight = window_height;

           
            //must be initialized before player.
            tiles = new List<List<Tile>>();
      
            grid = new Grid();
            grid.CreateTilesFromGrid(tiles);
            player = new Player(new Vector2(world_width / 2, world_height / 2));
            tiles[(int)(player.position.X / tile_length)][(int)(player.position.Y / tile_length)].AddObject(player);
            camera = new Camera();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // use this.Content to load your game content here
            player.Load(GraphicsDevice);
            grid.Load(GraphicsDevice);

            myFont = content.Load<SpriteFont>("SpriteFontTemPlate");
            
            musicPlayer.Load();
            musicPlayer.play_song_from_list("wasteland1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // Unload any non ContentManager content here
            player.Unload();
            grid.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Add your update logic here
            //player.UpdateMovement(gameTime.ElapsedGameTime.Milliseconds);
            for (int x = 0; x < tiles.Count; x++) {
                for(int y = 0; y < tiles[x].Count; y++) {
                    tiles[x][y].Update(gameTime);
                }
            }
            camera.UpdatePosition(player.position);

            // TODO: constraints for the player and camera going out of world bounds

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // Add your drawing code here
            spriteBatch.Begin();

            //player.Draw(spriteBatch, camera.position);
            for (int x = 0; x < tiles.Count; x++) {
                for (int y = 0; y < tiles[x].Count; y++) {
                    tiles[x][y].Draw(spriteBatch, camera.position);
                }
            }
            grid.Draw(spriteBatch, camera.position);

            if(player.getTile() != null)
                spriteBatch.DrawString(myFont, Convert.ToString(player.myTile.position.Y), player.position - camera.position, Color.Blue);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
