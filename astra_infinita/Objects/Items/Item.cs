using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace astra_infinita.Objects {
    public class Item : GameObject {
        public Item() {

        }

        public Item(String name,Texture2D newTexture) {
            objectName = name;
            texture = newTexture;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) { }

        public override void Update(GameTime gameTime) { }
    }
}
