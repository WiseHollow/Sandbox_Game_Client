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
    public class Entity
    {
        public Vector2 Location;
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

        public Entity(World World, Texture2D[] Textures, Vector2 Location)
        {
            this.World = World;
            this.Location = Location;
            this.Direction = Direction2D.RIGHT;
            this.Textures = Textures;

            Solid = true;
        }
        public Entity(World World, Texture2D Texture, Vector2 Location)
        {
            this.World = World;
            this.Location = Location;
            this.Direction = Direction2D.RIGHT;
            this.Textures = new Texture2D[1] { Texture };

            Solid = true;
        }
        public bool Collides(Entity e)
        {
            if (Location.X < e.Location.X + e.Textures[TextureIndex].Width &&
                Location.X + Textures[TextureIndex].Width > e.Location.X &&
                Location.Y < e.Location.Y + e.Textures[TextureIndex].Height &&
                Textures[TextureIndex].Height + Location.Y > e.Location.Y)
            {
                return true;
            }

            return false;
        }
        public bool Collides(Entity e, Vector2 Position)
        {
            if (Position.X < e.Location.X + e.Textures[TextureIndex].Width &&
                Position.X + Textures[TextureIndex].Width > e.Location.X &&
                Position.Y < e.Location.Y + e.Textures[TextureIndex].Height &&
                Textures[TextureIndex].Height + Position.Y > e.Location.Y)
            {
                return true;
            }

            return false;
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
                //if (Velocity.X <= 1 && Velocity.X >= -1) // If we have -1 or 1 pos to move
                //{
                //    Location.X += Velocity.X; // Let's move

                //    if (CheckSolidCollision() != null) { Location.X -= Velocity.X; } // If we collide with solid object, move back to original position.

                //    Velocity.X = 0; // Success, reset velocity to 0
                //}
                //else
                //{
                //    int offset = (int)(Velocity.X - (Math.Pow(Velocity.X, 0) * (Math.Abs(Velocity.X) - 1))); // Let's get which direction we are moving, -1 or 1

                //    Location.X += offset; // Apply it to current position.

                //    if (CheckSolidCollision() != null) { Location.X -= offset; } // Move back if we collide with solid object.

                //    Velocity.X -= offset; // Subtract the offset from velocity.
                //}

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
                //if (Velocity.Y <= 1 && Velocity.Y >= -1)
                //{
                //    Location.Y += Velocity.Y;

                //    if (CheckSolidCollision() != null) { Location.Y -= Velocity.Y; }

                //    Velocity.Y = 0;
                //}
                //else
                //{
                //    int offset = (int)(Velocity.Y - (Math.Pow(Velocity.Y, 0) * (Math.Abs(Velocity.Y) -1)));

                //    Location.Y += offset;

                //    if (CheckSolidCollision() != null) { Location.Y -= offset; }

                //    Velocity.Y -= offset;
                //}
                Location.Y += Velocity.Y;
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
