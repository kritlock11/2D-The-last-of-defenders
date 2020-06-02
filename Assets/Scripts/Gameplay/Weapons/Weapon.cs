using System.Collections;
using Assets.Scripts.Gameplay.Weapons.Projectiles;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Projectile _projectile;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _cooldown;
        [SerializeField] protected WeaponType _weaponType = WeaponType.None;

        protected UnitBattleIdentity _battleIdentity;
        protected bool _readyToFire = true;

        protected ProjectilePool _bulletsPool;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;

            switch (_weaponType)
            {
                case WeaponType.Laser:
                    _projectile = Resources.Load<Projectile>("ProjType/Laser");
                    break;
                case WeaponType.Rocket:
                    _projectile = Resources.Load<Projectile>("ProjType/Rocket");
                    break;
                case WeaponType.Plasma:
                    _projectile = Resources.Load<Projectile>("ProjType/Plasma");
                    break;
            }

            _bulletsPool = new ProjectilePool(_projectile, 10);
        }

        public virtual void TriggerFire() { }

        public void ChangeCooldowns(float mult) => _cooldown *= mult;

        public void DestroyProjectilePool(float sec = default)
        {
            _bulletsPool.Projectiles.ForEach(x => x.DestroyProjectile(sec));
            _bulletsPool.Projectiles.Clear();
        }

        protected IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }
    }
}
