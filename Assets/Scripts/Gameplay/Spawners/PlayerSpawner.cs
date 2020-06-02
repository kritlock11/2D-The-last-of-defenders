using Assets.Scripts.Gameplay.Spawners;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Spawners
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerParent;

        private void OnEnable() => PlayerSpawn();
        private void PlayerSpawn()
        {
            var go = Instantiate(_playerPrefab, _playerParent);
            SpawnedEntities.AddShip(go.GetComponent<ISpaceship>());
        }
    }
}
