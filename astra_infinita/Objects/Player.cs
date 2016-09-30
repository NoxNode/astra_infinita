using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using astra_infinita.Objects;
using astra_infinita.Objects.TerrainFeatures;

namespace astra_infinita {
    public class Player : GameObject {
        public Vector2 position;
        bool up, down, left, right;
        bool up2, down2, left2, right2;
        public List<Item> inventory;

        double stomachMax;
        double stomachCurrent;
        int waterMax;
        int waterCurrent;

        const int waterDecay = 1;
        const double foodDecay = .4;

        SpriteFont myFont;

        public Player()
        {
            //used for .Json serialization. Do not remove.
        }

        public Player(Vector2 startPosition, Scene curScene, GraphicsDevice graphicsDevice) {
            layer = 0;
            objectIndex = 0;

            up = false;
            down = false;
            left = false;
            right = false;
            up2 = false;
            down2 = false;
            left2 = false;
            right2 = false;

            position = new Vector2(startPosition.X, startPosition.Y);
            myTile = Tile.getTileAt(startPosition / curScene.tile_length, curScene.tiles);
            this.curScene = curScene;
            objectName = "Player";
            inventory = new List<Item>();
            inventory.Capacity = 8;

            stomachMax = 20;
            stomachCurrent = stomachMax;
            waterMax = 30;
            waterCurrent = waterMax;

            Load(graphicsDevice);

            myFont = Game1.content.Load<SpriteFont>("SpriteFontTemPlate");
        }

        ~Player() {
            Unload();
        }

        public override void Update(GameTime gameTime) {
            UpdateMovement(gameTime.ElapsedGameTime.Milliseconds);
            UpdateCameraPosition();
            if (Keyboard.GetState().IsKeyDown(Keys.J)) {
                SaveSystem.SaveGame.Save(this);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O)) {
                Water water = new Water();
                Tile.getTileAt(new Vector2(myTile.position.X - 1, myTile.position.Y), curScene.tiles).AddTerrain(water);
                curScene.gameObjects[Game1.terrain_index].Add(water);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            spriteBatch.Draw(texture, position - cameraPosition);

            spriteBatch.DrawString(myFont, Convert.ToString(waterCurrent), position - cameraPosition, Color.Blue);
        }

        public void Load(GraphicsDevice graphicsDevice) {
            texture = new Texture2D(graphicsDevice, curScene.tile_length, curScene.tile_length);
            Util.ColorTexture(texture, Color.Red);
        }

        public void Unload() {
            texture.Dispose();
        }

        public void UpdateMovement(int millisecondsElapsed) {
            Vector2 move_dir = new Vector2(0, 0);
            bool moved = false;

            if (!up && Keyboard.GetState().IsKeyDown(Keys.W)) {
                up = true;
                move_dir.Y--;
                moved = true;
            }
            if (!left && Keyboard.GetState().IsKeyDown(Keys.A)) {
                left = true;
                move_dir.X--;
                moved = true;
            }
            if (!down && Keyboard.GetState().IsKeyDown(Keys.S)) {
                down = true;
                move_dir.Y++;
                moved = true;
            }
            if (!right && Keyboard.GetState().IsKeyDown(Keys.D)) {
                right = true;
                move_dir.X++;
                moved = true;
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
                move_dir.Y--;
                moved = true;
            }
            if (!left2 && !left && Keyboard.GetState().IsKeyDown(Keys.Left)) {
                left2 = true;
                move_dir.X--;
                moved = true;
            }
            if (!down2 && !down && Keyboard.GetState().IsKeyDown(Keys.Down)) {
                down2 = true;
                move_dir.Y++;
                moved = true;
            }
            if (!right2 && !right && Keyboard.GetState().IsKeyDown(Keys.Right)) {
                right2 = true;
                move_dir.X++;
                moved = true;
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

            // TODO: constraints for the player and camera going out of world bounds

            if (moved) {
                UpdateTilePosition(move_dir);
                UpdateFoodAndWater();
            }

            position.X += (myTile.position.X * curScene.tile_length - position.X) / 100 * millisecondsElapsed;
            position.Y += (myTile.position.Y * curScene.tile_length - position.Y) / 100 * millisecondsElapsed;
        }

        public void UpdateTilePosition(Vector2 move_dir) {
            myOldTile = myTile;
            myOldTile.RemovePlayer();

            myTile = Tile.getTileAt(myTile.position + move_dir, curScene.tiles);
            myTile.AddPlayer(this);
        }

        public void UpdateFoodAndWater() {
            if (stomachCurrent > 0)
                stomachCurrent -= foodDecay;
            if (waterCurrent > 0)
                waterCurrent -= waterDecay;
        }

        public void UpdateCameraPosition() {
            if (position.X - curScene.camera.position.X < Game1.window_width / 3) {
                curScene.camera.position.X = position.X - Game1.window_width / 3;
            }
            if (position.X - curScene.camera.position.X > Game1.window_width * 2 / 3) {
                curScene.camera.position.X = position.X - Game1.window_width * 2 / 3;
            }
            if (position.Y - curScene.camera.position.Y < Game1.window_height / 3) {
                curScene.camera.position.Y = position.Y - Game1.window_height / 3;
            }
            if (position.Y - curScene.camera.position.Y > Game1.window_height * 2 / 3) {
                curScene.camera.position.Y = position.Y - Game1.window_height * 2 / 3;
            }
        }

        public int getWidth() {
            return texture.Width;
        }

        public int getHeight() {
            return texture.Height;
        }

        public bool isInventoryFull() {
            if (inventory.Count == inventory.Capacity)
                return true;
            else
                return false;
        }

        public bool AddItemToInventory(Item I) {
            if (isInventoryFull() == false) {
                inventory.Add(I);
                return true;
            }
            return false;
        }
        public bool AddItemToInventoryFromTile(Item I, Tile T) {
            if (isInventoryFull() == false) {
                inventory.Add(I);
                T.RemoveItem();
                return true;
            }
            return false;
        }

        public void RemoveItemFromInventory(Item I) {
            inventory.Remove(I);
        }

        public void DropItem(Item I, Tile T) {
            inventory.Remove(I);
            T.AddItem(I);
        }
    }
}
