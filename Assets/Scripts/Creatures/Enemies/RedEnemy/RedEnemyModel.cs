namespace Enemies.RedEnemy
{
    public class RedEnemyModel
    {

        public float BaseHp { get; private set; }

        public float CurrentHp { get; private set; }

        public float Speed { get; private set; }

        public float Damage { get; private set; }

        public RedEnemyModel()
        {
            BaseHp = 100;

            CurrentHp = BaseHp;

            Speed = 2f;

            Damage = 15f;
        }
    }
}
