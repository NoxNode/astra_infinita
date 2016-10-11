using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using astra_infinita.Objects;
using astra_infinita.GUIs;

namespace astra_infinita {
    public class Scene {
        public Camera camera;
        public List<List<Tile>> tiles;
        public List<GameObject>[] gameObjects;
        public int tile_length;
        public int world_width, world_height;
        public Grid grid;
        public GUI[] GUIs;

        public Scene() {
            camera = new Camera();
            tiles = new List<List<Tile>>();
            gameObjects = new List<GameObject>[GameObject.num_object_layers];
            for(int i = 0; i < GameObject.num_object_layers; i++) {
                gameObjects[i] = new List<GameObject>();
            }
            tile_length = 32;
            world_width = 800 * 8;
            world_height = 600 * 8;
            grid = new Grid();
            GUIs = new GUI[GUI.num_GUI_layers];
            for(int layer = 0; layer < GUI.num_GUI_layers; layer++) {
                GUIs[layer] = new GUI();
            }
        }

        public virtual void InitializeGUI(GraphicsDevice graphicsDevice) { }

        public virtual void InitializeTilemap(GraphicsDevice graphicsDevice) { }

        public virtual void UninitializeTilemap() { }

        public virtual void Update(GameTime gameTime) {
            for (int layer = 0; layer < gameObjects.Length; layer++) {
                for (int i = 0; i < gameObjects[layer].Count; i++) {
                    gameObjects[layer][i].Update(gameTime);
                }
            }
            for(int layer = 0; layer < GUIs.Length; layer++) {
                GUIs[layer].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            for (int layer = 0; layer < gameObjects.Length; layer++) {
                for (int i = 0; i < gameObjects[layer].Count; i++) {
                    gameObjects[layer][i].Draw(spriteBatch, camera.position);
                }
            }
            for (int layer = 0; layer < GUIs.Length; layer++) {
                GUIs[layer].Draw(spriteBatch);
            }
        }
    }
}
