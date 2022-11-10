using UnityEngine;
using System.Collections.Generic;
using Creators;

namespace Spawner
{
    public class SpawnerController
    {
        private SpawnerModel _model;

        private GameObject _player;

        private List<Transform> _enemyPositions;

        private Pool _poolBlueEnemies;

        private Pool _poolRedEnemies;

        private float _timer = 0;

        public SpawnerController(SpawnerModel model, List<Transform> enemyPositions, GameObject player)
        {
            _model = model;

            _enemyPositions = enemyPositions;

            _player = player;
        }

        private void CreatePools()
        {
            CreatorBlueEnemy creatorBlueEnemy = new CreatorBlueEnemy(_player.transform);

            CreatorRedEnemy creatorRedEnemy = new CreatorRedEnemy(_player.transform);

            _poolBlueEnemies = new Pool(creatorBlueEnemy, 1);

            _poolRedEnemies = new Pool(creatorRedEnemy, 4);

            EnemyPools.ListPools.Add(_poolBlueEnemies);
            EnemyPools.ListPools.Add(_poolRedEnemies);
        }

        private void SpawnFromPool(Pool pool, int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject enemy = pool.GetFreeItem();

                enemy.SetActive(true);

                SetPositionEnemies(enemy.transform);
            }
        }

        private void SpawnAll()
        {
            SpawnFromPool(_poolBlueEnemies, 1);
            SpawnFromPool(_poolRedEnemies, 4);
        }

        private void SetPositionEnemies(Transform enemy)
        {
            int lastIndex = _enemyPositions.Count - 1;

            Vector3 newPosition = _enemyPositions[Random.Range(0, lastIndex)].position;

            enemy.position = newPosition;
        }

        public void Init()
        {
            CreatePools();

            SpawnAll();
        }

        public void CUpdate()
        {
            _timer += Time.deltaTime;

            if (_timer >= _model.CurrentTime)
            {
                _timer = 0f;
                _model.ReduceTime(1f);
                SpawnAll();
            }
        }
    }
}

