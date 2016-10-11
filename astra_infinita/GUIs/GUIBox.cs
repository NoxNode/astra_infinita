using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace astra_infinita.GUIs {
    class GUIBox : GUI {
        public Texture2D texture;

        public GUIBox(Vector2 position, Texture2D texture) {
            this.position = new Vector2(position.X, position.Y);
            this.texture = texture;
        }

        ~GUIBox() {
            texture.Dispose();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (visible) {
                spriteBatch.Draw(texture, getBasePosition() + this.position);

                base.Draw(spriteBatch);
            }
        }

        public int getWidth() {
            return texture.Width;
        }
        
        public int getHeight() {
            return texture.Height;
        }
    }
}
