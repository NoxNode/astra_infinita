using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace astra_infinita.GUIs {
    public delegate void OnClickFunction();

    class GUIButton : GUIBox {
        OnClickFunction onClick;
        GUIText text;
        bool repeating; // determines whether or not the button should call onClick every frame the mouse is pressed on the button
        bool isPressed; // used to make it so onClick() is only fired once when someone clicks a button (if repeating == false)
        GUI myPetGUI; // this is a reference to any GUI element a button would want to change around when pressed

        public GUIButton(Vector2 position, Texture2D texture, OnClickFunction onClick, GUIText text, GUI myPetGUI = null, bool repeating = false) :
            base(position, texture)
        {
            this.onClick = onClick;
            this.text = text;
            this.isPressed = false;
            this.repeating = repeating;
            this.myPetGUI = myPetGUI;
        }

        ~GUIButton() {
            texture.Dispose();
        }

        public override void Update(GameTime gameTime) {
            if(visible) {
                MouseState mouse = Mouse.GetState();
                Vector2 realPosition = getBasePosition() + this.position;
                if (((!repeating && !isPressed) || repeating) && mouse.LeftButton == ButtonState.Pressed &&
                    mouse.X > realPosition.X && mouse.X < realPosition.X + getWidth() &&
                    mouse.Y > realPosition.Y && mouse.Y < realPosition.Y + getHeight()) {
                    onClick();
                    isPressed = true;
                }
                if (mouse.LeftButton != ButtonState.Pressed) {
                    isPressed = false;
                }

                base.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if(visible) {
                spriteBatch.Draw(texture, getBasePosition() + this.position);
                spriteBatch.DrawString(text.font, text.text, getBasePosition() + this.position + text.position, text.color);

                for (int i = 0; i < children.Count; i++) {
                    children[i].Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// hides myPetGUI on click
        /// </summary>
        /// <param name="position"></param>
        /// <param name="texture"></param>
        /// <param name="text"></param>
        /// <param name="myPetGUI"></param>
        /// <returns></returns>
        public static GUIButton GetHideButton(Vector2 position, Texture2D texture, GUIText text, GUI myPetGUI) {
            return new GUIButton(position, texture, () => {
                myPetGUI.visible = !myPetGUI.visible;
            }, text, myPetGUI);
        }

        /// <summary>
        /// destroys myPetGUI on click
        /// </summary>
        /// <param name="position"></param>
        /// <param name="texture"></param>
        /// <param name="text"></param>
        /// <param name="myPetGUI"></param>
        /// <returns></returns>
        public static GUIButton GetCloseButton(Vector2 position, Texture2D texture, GUIText text, GUI myPetGUI) {
            return new GUIButton(position, texture, () => {
                myPetGUI.parent.RemoveChildAt(myPetGUI.childIndex);
            }, text, myPetGUI);
        }
    }
}
