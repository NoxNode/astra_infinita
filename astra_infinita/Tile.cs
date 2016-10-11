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
        public GameObject[] gameObjects;

        public Tile(Vector2 position) {
            this.position = position;
            gameObjects = new GameObject[GameObject.num_object_layers];
        }

        public void AddTerrain(TerrainFeature terrain) {
            gameObjects[GameObject.terrain_index] = terrain;
            terrain.myTile = this;
        }

        public void RemoveTerrain() {
            gameObjects[GameObject.terrain_index] = null;
        }

        public void AddItem(Item item) {
            gameObjects[GameObject.item_index] = item;
            item.myTile = this;
        }

        public void RemoveItem() {
            gameObjects[GameObject.item_index] = null;
        }

        public void AddDynamicObject(GameObject dynamicItem) {
            gameObjects[GameObject.dynamic_object_index] = dynamicItem;
            dynamicItem.myTile = this;
        }

        public void RemoveDynamicObject() {
            gameObjects[GameObject.dynamic_object_index] = null;
        }

        public void AddPlayer(Player player) {
            gameObjects[GameObject.player_index] = player;
            player.myTile = this;
        }

        public void RemovePlayer() {
            gameObjects[GameObject.player_index] = null;
        }

        public static Tile getTileAt(Vector2 position, List<List<Tile>> tiles) {
            if (position.X < 0) position.X = 0;
            if (position.X >= tiles.Count) position.X = tiles.Count - 1;
            if (position.Y < 0) position.Y = 0;
            if (position.Y >= tiles[0].Count) position.Y = tiles[0].Count - 1;

            return tiles[(int)position.X][(int)position.Y];
        }
    }
}
