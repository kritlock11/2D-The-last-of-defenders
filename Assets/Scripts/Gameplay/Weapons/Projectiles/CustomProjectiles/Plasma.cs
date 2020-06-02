using Gameplay.Weapons;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

public class Plasma : Projectile
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var obj = other.gameObject.GetComponent<IDamagable>();

        if (obj == null || obj.BattleIdentity == BattleIdentity) return;
        obj.ApplyDamage(this);
        Return2Pool();
    }

    protected override void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
