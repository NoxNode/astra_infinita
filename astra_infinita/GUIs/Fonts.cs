using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using astra_infinita;
using astra_infinita.GUIs;

namespace astra_infinita.GUIs {
    class Fonts {
        public static SpriteFont testFont;

        public static void InitializeFonts() {
            testFont = Game1.content.Load<SpriteFont>("SpriteFontTemPlate");
        }
    }
}
