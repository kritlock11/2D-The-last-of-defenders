using Gameplay.ShipSystems;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Drops.DropsControllers
{
    public abstract class DropController : MonoBehaviour
    {
        protected IDrop _drop;
        public void Init(IDrop drop) => _drop = drop;
        protected virtual void Update() => Move(_drop.MovementSystem);
        protected abstract void Move(MovementSystem movementSystem);
    }
}