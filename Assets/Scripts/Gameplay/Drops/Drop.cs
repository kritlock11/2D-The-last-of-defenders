using Assets.Scripts.Gameplay.Drops.DropsControllers;
using Assets.Scripts.Gameplay.Spawners;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Drops
{
    public abstract class Drop : MonoBehaviour, IDrop
    {
        [SerializeField] private  float _lifeTime;
        [SerializeField] private DropType _type;
        [SerializeField] private DropController _dropController;
        [SerializeField] private MovementSystem _movementSystem;
        public UnitBattleIdentity BattleIdentity { get; }
        public MovementSystem MovementSystem => _movementSystem;
        public DropType Type => _type;

        protected virtual void Start()
        {
            _dropController.Init(this);
            SpawnedEntities.AddDrop(this);
            DestroyDropAfter(_lifeTime);
        }

        public GameObject GetGo() => gameObject;
        public void DestroyDropAfter(float time = 0) => Invoke(nameof(DestroyDrop), time);

        protected virtual void DestroyDrop()
        {
            Destroy(gameObject);
            SpawnedEntities.RemoveDrop(this);
        }
    }
}
