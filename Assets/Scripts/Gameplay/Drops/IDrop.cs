using Gameplay.ShipSystems;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Drops
{
    public interface IDrop
    {
        MovementSystem MovementSystem { get; }
        DropType Type { get; }
        GameObject GetGo();
    }
}