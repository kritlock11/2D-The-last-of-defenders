using Gameplay.Weapons;

namespace Gameplay.Spaceships
{
    public interface IEnergeble
    {
        UnitBattleIdentity BattleIdentity { get; }
        void ApplyEnergy(IEnergyGiver energyGiver);
    }
}