using Gameplay.Spaceships;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Drops
{
    public class HealDropImpl : Drop, IHealGiver
    {
        [SerializeField] private float _heal;

        public float Heal => _heal;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var obj = other.gameObject.GetComponent<IHealeble>();

            if (obj == null) return;
            obj.ApplyHeal(this);
            InstTxtAnim(_heal);
            DestroyDrop();
        }
    }
}