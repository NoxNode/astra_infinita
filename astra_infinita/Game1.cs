﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using astra_infinita.Scenes;
using astra_infinita.Objects.TerrainFeatures;

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

        public Scene curScene;

        public Dictionary<string,TerrainFeature> terrainList;

        public Player player;

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

            musicPlayer = new MusicPlayer();

            curScene = new StartingPlanet(32, 800 * 16, 600 * 16);

            terrainList = new Dictionary<string, TerrainFeature>();


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
            curScene.InitializeTilemap(GraphicsDevice);
            musicPlayer.Load();
            musicPlayer.playSongFromList("wasteland1");
            TerrainFeature.loadAllTerrainFeatures();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // Unload any non ContentManager content here
            curScene.UninitializeTilemap();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                TerrainFeature T;
                terrainList.TryGetValue("Shallow Water", out T);
                Tile.getTileAt(new Vector2(Player.getPlayer().myTile.position.X - 1, Player.getPlayer().myTile.position.Y), curScene.tiles).AddTerrainFeature(T);
                Tile.getTileAt(new Vector2(Player.getPlayer().myTile.position.X - 1, Player.getPlayer().myTile.position.Y), curScene.tiles).terrain.myTile = Tile.getTileAt(new Vector2(Player.getPlayer().myTile.position.X - 1, Player.getPlayer().myTile.position.Y), curScene.tiles);
                Console.WriteLine(Tile.getTileAt(new Vector2(Player.getPlayer().myTile.position.X - 1, Player.getPlayer().myTile.position.Y), curScene.tiles).terrain.objectName);
                Console.WriteLine(Tile.getTileAt(new Vector2(Player.getPlayer().myTile.position.X - 1, Player.getPlayer().myTile.position.Y), curScene.tiles).position.X);
                Console.WriteLine(Tile.getTileAt(new Vector2(Player.getPlayer().myTile.position.X - 1, Player.getPlayer().myTile.position.Y), curScene.tiles).position.Y);
            }

            // Add your update logic here
            curScene.Update(gameTime);
            musicPlayer.Update(gameTime);
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

            curScene.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
