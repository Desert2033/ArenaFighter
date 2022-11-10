using UnityEngine;
using Player;
using System.Collections.Generic;
using Spawner;
using UnityEngine.SceneManagement;

namespace Root
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Transform _playerPointPosition;

        [SerializeField] private List<Transform> _enemyPositions;

        [SerializeField] private PlayerView _player;

        [SerializeField] private Canvas _playerPanel;

        [SerializeField] private Canvas _theEndPanel;

        private SpawnerController _spawnerController;

        private void Start()
        {
            PlayerModel playerModel = new PlayerModel();

            PlayerController playerController = new PlayerController(_player, playerModel);

            _player.transform.position = _playerPointPosition.position;

            playerController._OnDie += GameEnd;

            SpawnerModel spawnerModel = new SpawnerModel();

            _spawnerController = new SpawnerController(spawnerModel, _enemyPositions, _player.gameObject);

            _spawnerController.Init();
        }

        private void Update()
        {
            _spawnerController.CUpdate();
        }

        public void GameEnd()
        {
            _playerPanel.gameObject.SetActive(false);

            _theEndPanel.gameObject.SetActive(true);

            Time.timeScale = 0f;
        }

        public void ReloadGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
