using Gameplay.Weapons;

namespace Gameplay.Spaceships
{
    public interface IEnergyGiver
    {
        UnitBattleIdentity BattleIdentity { get; }
        float Energy { get; }
    }
}