using System.Collections.Generic;
using Assets.Scripts.Gameplay.Spawners;
using Assets.Scripts.Gameplay.UI;
using Gameplay.Spawners;
using UnityEngine;

namespace Assets.Scripts.Gameplay.GameControl
{
    public class GameControl : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _ePref;
        [SerializeField] private PlayerSpawner _pPref;
        [SerializeField] private Transform _spawnParent;

        private int _spawnsAmount = 3;
        private readonly List<EnemySpawner> _enemySpawns = new List<EnemySpawner>();
        private readonly List<PlayerSpawner> _playerSpawns = new List<PlayerSpawner>();

        private readonly Vector3[] _sPoints = new Vector3[4]
        {
            new Vector3(-6, 20, 0),
            new Vector3(0, 20, 0),
            new Vector3(6, 20, 0),
            new Vector3(0, -17, 0)
        };

        public void StartGame()
        {
            InstantiateEnemySpawns();
            InstantiatePlayerSpawns();
        }

        public void EndGame()
        {
            _enemySpawns.ForEach(x => x.StopSpawn());
            _enemySpawns.Clear();

            SpawnedEntities.ShipList.ForEach(x => x.WeaponSystem.DestroyProjectilePool());
            SpawnedEntities.ShipList.ForEach(x => Destroy(x.GetGo()));
            SpawnedEntities.Drops.ForEach(x => Destroy(x.GetGo()));

            SpawnedEntities.ShipList.Clear();
            SpawnedEntities.Drops.Clear();

            UILocator.Restart.SetActive(true);
        }

        private void InstantiatePlayerSpawns()
        {
            var player = Instantiate(_pPref, _spawnParent);
            player.transform.position = _sPoints[3];
            _playerSpawns.Add(player);
        }

        private void InstantiateEnemySpawns()
        {
            for (var i = 0; i < _spawnsAmount; i++)
            {
                var enemy = Instantiate(_ePref, _spawnParent);
                enemy.transform.position = _sPoints[i];
                _enemySpawns.Add(enemy);
            }
        }
    }
}
