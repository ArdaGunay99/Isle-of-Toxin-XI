namespace IsleOfToxinXI
{
    public abstract class Creature {
        private string _creatureName;
        private bool _isHostile;
        private double _creatureHealth;
        private double _creatureDamage;
        private int _creatureInformationAmount;
        private int _creatureSampleAmount;

        public bool GetIsHostile() {
            return _isHostile;
        }

        public double GetCreatureDamage() {
            return _creatureDamage;
        }

        public double GetCreatureHealth() {
            return _creatureHealth;
        }

        public int GetCreatureInformationAmount() {
            return _creatureInformationAmount;
        }

        public int GetCreatureSampleAmount() {
            return _creatureSampleAmount;
        }

        public string GetCreatureName() {
            return _creatureName;
        }

        public void SetCreatureDamage(double creatureDamage) {
            this._creatureDamage = creatureDamage;
        }

        public void SetCreatureHealth(double creatureHealth) {
            this._creatureHealth = creatureHealth;
        }

        public void SetIsHostile(bool isHostile) {
            this._isHostile = isHostile;
        }

        public void SetCreatureInformationAmount(int creatureInformationAmount) {
            this._creatureInformationAmount = creatureInformationAmount;
        }

        public void SetCreatureName(string creatureName) {
            this._creatureName = creatureName;
        }

        public void SetCreatureSampleAmount(int creatureSampleAmount) {
            this._creatureSampleAmount = creatureSampleAmount;
        }
        public Creature(string creatureName,bool isHostile,double creatureHealth,double creatureDamage,int creatureInformationAmount,int creatureSampleAmount){
            this._creatureName = creatureName;
            this._isHostile = isHostile;
            this._creatureHealth = creatureHealth;
            this._creatureDamage = creatureDamage;
            this._creatureInformationAmount = creatureInformationAmount;
            this._creatureSampleAmount = creatureSampleAmount;
        }

        public abstract double CalculateTotalDamage();

    }
}