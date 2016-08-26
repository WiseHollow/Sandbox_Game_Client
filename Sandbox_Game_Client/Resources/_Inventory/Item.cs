using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._Entity;
using Sandbox_Game_Client.Resources._World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Inventory
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Texture2D[] Textures { get; set; }
        public Item(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
        public ItemDrop GetDrop(World World, Texture2D[] Textures, Vector2 Location)
        {
            ItemDrop drop = new ItemDrop(World, Textures, Location, this, 1);
            return drop;
        }
    }
}
