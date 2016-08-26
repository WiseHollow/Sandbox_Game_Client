using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Content._Fonts;
using Sandbox_Game_Client.Resources._World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class Neutral : LivingEntity
    {
        public string Name { get; set; }
        public Neutral(World World, Texture2D[] Textures, Vector2 Location, int Health, string Name) : base(World, Textures, Location, Health)
        {
            this.Name = Name;
        }
        public Neutral(World World, Texture2D Texture, Vector2 Location, int Health, string Name) : base(World, new Texture2D[1] { Texture }, Location, Health)
        {
            this.Name = Name;
        }
        public override void Update()
        {
            // TODO: Patrol 

            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Vector2 pos = Location;
            pos.Y += 13;
            spriteBatch.DrawString(Font.Regular, Name, pos, Color.Black);
            spriteBatch.End();

            base.Draw(spriteBatch);
        }
    }
}
