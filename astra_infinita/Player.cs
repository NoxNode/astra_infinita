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

namespace astra_infinita {
    class Player {
        public Vector2 position;
        Texture2D texture;
        Vector2 dest;
        bool up, down, left, right;
        bool up2, down2, left2, right2;

        Tile tilePosition;

        public void Initialize(Vector2 startPosition) {
            up = false;
            down = false;
            left = false;
            right = false;
            up2 = false;
            down2 = false;
            left2 = false;
            right2 = false;

            position = new Vector2(startPosition.X, startPosition.Y);
            dest = new Vector2(startPosition.X, startPosition.Y);
            tilePosition = new Tile((int)startPosition.X / Program.game.tile_width, (int)startPosition.Y / Program.game.tile_height);
        }

        public void Load(GraphicsDevice graphicsDevice) {
            texture = new Texture2D(graphicsDevice, Program.game.tile_height, Program.game.tile_width);
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
            }
            if (!left && Keyboard.GetState().IsKeyDown(Keys.A)) {
                left = true;
                move_dir.X -= texture.Width;
            }
            if (!down && Keyboard.GetState().IsKeyDown(Keys.S)) {
                down = true;
                move_dir.Y += texture.Height;
            }
            if (!right && Keyboard.GetState().IsKeyDown(Keys.D)) {
                right = true;
                move_dir.X += texture.Width;
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
            }
            if (!left2 && !left && Keyboard.GetState().IsKeyDown(Keys.Left)) {
                left2 = true;
                move_dir.X -= texture.Width;
            }
            if (!down2 && !down && Keyboard.GetState().IsKeyDown(Keys.Down)) {
                down2 = true;
                move_dir.Y += texture.Height;
            }
            if (!right2 && !right && Keyboard.GetState().IsKeyDown(Keys.Right)) {
                right2 = true;
                move_dir.X += texture.Width;
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

            position.X += (dest.X - position.X) / 100 * millisecondsElapsed;
            position.Y += (dest.Y - position.Y) / 100 * millisecondsElapsed;
            //updateTilePosition();
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
        public void updateTilePosition(GameTime gameTime)
        {
            tilePosition.X =(int) position.X / Program.game.tile_width;
            tilePosition.Y = (int)position.Y / Program.game.tile_height;
        }
        public Tile getTile()
        {
            return tilePosition;
        }

    }
}
