using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace astra_infinita {
    class Grid {
        public Texture2D horizontalGridLine;
        public Texture2D verticalGridLine;
        
        public void Load(GraphicsDevice graphicsDevice) {
            horizontalGridLine = new Texture2D(graphicsDevice, Game1.window_width, 1);
            verticalGridLine = new Texture2D(graphicsDevice, 1, Game1.window_height);
            Util.ColorTexture(horizontalGridLine, Color.White);
            Util.ColorTexture(verticalGridLine, Color.White);
        }

        public void Unload() {
            horizontalGridLine.Dispose();
            verticalGridLine.Dispose();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            for (int x = 0; x < Game1.world_width; x += Game1.tile_width) {
                spriteBatch.Draw(verticalGridLine, new Vector2(x - cameraPosition.X, 0));
            }
            for (int y = 0; y < Game1.world_height; y += Game1.tile_height) {
                spriteBatch.Draw(horizontalGridLine, new Vector2(0, y - cameraPosition.Y));
            }
        }

        public static void CreateTilesFromGrid(List<Tile> tileList) {
            for (int x = 0; x < Game1.world_width; x += Game1.tile_width) {
                for (int y = 0; y < Game1.world_height; y += Game1.tile_height) {
                    tileList.Add(new Tile(x/Game1.tile_width, y/Game1.tile_height));
                }
            }
        }
    }
}
