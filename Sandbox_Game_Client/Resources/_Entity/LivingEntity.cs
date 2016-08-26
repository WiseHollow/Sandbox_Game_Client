using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class LivingEntity : Entity
    {
        private int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (value > MaxHealth) { health = MaxHealth; }
                if (value < 0) { health = 0; }
            }
        }
        public int MaxHealth { get; set; }
        private bool alive;
        public bool Alive
        {
            set
            {
                alive = value;
            }
            get
            {
                if (Health <= 0) { return false; }
                else { return true; }
            }
        }
        public bool onGround = false;
        public bool OnGround
        {
            get
            {
                Entity e = CheckSolidCollision(new Vector2(Location.X, Location.Y + 1));

                if (e != null) { return true; }
                
                return false;
            }
            set
            {
                onGround = value;
            }
        }
        public bool UseGravity { get; set; }
        public LivingEntity(World World, Texture2D[] Textures, Vector2 Location, int Health) : base(World, Textures, Location)
        {
            this.World = World;
            this.MaxHealth = Health;
            this.Health = Health;

            this.UseGravity = true;
            this.Alive = true;
        }
        public LivingEntity(World World, Texture2D Texture, Vector2 Location) : base(World, new Texture2D[1] { Texture }, Location)
        {
            this.World = World;
            this.MaxHealth = Health;
            this.Health = Health;

            this.UseGravity = true;
            this.Alive = true;
        }
        public override void Update()
        {
            if (UseGravity)
            {
                if (Velocity.Y >= -1 && Velocity.Y <= 1)
                {
                    Velocity.Y += 4;
                }
                else if (Velocity.Y < 0)
                {
                    Velocity.Y *= 0.9f;
                }
            }

            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
