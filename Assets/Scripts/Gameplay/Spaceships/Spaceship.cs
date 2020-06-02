using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable, IHealeble, IEnergeble
    {
        [SerializeField] private ShipController _shipController;
        [SerializeField] private MovementSystem _movementSystem;
        [SerializeField] private WeaponSystem _weaponSystem;
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private DropSystem _dropSystem;
        [SerializeField] private UnitBattleIdentity _battleIdentity;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public HealthSystem HealthSystem => _healthSystem;
        public DropSystem DropSystem => _dropSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public GameObject GetGo() => gameObject;

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
            _healthSystem.Init();
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            _healthSystem.CurHealth -= damageDealer.Damage;
        }

        public void ApplyHeal(IHealGiver healDealer)
        {
            _healthSystem.CurHealth += healDealer.Heal;
        }

        public void ApplyEnergy(IEnergyGiver energyGiver)
        {
            _healthSystem.CurEnergy += energyGiver.Energy;
        }
    }
}
