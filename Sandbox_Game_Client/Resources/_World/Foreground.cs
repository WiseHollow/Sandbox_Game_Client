using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sandbox_Game_Client.Resources._World
{
    public class Foreground : ScrollingRectangle
    {
        public Point[] Points { get; set; }

        public Foreground(Texture2D Texture, float ScrollSpeed, Point[] Points) : base (Texture, ScrollSpeed)
        {
            this.Points = Points;
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
