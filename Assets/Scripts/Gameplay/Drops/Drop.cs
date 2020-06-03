using Assets.Scripts.Gameplay.Drops.DropsControllers;
using Assets.Scripts.Gameplay.Spawners;
using Assets.Scripts.Gameplay.UI;
using Gameplay.ShipSystems;
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
        [SerializeField] private ResourcesAddedAnim _hpAnim;

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

        protected virtual void InstTxtAnim(float res)
        {
            var addedText = Instantiate(_hpAnim, GameObject.Find("UICanvas").transform);
            addedText.transform.position = transform.position;
            addedText.SetText(res);
            addedText.SetColor(this);
        }

        public void DestroyDropAfter(float time = 0) => Invoke(nameof(DestroyDrop), time);

        protected virtual void DestroyDrop()
        {
            Destroy(gameObject);
            SpawnedEntities.RemoveDrop(this);
        }
    }
}
