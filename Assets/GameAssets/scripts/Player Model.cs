namespace GameAssets.scripts
{
    public class PlayerModel
    {
        public PlayerModel(string name, PlayerTypeEnum playerType)
        {
            Name = name;
            Health = 100;
            Stamina = 100;
            PlayerType = playerType;
        }

        public string Name { get; }
        public int Health { get; set; }
        public int Stamina { get; set; }
        public PlayerTypeEnum PlayerType { get; }
        public PowerModel ThrowPower { get; set; }
        public PowerModel CombatPower { get; set; }
    }
}