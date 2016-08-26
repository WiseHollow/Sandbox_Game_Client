using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sandbox_Game_Client.Resources._Menu
{
    public class MenuButton
    {
        public Texture2D Texture;

        public Vector2 Location;

        public int Width { get; set; }
        public int Height { get; set; }

        public bool Selected { get; set; }

        public MenuButton(Texture2D Texture, Vector2 Location)
        {
            this.Texture = Texture;
            this.Location = Location;

            this.Width = Texture.Width;
            this.Height = Texture.Height;
        }
        public void Update()
        {
            int MouseX = Microsoft.Xna.Framework.Input.Mouse.GetState().X;
            int MouseY = Microsoft.Xna.Framework.Input.Mouse.GetState().Y;

            if (MouseX >= Location.X && MouseX <= Location.X + Width && MouseY >= Location.Y && MouseY <= Location.Y + Height)
            {
                Selected = true;

                if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Press();
                }
            }
            else
            {
                Selected = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (Selected)
                spriteBatch.Draw(Texture, Location, Color.White);
            else
                spriteBatch.Draw(Texture, Location, Color.Black);
            spriteBatch.End();
        }
        public virtual void Press() { throw new NotImplementedException(); }
    }
}
