using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using astra_infinita.Objects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using astra_infinita.Objects.TerrainFeatures;

namespace astra_infinita {
    public class Tile {
        public Vector2 position;
        public List<List<GameObject>> gameObjects;

        public TerrainFeature terrain;
        public bool isPassable;

        public Tile(Vector2 position) {
            this.position = position;
            gameObjects = new List<List<GameObject>>();
            gameObjects.Add(new List<GameObject>());
            isPassable = true;
        }

        public void Update(GameTime gameTime) {
            for (int curLayer = 0; curLayer < gameObjects.Count; curLayer++) {
                for (int index = 0; index < gameObjects[curLayer].Count; index++) {
                    GameObject obj = gameObjects[curLayer][index];
                    obj.Update(gameTime);
                    
                }
            }
            if(terrain!=null)terrain.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            for (int curLayer = 0; curLayer < gameObjects.Count; curLayer++) {
                for (int index = 0; index < gameObjects[curLayer].Count; index++) {
                    GameObject obj = gameObjects[curLayer][index];
                    obj.Draw(spriteBatch, cameraPosition);

                    }
            }
            if (terrain != null)
            {
                if (terrain.GetType() == typeof(Water)) (terrain as Water).Draw(spriteBatch, cameraPosition);
            }
        }

        public void RemoveObject(GameObject obj) {
            gameObjects[obj.layer].RemoveAt(obj.objectIndex);
        }

        public void AddObject(GameObject obj) {
            gameObjects[obj.layer].Add(obj);
            obj.objectIndex = gameObjects[obj.layer].Count - 1;
        }

        public void AddTerrainFeature(TerrainFeature T)
        {
            terrain = T;
        }

        public void RemoveTerrainFeature(TerrainFeature T)
        {
            terrain = null;
        }

        public TerrainFeature getTerrainFeature()
        {
            return terrain;
        }

        public void getPassabilityFromTerrain()
        {
            isPassable = terrain.isPassable;
        }

        public bool getPassability()
        {
            getPassabilityFromTerrain();
            return isPassable;
        }

        public static Tile getTileAt(Vector2 position, List<List<Tile>> tiles) {
            return tiles[(int)position.X][(int)position.Y];
        }
    }
}
