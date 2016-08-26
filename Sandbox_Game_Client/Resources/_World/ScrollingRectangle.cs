using Microsoft.Xna.Framework.Graphics;

namespace Sandbox_Game_Client.Resources._World
{
    public class ScrollingRectangle
    {
        public Texture2D Texture { get; set; }
        public float ScrollSpeed { get; set; }

        public ScrollingRectangle(Texture2D Texture, float ScrollSpeed)
        {
            this.Texture = Texture;
            this.ScrollSpeed = ScrollSpeed;
        }
        public virtual void Update()
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
