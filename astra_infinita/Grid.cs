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
        
        public void Load(GraphicsDevice graphicsDevice, int window_width, int window_height) {
            horizontalGridLine = new Texture2D(graphicsDevice, window_width, 1);
            verticalGridLine = new Texture2D(graphicsDevice, 1, window_height);
            Util.ColorTexture(horizontalGridLine, Color.White);
            Util.ColorTexture(verticalGridLine, Color.White);
        }

        public void Unload() {
            horizontalGridLine.Dispose();
            verticalGridLine.Dispose();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition, int world_width, int world_height, int playerWidth, int playerHeight) {
            for (int x = 0; x < world_width; x += playerWidth) {
                spriteBatch.Draw(verticalGridLine, new Vector2(x - cameraPosition.X, 0));
            }
            for (int y = 0; y < world_height; y += playerHeight) {
                spriteBatch.Draw(horizontalGridLine, new Vector2(0, y - cameraPosition.Y));
            }
        }
    }
}
