using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using astra_infinita;
using astra_infinita.GUIs;
using astra_infinita.Objects;

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

        public override void InitializeGUI(GraphicsDevice graphicsDevice) {
            Texture2D texture = new Texture2D(graphicsDevice, tile_length * 4, tile_length * 4);
            Util.ColorTexture(texture, Color.Blue);
            GUIBox box = new GUIBox(new Vector2(50, 50), texture);

            Texture2D texture2 = new Texture2D(graphicsDevice, tile_length, tile_length);
            Util.ColorTexture(texture2, Color.Red);
            GUIText text = new GUIText(new Vector2(5, 5), "dont press me", Fonts.testFont, Color.Yellow);
            GUIButton button = new GUIButton(new Vector2(10, 10), texture2, () => {
                ((Player)Program.game.curScene.gameObjects[GameObject.player_index][0]).waterCurrent--;
            }, text);
            GUIButton button2 = new GUIButton(new Vector2(50, 50), texture2, () => {
                ((Player)Program.game.curScene.gameObjects[GameObject.player_index][0]).waterCurrent--;
            }, text, null, true);

            box.AddChild(button);
            box.AddChild(button2);
            box.AddChild(GUIButton.GetHideButton(new Vector2(10, 50), texture2, text, button2));
            GUIs[GUI.menuGUI_layer].AddChild(box);
        }

        public override void InitializeTilemap(GraphicsDevice graphicsDevice) {
            grid.Load(graphicsDevice);

            Player player = new Player(new Vector2(tile_length, tile_length), this, graphicsDevice);
            tiles[(int)(player.position.X / tile_length)][(int)(player.position.Y / tile_length)].AddPlayer(player);
            gameObjects[GameObject.player_index].Add(player);
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
