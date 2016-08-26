using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class Collidable
    {
        public Vector2 Location;
        public int Width { get; set; }
        public int Height { get; set; }

        public Collidable(Vector2 Location, int Width, int Height)
        {
            this.Location = Location;
            this.Width = Width;
            this.Height = Height;
        }
        public bool Collides(Entity e)
        {
            if (Location.X < e.Location.X + e.Textures[e.TextureIndex].Width &&
                Location.X + Width > e.Location.X &&
                Location.Y < e.Location.Y + e.Textures[e.TextureIndex].Height &&
                Height + Location.Y > e.Location.Y)
            {
                return true;
            }

            return false;
        }
        public bool Collides(Entity e, Vector2 Position)
        {
            if (Position.X < e.Location.X + e.Textures[e.TextureIndex].Width &&
                Position.X + Width > e.Location.X &&
                Position.Y < e.Location.Y + e.Textures[e.TextureIndex].Height &&
                Height + Position.Y > e.Location.Y)
            {
                return true;
            }

            return false;
        }
    }
}
