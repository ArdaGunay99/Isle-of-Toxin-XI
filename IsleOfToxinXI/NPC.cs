namespace IsleOfToxinXI
{
    public class NPC
    {
        private string NPCName;
        private Inventory NPCInventory;
        public void addToNPCInventory(Item item) {
            NPCInventory.addItem(item);

        }
        public void removeFromNPCInventory(Item Item){
            NPCInventory.dropItem(Item);
        }
        public Inventory getNPCInventory() {
            return NPCInventory;
        }
        public string getNPCName() {
            return NPCName;
        }
        public void setNPCName(string nPCName) {
            NPCName = nPCName;
        }
        public NPC() {
            NPCInventory=new Inventory();
        }
        public NPC(string NPCName) {
            NPCInventory = new Inventory();
            this.NPCName = NPCName;
        }
        public void trade(NPC NPC,Character player,Item Item){
            NPC.removeFromNPCInventory(Item);
            player.addToCharInventory(Item);

        }
    }
}