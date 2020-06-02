using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Gameplay.Weapons
{
    public class LaserWeapon : Weapon
    {
        protected void Awake() => _weaponType = WeaponType.Laser;

        public override void TriggerFire()
        {
            if (!_readyToFire) return;

            foreach (var t in _bulletsPool.Projectiles.Where(t => !t.gameObject.activeInHierarchy))
            {
                t.Init(_battleIdentity);
                t.Return2Pool(t.LifeTime);
                t.transform.position = _barrel.transform.position;
                t.transform.rotation = _barrel.transform.rotation;
                t.gameObject.SetActive(true);
                break;
            }
            StartCoroutine(Reload(_cooldown));
        }
    }
}
