using System.Collections.Generic;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons.Projectiles
{
    public class ProjectilePool
    {
        private readonly int _poolSize;
        public List<Projectile> Projectiles;

        public ProjectilePool(Projectile baseBullet, int poolSize)
        {
            _poolSize = poolSize;
            Projectiles = new List<Projectile>();

            for (var i = 0; i < _poolSize; i++)
            {
                var bullet = Object.Instantiate(baseBullet);
                bullet.gameObject.SetActive(false);
                Projectiles.Add(bullet);
            }
        }
    }
}