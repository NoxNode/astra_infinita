using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace astra_infinita.Objects.TerrainFeatures {
   public class TerrainFeature :GameObject {
       public bool isPassable;
       public bool isWater;

        public TerrainFeature() {
            layer = 0;
        }
        
        public virtual bool getPassability() {
            return isPassable;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            base.Draw(spriteBatch, cameraPosition);
        }
    }
}
