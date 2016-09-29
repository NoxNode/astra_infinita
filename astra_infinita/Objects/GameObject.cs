using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astra_infinita.Objects {
   public abstract class GameObject {
        public int layer, objectIndex;
        public Tile myTile;
        public Tile myOldTile;
        public Texture2D texture;
        public string objectName;

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition);
    }
}
