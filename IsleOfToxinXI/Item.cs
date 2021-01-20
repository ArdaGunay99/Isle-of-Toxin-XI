namespace IsleOfToxinXI
{
    public class Item : IPrint
    {
        private string _itemName;
        private double _itemDamage;
        private double _itemDurability;
        private bool _isEnabled;

        public Item(string itemName, double itemDamage, double itemDurability)
        {
            this._itemName = itemName;
            this._itemDamage = itemDamage;
            this._itemDurability = itemDurability;
            _isEnabled = true;
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => _isEnabled = value;
        }

        public string ItemName
        {
            get => _itemName;
            set => _itemName = value;
        }

        public double ItemDamage
        {
            get => _itemDamage;
            set => _itemDamage = value;
        }

        public double ItemDurability
        {
            get => _itemDurability;
            set => _itemDurability = value;
        }

        public string printInfo()
        {
            return "Item name: " + _itemName + "\n" +
                   "Item damage: " + _itemDamage + "\n" +
                   "Item durability: " + _itemDurability;
        }
    }
}