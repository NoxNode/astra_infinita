using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace astra_infinita.Objects.TerrainFeatures
{
   public class Water : TerrainFeature {
       public Water() {
            isWater = true;
            isPassable = false;
            objectName = "Shallow Water";
            texture = Program.game.Content.Load<Texture2D>(Path.Combine("TerrainFeatures", "Graphics", "WaterShallow"));
        }

        public override bool getPassability() {
            //maybe add custom passability if you have a raft or boat or can swim?
            return isPassable;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition) {
            // base.Draw(spriteBatch, cameraPosition);
            spriteBatch.Draw(texture, (myTile.position * Program.game.curScene.tile_length) - cameraPosition);

            // spriteBatch.DrawString(myFont, Convert.ToString(waterCurrent), position - cameraPosition, Color.Blue);
        }
    }
}
