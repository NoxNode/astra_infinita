using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace astra_infinita.GUIs {
    public class GUI {
        public Vector2 position;
        public GUI parent;
        public List<GUI> children;
        public int childIndex;
        public bool visible;
        public static int gameGUI_layer = 0, eventGUI_layer = 1, menuGUI_layer = 2, importantGUI_layer = 3, num_GUI_layers = 4;

        public GUI() {
            position = new Vector2(0, 0);
            parent = null;
            children = new List<GUI>();
            childIndex = 0;
            visible = true;
        }

        public virtual void Update(GameTime gameTime) {
            for (int i = 0; i < children.Count; i++) {
                children[i].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if(visible) {
                for (int i = 0; i < children.Count; i++) {
                    children[i].Draw(spriteBatch);
                }
            }
        }

        public Vector2 getBasePosition() {
            Vector2 basePosition = new Vector2(0, 0);
            GUI curGUI = parent;

            while (curGUI != null) {
                basePosition += curGUI.position;
                curGUI = curGUI.parent;
            }

            return basePosition;
        }

        public void AddChild(GUI child) {
            children.Add(child);
            child.parent = this;
            child.childIndex = children.Count - 1;
        }

        public void RemoveChildAt(int index) {
            children.RemoveAt(index);
        }

        public GUI GetChildAt(int index) {
            return children[index];
        }
    }
}
