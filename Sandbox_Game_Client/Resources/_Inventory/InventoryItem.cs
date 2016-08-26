using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Inventory
{
    public class InventoryItem : Item
    {
        public int Amount { get; set; }
        public InventoryItem(string Name, string Description, int Amount) : base(Name, Description)
        {
            this.Amount = Amount;
        }
        public override bool Equals(object obj)
        {
            if (obj is InventoryItem)
            {
                InventoryItem item = (InventoryItem)obj;
                if (Name == item.Name && Description == item.Description && Textures == item.Textures) { return true; }
            }

            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
