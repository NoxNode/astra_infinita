using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using astra_infinita;
using astra_infinita.Objects;
namespace astra_infinita {
    public class Player : GameObject{

        Vector2 destination;
        bool up, down, left, right;
        bool up2, down2, left2, right2;
        bool moved;


        public Player(Vector2 startPosition) {
            up = false;
            down = false;
            left = false;
            right = false;
            up2 = false;
            down2 = false;
            left2 = false;
            right2 = false;

            position = new Vector2(startPosition.X, startPosition.Y);
            destination = new Vector2(startPosition.X, startPosition.Y);

            tilePosition = Tile.getTile((int)startPosition.X / Game1.tile_width, (int)startPosition.Y / Game1.tile_height, Game1.mapTiles);
            objectName = "Player";
        }

        public void Load(GraphicsDevice graphicsDevice) {
            texture = new Texture2D(graphicsDevice, Game1.tile_height, Game1.tile_width);
            Util.ColorTexture(texture, Color.Red);
        }

        public void Unload() {
            texture.Dispose();
        }

        public void UpdateMovement(int millisecondsElapsed) {
            Vector2 move_dir = new Vector2(0, 0);
            if (!up && Keyboard.GetState().IsKeyDown(Keys.W)) {
                up = true;
                move_dir.Y -= texture.Height;
                moved = true;
            }
            if (!left && Keyboard.GetState().IsKeyDown(Keys.A)) {
                left = true;
                move_dir.X -= texture.Width;
                moved = true;
            }
            if (!down && Keyboard.GetState().IsKeyDown(Keys.S)) {
                down = true;
                move_dir.Y += texture.Height;
                moved = true;
            }
            if (!right && Keyboard.GetState().IsKeyDown(Keys.D)) {
                right = true;
                move_dir.X += texture.Width;
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
                move_dir.Y -= texture.Height;
                moved = true;
            }
            if (!left2 && !left && Keyboard.GetState().IsKeyDown(Keys.Left)) {
                left2 = true;
                move_dir.X -= texture.Width;
                moved = true;
            }
            if (!down2 && !down && Keyboard.GetState().IsKeyDown(Keys.Down)) {
                down2 = true;
                move_dir.Y += texture.Height;
                moved = true;
            }
            if (!right2 && !right && Keyboard.GetState().IsKeyDown(Keys.Right)) {
                right2 = true;
                move_dir.X += texture.Width;
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

            destination.X += move_dir.X;
            destination.Y += move_dir.Y;

            position.X += (destination.X - position.X) / 100 * millisecondsElapsed;
            position.Y += (destination.Y - position.Y) / 100 * millisecondsElapsed;
            
        }

        public void UpdateTilePosition() {
            if (moved == true)
            {
                tilePostionOld = tilePosition;
                Tile.removeObject(tilePostionOld, Program.game.player);
                tilePosition.X = (int)destination.X / Game1.tile_width;
                tilePosition.Y = (int)destination.Y / Game1.tile_height;
                tilePosition = Tile.getTile(tilePosition.X, tilePosition.Y, Game1.mapTiles);

                Tile.AddObject(tilePosition, this);
                moved = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            spriteBatch.Draw(texture, position - cameraPosition);
        }

        public int getWidth() {
            return texture.Width;
        }

        public int getHeight() {
            return texture.Height;
        }

        public Tile getTile() {
            return tilePosition;
        }

    }
}
