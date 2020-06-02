using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private float _lifeTime;
        [SerializeField] private ProjType _type = ProjType.None;
        private UnitBattleIdentity _battleIdentity;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Damage => _damage;
        public float LifeTime => _lifeTime;

        public void Init(UnitBattleIdentity battleIdentity) => _battleIdentity = battleIdentity;
        protected virtual void Update() => Move(_speed);
        public void Return2Pool(float time = 0) => Invoke(nameof(SetActiveFalse), time);
        public void DestroyProjectile(float time = 0) => Invoke(nameof(Destroy), time);
        protected virtual void SetActiveFalse() => gameObject.SetActive(false);
        protected virtual void Destroy() => Destroy(gameObject);
        protected abstract void Move(float speed);
    }
}
