using System.Collections.Generic;

namespace IsleOfToxinXI
{
    public class Inventory : IPrint
    {
        private List<Item> inventory = new List<Item>();

        public List<Item> GetInventory()
        {
            return inventory;
        }
        public void addItem(Item item){
            inventory.Add(item);

        }

        public void dropItem(Item item){
            inventory.Remove(item);
        }
        
        public string craft(Item x,Item y,string craftResult){
            var result = new Item(craftResult,x.ItemDamage*y.ItemDamage,x.ItemDurability+y.ItemDurability);
            inventory.Remove(x);
            inventory.Remove(y);
            inventory.Add(result);
            return craftResult+" crafted added and to inventory:";
        }
        
        public string printInfo()
        {
            string info = "";
            for (int i = 0; i < inventory.Count; i++)
            {
              info = string.Concat(info,"\n"+inventory[i].printInfo());
            }

            return info;
        }
    }
}