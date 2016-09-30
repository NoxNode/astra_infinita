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
            gameObjects = new GameObject[Game1.num_object_layers];
        }

        public void AddTerrain(TerrainFeature terrain) {
            gameObjects[Game1.terrain_index] = terrain;
            terrain.myTile = this;
        }

        public void RemoveTerrain() {
            gameObjects[Game1.terrain_index] = null;
        }

        public void AddItem(Item item) {
            gameObjects[Game1.item_index] = item;
            item.myTile = this;
        }

        public void RemoveItem() {
            gameObjects[Game1.item_index] = null;
        }

        public void AddDynamicObject(GameObject dynamicItem) {
            gameObjects[Game1.dynamic_object_index] = dynamicItem;
            dynamicItem.myTile = this;
        }

        public void RemoveDynamicObject() {
            gameObjects[Game1.dynamic_object_index] = null;
        }

        public void AddPlayer(Player player) {
            gameObjects[Game1.player_index] = player;
            player.myTile = this;
        }

        public void RemovePlayer() {
            gameObjects[Game1.player_index] = null;
        }

        public static Tile getTileAt(Vector2 position, List<List<Tile>> tiles) {
            return tiles[(int)position.X][(int)position.Y];
        }
    }
}
