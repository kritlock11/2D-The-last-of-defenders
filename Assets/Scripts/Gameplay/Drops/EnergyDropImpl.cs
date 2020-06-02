using Gameplay.Spaceships;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Drops
{
    public class EnergyDropImpl : Drop, IEnergyGiver
    {
        [SerializeField] private float _energy;
        public float Energy => _energy;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var obj = other.gameObject.GetComponent<IEnergeble>();

            if (obj == null) return;
            obj.ApplyEnergy(this);
            DestroyDrop();
        }
    }
}