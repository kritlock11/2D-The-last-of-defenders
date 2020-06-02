using UnityEngine;
using Assets.Scripts.Gameplay.Spawners;
using Gameplay.ShipControllers;
using Gameplay.Spaceships;

namespace Gameplay.ShipSystems
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _maxEnergy;
        [SerializeField] private float _curHealth;
        [SerializeField] private float _curEnergy;

        private GameObject EffectPrefab;

        private ShipController _shipController;

        public float CurHealth
        {
            get => _curHealth;
            set
            {
                _curHealth = Mathf.Clamp(value, 0, _maxHealth);
                _shipController.OnChangeHealth(this);
            }
        }

        public float CurEnergy
        {
            get => _curEnergy;
            set
            {
                _curEnergy = Mathf.Clamp(value, 0, _maxEnergy);
                _shipController.OnChangeEnergy(this);
            }
        }



        public void Init()
        {
            EffectPrefab = Resources.Load<GameObject>("Effects/DeathEffect");

            _shipController = GetComponent<ShipController>();
            CurHealth = _maxHealth;
            CurEnergy = 0;
        }

        public void Die()
        {
            Instantiate(EffectPrefab, transform.position, Quaternion.identity);

            GetComponent<WeaponSystem>().DestroyProjectilePool(2);
            SpawnedEntities.RemoveShip(GetComponent<ISpaceship>());
            Destroy(gameObject);
        }
    }
}
