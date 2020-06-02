using System.Collections;
using Gameplay.Helpers;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

public class EnemyShipController : ShipController
{
    [SerializeField] private Vector2 _fireDelay;
    [SerializeField] private SpriteRenderer _hull;

    private bool _fire = true;
    
    protected override void ProcessMove(MovementSystem movementSystem)
    {
        //movementSystem.LateralMovement(Time.deltaTime);
        //movementSystem.LongitudinalMovement(Time.deltaTime);
        movementSystem.RandomMovement(Time.deltaTime);
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire) return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }

    protected override void ProcessCheckBorders(UnitBattleIdentity identity)
    {
        if (identity != UnitBattleIdentity.Enemy) return;

        if (GameAreaHelper.CheckPlayArea(transform, _hull.bounds))
        {
            _spaceShip.HealthSystem.Die();
        }
    }

    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }
}
