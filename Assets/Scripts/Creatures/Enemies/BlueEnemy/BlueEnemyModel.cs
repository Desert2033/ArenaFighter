namespace Enemies.BlueEnemy
{
    public class BlueEnemyModel
    {

        public float BaseHp { get; set; }

        public float CurrentHp { get; set; }

        public float Speed { get; set; }

        public BlueEnemyModel()
        {
            BaseHp = 100;

            CurrentHp = BaseHp;

            Speed = 1f;
        }
    }
}
