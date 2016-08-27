using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._Entity;
using System;

namespace Sandbox_Game_Client.Resources._World
{
    public class Foreground : ScrollingRectangle
    {
        public Point[] Points { get; set; }

        public Foreground(Texture2D Texture, float ScrollSpeed, Point[] Points) : base (Texture, ScrollSpeed)
        {
            this.Points = Points;
        }
        public bool Collides(Entity e)
        {
            Point[] closest = new Point[2];
            int Distance = int.MaxValue;

            foreach (Point p in Points)
            {
                int d = (int)Math.Abs(e.Location.X - p.X);
                if (d < Distance)
                {
                    closest[0] = p;
                    Distance = d;
                }
            }
            Distance = int.MaxValue;
            foreach (Point p in Points)
            {
                int d = (int)Math.Abs(e.Location.X - p.X);
                if (d < Distance && closest[0] != p)
                {
                    closest[0] = p;
                    Distance = d;
                }
            }

            //
            // Have the two closest points
            //

            double slope = (((double)closest[1].Y - (double)closest[0].Y) / ((double)closest[1].X - (double)closest[0].X));
            double slope2 = (((double)closest[0].Y - (double)e.Location.Y) / ((double)closest[0].X - (double)e.Location.X));

            if (slope2 < slope)
                if (slope2 % slope == 0) { return true; }
            else
                if (slope % slope2 == 0) { return true; }

            return false;
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
