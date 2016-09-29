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
    public class Camera {
        public Vector2 position;

        public Camera() {
            position = new Vector2(0, 0);
        }

        public void UpdatePosition(Vector2 playerPosition) {
            if (playerPosition.X - position.X < Game1.window_width / 3) {
                position.X = playerPosition.X - Game1.window_width / 3;
            }
            if (playerPosition.X - position.X > Game1.window_width * 2 / 3) {
                position.X = playerPosition.X - Game1.window_width * 2 / 3;
            }
            if (playerPosition.Y - position.Y < Game1.window_height / 3) {
                position.Y = playerPosition.Y - Game1.window_height / 3;
            }
            if (playerPosition.Y - position.Y > Game1.window_height * 2 / 3) {
                position.Y = playerPosition.Y - Game1.window_height * 2 / 3;
            }
        }
    }
}
