namespace GameAssets.scripts
{
    public class PowerModel
    {
        public PowerModel(string id, string powerName, int damageCapacity, PowerTypeEnum powerType, int staminaCost,
            int maxObjects)
        {
            ID = id;
            PowerName = powerName;
            DamageCapacity = damageCapacity;
            PowerType = powerType;
            StaminaCost = staminaCost;
            MaxObjects = maxObjects;
        }

        public string ID { get; }
        public string PowerName { get; }
        public int DamageCapacity { get; }
        public PowerTypeEnum PowerType { get; }
        public int StaminaCost { get; }
        public int MaxObjects { get; }
    }
}