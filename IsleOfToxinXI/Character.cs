using System.Windows.Forms;

namespace IsleOfToxinXI
{
    public class Character : IPrint
    {
        private int infoGathered = 0;
        private int sampleCollected = 0;
        private double health = 100;
        private Inventory charInventory;
        private double charDamage = 10;
        private Form1 _form1 = (Form1) Application.OpenForms["Form1"];
        
        public Character(){
            charInventory = new Inventory();
        }

        public double getCharDamage() {
            return charDamage;
        }

        public void setCharDamage(double charDamage) {
            this.charDamage = charDamage;
        }

        public void setCharInventory(Inventory charInventory) {
            this.charInventory = charInventory;
        }


        public double getHealth() {
            return health;
        }
        public void setHealth(double health) {
            this.health = health;
        }
        public int getSampleCollected() {
            return sampleCollected;
        }
        public void setSampleCollected(int sampleCollected) {
            this.sampleCollected = sampleCollected;
        }
        public int getInfoGathered() {
            return infoGathered;
        }
        public void setInfoGathered(int infoGathered) {
            this.infoGathered = infoGathered;
        }
        
        public Inventory getCharInventory(){
            return charInventory;
        }
        public string addToCharInventory(Item item){
            charInventory.addItem(item);
            setCharDamage(getCharDamage()+item.ItemDamage);
            return">"+item.ItemName+" added to inventory.";
        }
        public string removeFromCharInventory(Item item){
            charInventory.dropItem(item);
            setCharDamage(getCharDamage()-item.ItemDamage);
            return">"+item.ItemName+" removed from inventory.";
        }
        public void Fight(Character player,Creature newCreature){
            
            while(true)
            {
                _form1.AddLine(">you took " + (newCreature.CalculateTotalDamage() / 2) + " damage");
                player.setHealth(player.getHealth() - (newCreature.CalculateTotalDamage() / 2));
                _form1.SetHealthBar((int)player.getHealth());
                
                _form1.AddLine(">You dealt " + player.getCharDamage() + " damage");
                newCreature.SetCreatureHealth(newCreature.GetCreatureDamage() - player.getCharDamage());
                
                if(player.getHealth() <=0){
                    _form1.AddLine(">You are dead. Your scores:");
                    _form1.AddLine(player.printInfo());
                    _form1.AddLine("Restarting from the Start Point...");
                    Map newMap = new Map();
                    Character player1 = new Character();
                    _form1.AddLine(">Character info: ");
                    _form1.AddLine(player1.printInfo());


                    _form1.AddLine("You Jump out of your Plane Just Above the Toxic Island.");

                    //newMap.StartPoint(player1);
                    break;
                }
                if (newCreature.GetCreatureHealth() <= 0) {
                    _form1.AddLine(">You have killed "+ newCreature.GetCreatureName());
                    _form1.AddLine(">You have received "+newCreature.GetCreatureInformationAmount()+" informations and "+newCreature.GetCreatureSampleAmount()+" samples");
                    player.setInfoGathered(player.getInfoGathered()+(newCreature.GetCreatureInformationAmount()));
                    player.setSampleCollected(player.getSampleCollected()+(newCreature.GetCreatureSampleAmount()));
                   
                    foreach (var item in getCharInventory().GetInventory())
                    {
                        item.ItemDurability -= 1;
                        if (item.ItemDurability <= 0)
                        {
                            item.IsEnabled = false;
                            _form1.AddLine(">"+item.ItemName+" has been broken and removed from inventory.");
                            player.setCharDamage(player.getCharDamage()-item.ItemDamage);
                        }
                    }
                    _form1.AddLine(">Character info after fight: ");
                    player.printInfo();
                    break;

                }

            }

        }

        public void Escape(Character player, Creature newCreature)
        {
            _form1.AddLine(">by escaping the fight you took " + newCreature.CalculateTotalDamage() + " damage");
            _form1.SetHealthBar((int)player.getHealth());
            if(player.getHealth() <=0){
                _form1.AddLine(">You are dead. Your scores:");
                _form1.AddLine(player.printInfo());
                _form1. AddLine(">Restarting from the Start Point...");
                Map newMap = new Map();
                Character player1 = new Character();
                _form1.AddLine(">Character info: ");
                _form1.AddLine(player1.printInfo());


                _form1.AddLine(">You Jump out of your Plane Just Above the Toxic Island.");

                //newMap.StartPoint(player1);
                return;
            }
            
            _form1.AddLine(">You have received "+(newCreature.GetCreatureInformationAmount()/2)+" informations and "+(newCreature.GetCreatureSampleAmount()/2)+" samples");
            player.setInfoGathered(player.getInfoGathered()+(newCreature.GetCreatureInformationAmount()/2));
            player.setSampleCollected(player.getSampleCollected()+(newCreature.GetCreatureSampleAmount()/2));
            foreach (var item in getCharInventory().GetInventory())
            {
                item.ItemDurability -= 1;
                if (item.ItemDurability <= 0)
                {
                    item.IsEnabled = false;
                    _form1.AddLine(">"+item.ItemName+" has been broken and removed from inventory.");
                    player.setCharDamage(player.getCharDamage()-item.ItemDamage);
                }
            }
            _form1.AddLine(">Character info after escape: ");
            player.printInfo();
        }
       
        public string printInfo()
        {
          return ">Character health: " + health + "\r\n" +
                 ">Character damage: " + charDamage + "\r\n" +
                 ">information amount: " + infoGathered + "\r\n" +
                 ">sample amount: " + sampleCollected;
        }
        
    }
}