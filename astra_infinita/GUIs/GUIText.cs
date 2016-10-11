using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace astra_infinita.GUIs {
    class GUIText : GUI {
        public string text;
        public SpriteFont font;
        public Color color;

        public GUIText(Vector2 position, string text, SpriteFont font, Color color) {
            this.position = new Vector2(position.X, position.Y);
            this.text = text;
            this.font = font;
            this.color = color;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if(visible) {
                spriteBatch.DrawString(font, text, getBasePosition() + this.position, color);

                base.Draw(spriteBatch);
            }
        }
    }
}
