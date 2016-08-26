using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._Inventory;
using Sandbox_Game_Client.Resources._World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class ItemDrop : Entity
    {
        public Item Item { get; set; }
        public int Amount { get; set; }
        public ItemDrop(World world, Texture2D[] Textures, Vector2 Location, Item Item, int Amount) : base(world, Textures, Location)
        {
            this.Item = Item;
            this.Amount = Amount;
        }
        public ItemDrop(World world, Texture2D Texture, Vector2 Location, Item Item, int Amount) : base(world, new Texture2D[1] { Texture }, Location)
        {
            this.Item = Item;
            this.Amount = Amount;
        }
        public InventoryItem GetInventoryItem()
        {
            InventoryItem item = new InventoryItem(Item.Name, Item.Description, Amount);
            return item;
        }
        public override void Update()
        {
            LivingEntity e = CheckLivingEntityCollision();
            if (e != null)
            {
                Player player = e as Player;
                if (player != null)
                {
                    player.Inventory.Add(this);
                    Remove();
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
