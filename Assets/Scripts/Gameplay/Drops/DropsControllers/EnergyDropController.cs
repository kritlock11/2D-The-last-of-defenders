using Gameplay.ShipSystems;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Drops.DropsControllers
{
    public class EnergyDropController : DropController
    {
        protected override void Move(MovementSystem movementSystem)
        {
            movementSystem.LongitudinalMovement(-Time.deltaTime);
        }
    }
}