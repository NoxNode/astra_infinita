using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace astra_infinita {
    class Util {
        public static void ColorTexture(Texture2D texture, Color color) {
            Color[] colorData = new Color[texture.Width * texture.Height];
            for (int x = 0; x < texture.Width; x++) {
                for (int y = 0; y < texture.Height; y++) {
                    colorData[y * texture.Width + x] = color;
                }
            }
            texture.SetData<Color>(colorData);
        }
    }
}
