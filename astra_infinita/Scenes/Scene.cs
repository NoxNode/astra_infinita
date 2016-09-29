using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace astra_infinita {
    public class Scene {
        public Camera camera;
        public List<List<Tile>> tiles;
        public int tile_length;
        public int world_width, world_height;
        public Grid grid;

        public Scene() {
            camera = new Camera();
            tiles = new List<List<Tile>>();
            tile_length = 32;
            world_width = 800 * 8;
            world_height = 600 * 8;
            grid = new Grid();
        }

        public virtual void InitializeTilemap(GraphicsDevice graphicsDevice) {

        }

        public virtual void UninitializeTilemap() {

        }

        public virtual void Update(GameTime gameTime) {
            for (int x = 0; x < tiles.Count; x++) {
                for (int y = 0; y < tiles[x].Count; y++) {
                    tiles[x][y].Update(gameTime);
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            for (int x = 0; x < tiles.Count; x++) {
                for (int y = 0; y < tiles[x].Count; y++) {
                    tiles[x][y].Draw(spriteBatch, camera.position);
                }
            }
        }
    }
}
