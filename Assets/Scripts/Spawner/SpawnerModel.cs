namespace Spawner
{
    public class SpawnerModel
    {
        public float MinTimeToSpawnSec { get; private set; }

        public float MaxTimeToSpawnSec { get; private set; }

        public float CurrentTime { get; private set; }

        public SpawnerModel()
        {
            MinTimeToSpawnSec = 2f;

            MaxTimeToSpawnSec = 5f;

            CurrentTime = MaxTimeToSpawnSec;
        }

        public void ReduceTime(float reduceTime)
        {
            if (CurrentTime >= MinTimeToSpawnSec)
            {
                CurrentTime -= reduceTime;
            }
        }

    }
}