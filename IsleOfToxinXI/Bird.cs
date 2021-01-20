namespace IsleOfToxinXI
{
    public class Bird : Creature
    {
        private int beakForce;

        public int getBeakForce() {
            return beakForce;
        }

        public void setBeakForce(int beakForce) {
            this.beakForce = beakForce;
        }

        
        public override double CalculateTotalDamage() {
            double totalDamage = GetCreatureDamage()*getBeakForce();
            return totalDamage;
        }
        // public Bird(string creatureName, bool creatureMood, double creatureHealth, double creatureDamage,
        //     int creatureInformationAmount, int creatureSampleAmount,int beakForce){
        //     base(creatureName, creatureMood, creatureHealth, creatureDamage, creatureInformationAmount, creatureSampleAmount);
        //     this.beakForce = beakForce ;
        // }
        public Bird(string creatureName, bool isHostile, double creatureHealth, double creatureDamage, int creatureInformationAmount, int creatureSampleAmount, int beakForce) : base(creatureName, isHostile, creatureHealth, creatureDamage, creatureInformationAmount, creatureSampleAmount)
        {
            this.beakForce = beakForce ;
        }
    }
}