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
        public int X;
        public int Y;
       public List<GameObject> gameObjects;
        //add object holder so tiles can hold items/objects/things

        public Tile(int x, int y) {
            this.X = x;
            this.Y = y;
            gameObjects = new List<GameObject>();
        }

        public virtual int getX() {
            return this.X;
        }

        public virtual int getY() {
            return this.Y;
        }

        public void Update() {
            
        }

        public static Tile getTile(int x, int y, List<Tile> tilelist)
        {
            
            foreach (Tile t in tilelist)
            {
                if (t.X == x && t.Y == y) return t;
            }
            return null;
        }

        public static void removeObject(Tile t,GameObject obj)
        {
            t.gameObjects.Remove(obj);
        }
        public static void AddObject(Tile t,GameObject obj)
        {
            t.gameObjects.Add(obj);
        }
        public static void removePlayer(Tile t, Player p)
        {
            t.gameObjects.Remove(p);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            foreach (GameObject o in gameObjects)
            {
                if (o.GetType() == typeof(Player)) continue;
                spriteBatch.Draw(o.texture, new Vector2(X*Game1.tile_width,Y*Game1.tile_height)-cameraPosition);
            }
        }
    }
}
