using Gameplay.Weapons;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

public class Rocket : Projectile
{
    [SerializeField] private float _rocketSpeed;
    [SerializeField] private float _rocketMinSpeed;
    [SerializeField] private float _rocketMaxSpeed;
    [SerializeField] private float _acceleration;

    private Vector3 _vector = Vector3.down;
    private bool _detected;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var obj = other.gameObject.GetComponent<IDamagable>();

        if (obj == null || obj.BattleIdentity == BattleIdentity) return;
        Return2Pool();
        obj.ApplyDamage(this);
    }

    private void OnDisable()
    {
        _rocketSpeed = _rocketMinSpeed;
        _detected = false;
    }

    protected override void Move(float speed)
    {
        var dt = Time.deltaTime;
        if (_rocketSpeed < _rocketMaxSpeed)
        {
            _rocketSpeed += _acceleration * dt;
        }

        FindTarget();
        transform.Translate(-_rocketSpeed * dt * _vector);
    }

    private void FindTarget()
    {
        if (_detected) return;
        var tar = GameObject.FindGameObjectWithTag("Player");
        if (!tar) return;
        _detected = true;
        _vector = (tar.transform.position - transform.position).normalized;
    }

    //private void Explosion()
    //{
    //    var cols = Physics2D.OverlapCircleAll(transform.position, _radius);
    //    if (cols.Length == 0) return;

    //    foreach (var col in cols)
    //    {
    //        var target = col.gameObject.GetComponent<IDamagable>();
    //        if (target == null || target.BattleIdentity == BattleIdentity) return;
    //        target.ApplyDamage(this);
    //    }
    //}

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, _radius);
    //}
}
