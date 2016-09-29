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
            horizontalGridLine = new Texture2D(graphicsDevice, Program.game.window_width, 1);
            verticalGridLine = new Texture2D(graphicsDevice, 1, Program.game.window_height);
            Util.ColorTexture(horizontalGridLine, Color.White);
            Util.ColorTexture(verticalGridLine, Color.White);
        }

        public void Unload() {
            horizontalGridLine.Dispose();
            verticalGridLine.Dispose();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            for (int x = 0; x < Program.game.world_width; x += Program.game.tile_width) {
                spriteBatch.Draw(verticalGridLine, new Vector2(x - cameraPosition.X, 0));
            }
            for (int y = 0; y < Program.game.world_height; y += Program.game.tile_height) {
                spriteBatch.Draw(horizontalGridLine, new Vector2(0, y - cameraPosition.Y));
            }
        }

        public void CreateTilesFromGrid() {
            for (int x = 0; x < Program.game.world_width; x += Program.game.tile_width) {
                for (int y = 0; y < Program.game.world_height; y += Program.game.tile_height) {
                    Program.game.mapTiles.Add(new Tile(x, y));
                }
            }
        }
    }
}
