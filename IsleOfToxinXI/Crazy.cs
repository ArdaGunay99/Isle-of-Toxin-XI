namespace IsleOfToxinXI
{
    public class Crazy : Creature
    {
        private int crazinessConstant;
        
        public Crazy(string creatureName, bool isHostile, double creatureHealth, double creatureDamage, int creatureInformationAmount, int creatureSampleAmount, int crazinessConstant) : base(creatureName, isHostile, creatureHealth, creatureDamage, creatureInformationAmount, creatureSampleAmount)
        {
            this.crazinessConstant = crazinessConstant;
        }

        public override double CalculateTotalDamage()
        {
            double totalDamage = GetCreatureDamage()*crazinessConstant;
            return totalDamage;
        }
    }
}