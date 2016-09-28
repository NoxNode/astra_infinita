﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace astra_infinita {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager content;

        int window_width, window_height;
        int world_width, world_height;

        Player player;
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

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            window_width = graphics.PreferredBackBufferWidth;
            window_height = graphics.PreferredBackBufferHeight;

            world_width = window_width * 16;
            world_height = window_height * 16;

            player = new Player();
            player.Initialize(new Vector2(world_width / 2, world_height / 2));
            camera = new Camera();
            grid = new Grid();

            myFont = content.Load<SpriteFont>("SpriteFontTemPlate");

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
            grid.Load(GraphicsDevice, window_width, window_height);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
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
            camera.UpdatePosition(player.position, window_width, window_height);

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

            player.Draw(spriteBatch, camera.position);
            grid.Draw(spriteBatch, camera.position, world_width, world_height, player.getWidth(), player.getHeight());

            spriteBatch.DrawString(myFont, "test", player.position - camera.position, Color.Blue);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
