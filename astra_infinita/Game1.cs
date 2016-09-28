using Microsoft.Xna.Framework;
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
        Texture2D texture;
        Vector2 position;
        Vector2 dest;
        Vector2 camera;
        Texture2D horizontalGridLine;
        Texture2D verticalGridLine;
        int window_width, window_height;
        int world_width, world_height;
        bool up, down, left, right;
        bool up2, down2, left2, right2;
        SpriteFont myFont;
        ContentManager content;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        void ColorTexture(Texture2D texture, Color color) {
            Color[] colorData = new Color[texture.Width * texture.Height];
            for (int x = 0; x < texture.Width; x++) {
                for(int y = 0; y < texture.Height; y++) {
                    colorData[y * texture.Width + x] = color;
                }
            }
            texture.SetData<Color>(colorData);
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

            myFont = content.Load<SpriteFont>("SpriteFontTemPlate");

            up = false;
            down = false;
            left = false;
            right = false;
            up2 = false;
            down2 = false;
            left2 = false;
            right2 = false;

            world_width = window_width * 16;
            world_height = window_height * 16;

            camera = new Vector2(0, 0);
            position = new Vector2(window_width * 8, window_height * 8);
            dest = new Vector2(window_width * 8, window_height * 8);
            texture = new Texture2D(this.GraphicsDevice, 50, 50);
            ColorTexture(texture, Color.Red);

            horizontalGridLine = new Texture2D(this.GraphicsDevice, window_width, 1);
            ColorTexture(horizontalGridLine, Color.White);
            verticalGridLine = new Texture2D(this.GraphicsDevice, 1, window_height);
            ColorTexture(verticalGridLine, Color.White);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
            texture.Dispose();
            horizontalGridLine.Dispose();
            verticalGridLine.Dispose();
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
            Vector2 move_dir = new Vector2(0, 0);
            if (!up && Keyboard.GetState().IsKeyDown(Keys.W)) {
                up = true;
                move_dir.Y -= 50;
            }
            if (!left && Keyboard.GetState().IsKeyDown(Keys.A)) {
                left = true;
                move_dir.X -= 50;
            }
            if (!down && Keyboard.GetState().IsKeyDown(Keys.S)) {
                down = true;
                move_dir.Y += 50;
            }
            if (!right && Keyboard.GetState().IsKeyDown(Keys.D)) {
                right = true;
                move_dir.X += 50;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W)) {
                up = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.A)) {
                left = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.S)) {
                down = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D)) {
                right = false;
            }

            if (!up2 && !up && Keyboard.GetState().IsKeyDown(Keys.Up)) {
                up2 = true;
                move_dir.Y -= 50;
            }
            if (!left2 && !left && Keyboard.GetState().IsKeyDown(Keys.Left)) {
                left2 = true;
                move_dir.X -= 50;
            }
            if (!down2 && !down && Keyboard.GetState().IsKeyDown(Keys.Down)) {
                down2 = true;
                move_dir.Y += 50;
            }
            if (!right2 && !right && Keyboard.GetState().IsKeyDown(Keys.Right)) {
                right2 = true;
                move_dir.X += 50;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Up)) {
                up2 = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left)) {
                left2 = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Down)) {
                down2 = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Right)) {
                right2 = false;
            }

            dest.X += move_dir.X;
            dest.Y += move_dir.Y;

            position.X += (dest.X - position.X) / 5;
            position.Y += (dest.Y - position.Y) / 5;

            if (position.X - camera.X < window_width / 3) {
                camera.X = position.X - window_width / 3;
            }
            if (position.X - camera.X > window_width * 2 / 3) {
                camera.X = position.X - window_width * 2 / 3;
            }
            if (position.Y - camera.Y < window_height / 3) {
                camera.Y = position.Y - window_height / 3;
            }
            if (position.Y - camera.Y > window_height * 2 / 3) {
                camera.Y = position.Y - window_height * 2 / 3;
            }

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
            spriteBatch.Draw(texture, position - camera);
            for (int x = 0; x < world_width; x += 50) {
                spriteBatch.Draw(verticalGridLine, new Vector2(x - camera.X, 0));
            }
            for (int y = 0; y < world_height; y += 50) {
                spriteBatch.Draw(horizontalGridLine, new Vector2(0, y - camera.Y));
            }
            spriteBatch.DrawString(myFont, "test", position - camera, Color.Blue);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
