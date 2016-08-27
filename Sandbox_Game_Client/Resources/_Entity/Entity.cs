using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._World;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class Entity : Collidable
    {
        //public Vector2 Location;
        public Vector2 Velocity;
        public World World { get; set; }
        public Direction2D Direction { get; set; }
        public Texture2D[] Textures { get; set; }
        private int textureIndex = 0;
        public int TextureIndex
        {
            get
            {
                return textureIndex;
            }
            set
            {
                textureIndex = value;
                if (value >= Textures.Length)
                {
                    textureIndex = 0;
                }
            }
        }
        public bool Solid { get; set; }

        public Entity(World World, Texture2D[] Textures, Vector2 Location) : base (Location, Textures[0].Width, Textures[0].Height)
        {
            this.World = World;
            this.Location = Location;
            this.Direction = Direction2D.RIGHT;
            this.Textures = Textures;

            Solid = true;
        }
        public Entity(World World, Texture2D Texture, Vector2 Location) : base(Location, Texture.Width, Texture.Height)
        {
            this.World = World;
            this.Location = Location;
            this.Direction = Direction2D.RIGHT;
            this.Textures = new Texture2D[1] { Texture };

            Solid = true;
        }
        public Entity CheckEntityCollision()
        {
            foreach (Entity e in World.Entities)
            {
                if (this.Collides(e)) { return e; }
            }

            return null;
        }
        public Entity CheckSolidCollision()
        {
            foreach (Entity e in World.Entities)
            {
                if (!e.Solid) { continue; }
                if (this.Collides(e)) { return e; }
            }
            return null;
        }
        public Entity CheckSolidCollision(Vector2 Position)
        {
            foreach (Entity e in World.Entities)
            {
                if (!e.Solid) { continue; }
                if (this.Collides(e, Position)) { return e; }
            }

            return null;
        }
        public LivingEntity CheckLivingEntityCollision()
        {
            foreach (LivingEntity e in World.LivingEntities)
            {
                if (this.Collides(e)) { return e; }
            }

            return null;
        }
        public bool CheckForegroundCollision()
        {
            if (World.Foreground.Collides(this)) { return true; }
            return false;
        }
        public void Remove()
        {
            World.Entities.Remove(this);
            if (this is LivingEntity) { World.LivingEntities.Remove(this as LivingEntity); }
        }
        public virtual void Update()
        {
            if (!(this is LivingEntity) && Textures.Length != 0) { TextureIndex++; } // Entities with more than one texture, will have a constant animation.

            if (Velocity.X != 0) // Move towards velocity.
            {
                if (Velocity.X > 0) { Direction = Direction2D.RIGHT; }
                else { Direction = Direction2D.LEFT; }

                Location.X += Velocity.X;
                Entity e = CheckSolidCollision();
                if (e != null)
                {
                    if (Direction == Direction2D.LEFT) { Location.X = e.Location.X + e.Textures[e.TextureIndex].Width; }
                    else { Location.X = e.Location.X - Textures[TextureIndex].Height; }
                    e = null;
                }
                Velocity.X = (Velocity.X * 0.9f);
            }
            if (Velocity.Y != 0)
            {
                Location.Y += Velocity.Y;
                if (CheckForegroundCollision())
                {
                    Location.Y -= Velocity.Y;
                    Velocity.Y = 0;
                }
                Entity e = CheckSolidCollision();
                if (e != null)
                {
                    if (Velocity.Y > 0)
                    {
                        int height = Textures[TextureIndex].Height;
                        Location.Y = e.Location.Y - height;
                        e = null;
                    } else
                    {
                        Velocity.Y = 0;
                        int height = e.Textures[e.TextureIndex].Height;
                        Location.Y = e.Location.Y + height;
                        e = null;
                    }
                }
                if (Velocity.Y < 0)
                {
                    Velocity.Y = (Velocity.Y * 0.9f);
                }
                else { Velocity.Y = 0; }
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects effect = SpriteEffects.None;
            if (Direction == Direction2D.LEFT) { effect = SpriteEffects.FlipHorizontally; }

            spriteBatch.Begin();

            spriteBatch.Draw(Textures[TextureIndex], Location, null, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);

            spriteBatch.End();
        }
    }
}
