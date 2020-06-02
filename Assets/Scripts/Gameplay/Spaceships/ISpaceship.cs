using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public interface ISpaceship
    {
        MovementSystem MovementSystem { get; }
        WeaponSystem WeaponSystem { get; }
        HealthSystem HealthSystem { get; }
        DropSystem DropSystem { get; }
        UnitBattleIdentity BattleIdentity { get; }
        GameObject GetGo();
    }
}
