using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Control
{
    public class MouseController
    {
        public bool Active { get; set; }
        public Vector2 Location;
        public MouseController()
        {
            Active = true;
        }

        public void Update()
        {
            if (!Active) { return; }
            Location.X = Microsoft.Xna.Framework.Input.Mouse.GetState().X;
            Location.Y = Microsoft.Xna.Framework.Input.Mouse.GetState().Y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) { return; }
            spriteBatch.Begin();
            spriteBatch.Draw(Textures.MOUSE, Location, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
