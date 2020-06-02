using Assets.Scripts.Gameplay.Drops;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class DropSystem : MonoBehaviour
    {
        [SerializeField] private Drop[] _dropPrefabs;

        public IDrop DropBonus()
        {
            var rv = Random.value > 0.5f ? 1 : 0;
            Debug.Log($"{rv}");
            return Instantiate(_dropPrefabs[rv], gameObject.transform.position, Quaternion.identity);
        }
    }
}