using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using astra_infinita.Objects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace astra_infinita
{
    public class Tile
    {
        public Vector2 position;
        public List<List<GameObject>> gameObjects;

        public Tile(Vector2 position) {
            this.position = position;
            gameObjects = new List<List<GameObject>>();
            gameObjects.Add(new List<GameObject>());
        }

        public void Update(GameTime gameTime) {
            for (int curLayer = 0; curLayer < gameObjects.Count; curLayer++) {
                for (int index = 0; index < gameObjects[curLayer].Count; index++) {
                    GameObject obj = gameObjects[curLayer][index];
                    obj.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            for (int curLayer = 0; curLayer < gameObjects.Count; curLayer++) {
                for (int index = 0; index < gameObjects[curLayer].Count; index++) {
                    GameObject obj = gameObjects[curLayer][index];
                    obj.Draw(spriteBatch, cameraPosition);
                }
            }
        }

        public void RemoveObject(GameObject obj) {
            gameObjects[obj.layer].RemoveAt(obj.objectIndex);
        }
        public void AddObject(GameObject obj) {
            gameObjects[obj.layer].Add(obj);
            obj.objectIndex = gameObjects[obj.layer].Count - 1;
        }

        public static Tile getTileAt(Vector2 position, List<List<Tile>> tiles) {
            return tiles[(int)position.X][(int)position.Y];
        }
    }
}
