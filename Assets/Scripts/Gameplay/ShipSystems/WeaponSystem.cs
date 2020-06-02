using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }
        
        public void ChangeCooldowns(float mult)
        {
            _weapons.ForEach(w => w.ChangeCooldowns(mult));
        }

        public void DestroyProjectilePool(float sec = default)
        {
            _weapons.ForEach(w => w.DestroyProjectilePool(sec));
        }

        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }
    }
}
