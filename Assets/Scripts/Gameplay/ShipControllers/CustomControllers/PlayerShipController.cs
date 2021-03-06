﻿using Gameplay.Helpers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        protected override void ProcessMove(MovementSystem movementSystem)
        {
            var delta = Input.GetAxis("Horizontal");
            Time.timeScale = delta == 0 ?
                0.3f :
                Mathf.Lerp(Time.timeScale, 1, 0.5f);

            movementSystem.LateralMovement(delta * Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (!Input.GetKey(KeyCode.Space)) return;
            fireSystem.TriggerFire();
        }

        protected override void ProcessCheckBorders(UnitBattleIdentity identity)
        {
            if (identity != UnitBattleIdentity.Player) return;

            if (GameAreaHelper.CheckBorders(transform) < 0)
            {
                transform.position = new Vector2(GameAreaHelper.LeftBound, transform.position.y);
            }
            if (GameAreaHelper.CheckBorders(transform) > 0)
            {
                transform.position = new Vector2(GameAreaHelper.RightBound, transform.position.y);
            }
        }
    }
}
