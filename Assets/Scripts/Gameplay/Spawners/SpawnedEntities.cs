using System;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Drops;
using Gameplay.Spaceships;
using Gameplay.Weapons;


namespace Assets.Scripts.Gameplay.Spawners
{
    public static class SpawnedEntities
    {
        public static event Action<ISpaceship> OnKill;

        public static List<IDrop> Drops = new List<IDrop>();
        public static List<ISpaceship> ShipList = new List<ISpaceship>();
        public static List<ISpaceship> KilledShipList = new List<ISpaceship>();

        public static void AddDrop(IDrop drop) => Drops.Add(drop);
        public static void RemoveDrop(IDrop drop) => Drops.Remove(drop);
        public static void AddShip(ISpaceship ship) => ShipList.Add(ship);
        
        public static void RemoveShip(ISpaceship ship)
        {
            ShipList.Remove(ship);

            if (ship.BattleIdentity != UnitBattleIdentity.Enemy) return;
            if (ship.HealthSystem.CurHealth > 0) return;

            KilledShipList.Add(ship);
            OnKill?.Invoke(ship);
        }
    }
}
