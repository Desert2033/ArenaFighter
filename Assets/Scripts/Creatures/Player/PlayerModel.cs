namespace Player
{
    public class PlayerModel
    {
        public float BaseHp { get; set; }

        public float CurrentHp { get; set; }

        public float BasePower { get; set; }

        public float CurrentPower { get; set; }

        public float Speed { get; set; }

        public PlayerModel()
        {
            BaseHp = 100;

            CurrentHp = BaseHp;

            BasePower = 100;

            CurrentPower = 50;

            Speed = 2f;
        }
    }
}