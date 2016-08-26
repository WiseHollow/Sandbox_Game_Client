using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Content._Fonts;
using Sandbox_Game_Client.Resources._World;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class Enemy : LivingEntity
    {
        public string Name { get; set; }
        public Enemy(World World, Texture2D[] Textures, Vector2 Location, int Health, string Name) : base(World, Textures, Location, Health)
        {
            this.Name = Name;
        }
        public Enemy(World World, Texture2D Texture, Vector2 Location, int Health, string Name) : base(World, new Texture2D[1] { Texture }, Location, Health)
        {
            this.Name = Name;
        }
        public override void Update()
        {
            // TODO: Patrol until sees enemy

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
