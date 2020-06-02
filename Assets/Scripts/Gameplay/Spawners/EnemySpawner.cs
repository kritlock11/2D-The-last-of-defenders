using System.Collections;
using Assets.Scripts.Gameplay.Spawners;
using Gameplay.Spaceships;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _object;
        [SerializeField] private Transform _parent;
        [SerializeField] private Vector2 _spawnPeriodRange;
        [SerializeField] private Vector2 _spawnDelayRange;

        private void Start() => StartSpawn();
        public void StartSpawn() => StartCoroutine(Spawn());
        public void StopSpawn() => StopAllCoroutines();

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));

            while (true)
            {
                var go = Instantiate(_object[Random.Range(0, 4)], transform.position, transform.rotation, _parent);
                SpawnedEntities.AddShip(go.GetComponent<ISpaceship>());
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
