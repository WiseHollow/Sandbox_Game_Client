using LibNoise;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._Entity;
using Sandbox_Game_Client.Resources._Shape;
using System;
using System.Collections.Generic;

namespace Sandbox_Game_Client.Resources._World
{
    public class World
    {
        private static Player player = null;
        public static Player Player
        {
            get
            {
                if (player == null)
                {
                    World w = new World("Overworld", 201);
                    w.Initialize();
                    
                    player = new Player(w, Textures.PLAYER, new Vector2(100, 100), 100, 3, "WiseHollow"); // TODO: Give default name

                    w.LivingEntities.Add(player);
                }

                return player;
            }
            set
            {
                player = value;
            }
        }
        public string Name { get; set; }
        private int seed = 0;
        public int Seed // Only can be changed from 0 once..
        {
            get
            {
                return seed;
            }
            set
            {
                if (seed == 0)
                {
                    seed = value;
                }
            }
        }
        public FastNoise FastNoise { get; set; }
        public List<Entity> Entities;
        public List<LivingEntity> LivingEntities;
        public Vector2 CloudLocation = new Vector2(800, 0);

        private CRectangle rect;

        public World(string Name, int Seed)
        {
            this.Name = Name;
            this.Seed = Seed;
            this.FastNoise = new FastNoise(Seed);
            Entities = new List<Entity>();
            LivingEntities = new List<LivingEntity>();
            rect = new CRectangle(new Vector2(100, 200), 100, 200, Color.Green);
        }
        public void Initialize()
        {
            //rect.PointD = new Vector2(rect.PointD.X, rect.PointD.Y + 180);
            rect.PointA = new Vector2(rect.PointA.X, rect.PointA.Y + 180);
        }
        public void SpawnEntity(EntityType type)
        {
            switch (type)
            {
                case EntityType.NEUTRAL:
                    //TODO: Finish
                    break;
                case EntityType.ENEMY:
                    //TODO: Finish
                    break;
            }
        }
        public void Update()
        {
            foreach(Entity e in Entities)
            {
                e.Update();
            }
            foreach(LivingEntity e in LivingEntities)
            {
                e.Update();
            }

            CloudLocation.X -= 0.45f;
            //CloudLocation.Y -= 0.25f;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            //
            // Draw background clouds.
            //

            spritebatch.Begin();
            spritebatch.Draw(Textures.CLOUDS[0], CloudLocation, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spritebatch.End();
            rect.Draw(spritebatch);
            //
            // Draw all entities in memory
            //

            foreach (Entity e in Entities)
            {
                e.Draw(spritebatch);
            }
            foreach (LivingEntity e in LivingEntities)
            {
                e.Draw(spritebatch);
            }
        }
    }
}
