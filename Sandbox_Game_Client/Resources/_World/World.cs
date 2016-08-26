using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._Entity;
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
                    World w = new World("Overworld");
                    w.Initialize();
                    
                    player = new Player(w, Textures.PLAYER, new Vector2(1, 200), 100, 3, "WiseHollow"); // TODO: Give default name

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
        public List<Entity> Entities;
        public List<LivingEntity> LivingEntities;

        public Vector2 CloudLocation = new Vector2(800, 0);
        public World(string Name)
        {
            this.Name = Name;
            Entities = new List<Entity>();
            LivingEntities = new List<LivingEntity>();
        }
        public void Initialize()
        {
            int w = 800 / 16;
            int h = 480 / 16;

            for(int x = 0; x < w; x++)
            {
                for (int y = 23; y < h; y++)
                {
                    if (y == 23)
                    {
                        Entities.Add(new Entity(this, Textures.GRASS, new Vector2(x * 16, y * 16)));
                    }
                    else
                    {
                        Entities.Add(new Entity(this, Textures.DIRT, new Vector2(x * 16, y * 16)));
                    }
                }
            }

            Entities.Add(new Entity(this, Textures.STONE, new Vector2(200, 352)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(200, 336)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(200, 320)));

            Entities.Add(new Entity(this, Textures.STONE, new Vector2(216, 352)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(216, 336)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(216, 320)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(216, 304)));

            Entities.Add(new Entity(this, Textures.STONE, new Vector2(232, 352)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(232, 336)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(232, 320)));
            Entities.Add(new Entity(this, Textures.STONE, new Vector2(232, 304)));
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
