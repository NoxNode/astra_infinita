using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using astra_infinita;
namespace astra_infinita.Scenes {
    public class StartingPlanet : Scene {
        public StartingPlanet(int tile_length, int world_width, int world_height) {
            tiles = new List<List<Tile>>();
            this.tile_length = tile_length;
            this.world_width = world_width;
            this.world_height = world_height;
            grid = new Grid();
            grid.CreateTilesFromGrid(tiles, tile_length, world_width, world_height);
        }

        public override void InitializeTilemap(GraphicsDevice graphicsDevice) {
            grid.Load(graphicsDevice);

           Program.game.player = new Player(new Vector2(world_width / 2, world_height / 2), this, graphicsDevice);
            tiles[(int)(Player.getPlayer().position.X / tile_length)][(int)(Player.getPlayer().position.Y / tile_length)].AddObject(Player.getPlayer());
        }

        public override void UninitializeTilemap() {
            grid.Unload();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            grid.Draw(spriteBatch, camera.position, tile_length, world_width, world_height);
            base.Draw(spriteBatch);
        }
    }
}
