using Sandbox_Game_Client.Resources._Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Inventory
{
    public class Inventory
    {
        private InventoryItem[] Items;
        public Inventory()
        {
            Items = new InventoryItem[18];
        }
        public bool Add(ItemDrop add)
        {
            InventoryItem item = add.GetInventoryItem();

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].Equals(item)) // Inventory Items are compared by name, desc, and textures
                {
                    Items[i].Amount += add.Amount;
                    item = null;
                    return true;
                }
            }
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    return true;
                }
            }


            return false;
        }
        public bool Remove(Item remove)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                InventoryItem item = Items[i];
                if (item.Equals(remove))
                {
                    Items[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}
