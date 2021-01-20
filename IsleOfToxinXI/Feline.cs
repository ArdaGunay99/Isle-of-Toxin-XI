namespace IsleOfToxinXI
{
    public class Feline : Creature
    {
        private int numberOfClaw;

        public int getNumberOfClaw() {
            return numberOfClaw;
        }

        public void setNumberOfClaw(int numberOfClaw) {
            this.numberOfClaw = numberOfClaw;
        }

        
        // public Feline(String creatureName, boolean creatureMood, double creatureHealth, double creatureDamage,
        //     int creatureInformationAmount, int creatureSampleAmount,int numberOfClaw) {
        //     super(creatureName, creatureMood, creatureHealth, creatureDamage, creatureInformationAmount, creatureSampleAmount);
        //     this.numberOfClaw = numberOfClaw;
        // }

        
        public override double CalculateTotalDamage() {
            double totalDamage = GetCreatureDamage()*numberOfClaw;
            return totalDamage;
        }

        public Feline(string creatureName, bool isHostile, double creatureHealth, double creatureDamage, int creatureInformationAmount, int creatureSampleAmount, int numberOfClaw) : base(creatureName, isHostile, creatureHealth, creatureDamage, creatureInformationAmount, creatureSampleAmount)
        {
            this.numberOfClaw = numberOfClaw;
        }
    }
}