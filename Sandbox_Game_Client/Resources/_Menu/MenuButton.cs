using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sandbox_Game_Client.Resources._Menu
{
    public class MenuButton
    {
        public Texture2D Texture;

        public Vector2 Location;

        public int Width { get; set; }
        public int Height { get; set; }

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


        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
