using System.Collections;
using Assets.Scripts.Gameplay.GameControl;
using Assets.Scripts.Gameplay.UI;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipControllers
{
    public abstract class ShipController : MonoBehaviour
    {
        protected ISpaceship _spaceShip;
        private GameControl _gameControl;

        public void Init(ISpaceship spaceship)
        {
            _spaceShip = spaceship;
            _gameControl = FindObjectOfType<GameControl>();
        }

        public void OnChangeHealth(HealthSystem healthSystem)
        {
            var health = healthSystem.CurHealth;

            if (health <= 0)
            {
                if (_spaceShip.BattleIdentity == UnitBattleIdentity.Enemy)
                {
                    _spaceShip.DropSystem.DropBonus();

                    _spaceShip.HealthSystem.Die();
                }

                if (_spaceShip.BattleIdentity == UnitBattleIdentity.Player)
                {
                    UILocator.Health.Text = health.ToString();
                    _gameControl.EndGame();
                }
            }
            else
            {
                if (_spaceShip.BattleIdentity == UnitBattleIdentity.Player)
                {
                    UILocator.Health.Text = health.ToString();
                }
            }
        }

        private bool _corStarts;
        public void OnChangeEnergy(HealthSystem healthSystem)
        {
            if (_spaceShip.BattleIdentity != UnitBattleIdentity.Player) return;
            var energy = healthSystem.CurEnergy;

            if (energy >= 20 && _corStarts == false)
            {
                _corStarts = true;
                _spaceShip.WeaponSystem.ChangeCooldowns(0.5f);
                StartCoroutine(nameof(EnergySpend));
            }
            UILocator.Energy.Text = energy <= 0 ? "0" : energy.ToString();
        }

        private IEnumerator EnergySpend()
        {
            while (_spaceShip.HealthSystem.CurEnergy > 0)
            {
                _spaceShip.HealthSystem.CurEnergy = (int)(_spaceShip.HealthSystem.CurEnergy - 1);
                UILocator.Energy.Text = _spaceShip.HealthSystem.CurEnergy.ToString();
                yield return new WaitForSeconds(0.3f);
            }

            _corStarts = false;
            _spaceShip.WeaponSystem.ChangeCooldowns(2f);

        }

        private void Update()
        {
            ProcessMove(_spaceShip.MovementSystem);
            ProcessFire(_spaceShip.WeaponSystem);
            ProcessCheckBorders(_spaceShip.BattleIdentity);
        }


        protected abstract void ProcessMove(MovementSystem movementSystem);
        protected abstract void ProcessFire(WeaponSystem fireSystem);
        protected abstract void ProcessCheckBorders(UnitBattleIdentity identity);
    }
}
