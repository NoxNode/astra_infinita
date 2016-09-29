using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace astra_infinita {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager content;

        public const int window_width = 800, window_height = 600;
        public const int world_width = 800 * 16, world_height = 600 * 16;

        public const int tile_width = 32;
        public const int tile_height = 32;
        public static List<Tile> mapTiles;

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

            graphics.PreferredBackBufferWidth = window_width;
            graphics.PreferredBackBufferHeight = window_height;

            //must be initialized before player.
            mapTiles = new List<Tile>();
      
            grid = new Grid();
            Grid.CreateTilesFromGrid(mapTiles);
            player = new Player(new Vector2(world_width / 2, world_height / 2));
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
            Tile.AddObject(player.getTile(), player);
            //grid.CreateTilesFromGrid();
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
            player.UpdateMovement(gameTime.ElapsedGameTime.Milliseconds);
            player.UpdateTilePosition();
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

            foreach(Tile t in mapTiles)
            {
                t.Draw(spriteBatch, camera.position);
            }
            player.Draw(spriteBatch, camera.position);
            grid.Draw(spriteBatch, camera.position);

            if(player.getTile()!=null)spriteBatch.DrawString(myFont, Convert.ToString(player.getTile().Y), player.position - camera.position, Color.Blue);


            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
