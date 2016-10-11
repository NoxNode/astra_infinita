using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astra_infinita.Objects {
   public class GameObject {
        public Scene curScene;
        public int layer, objectIndex;
        public Tile myTile;
        public Tile myOldTile;
        public Texture2D texture;
        public string objectName;
        public const int terrain_index = 0, item_index = 1, dynamic_object_index = 2, player_index = 3, num_object_layers = 4;

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) { }
    }
}
