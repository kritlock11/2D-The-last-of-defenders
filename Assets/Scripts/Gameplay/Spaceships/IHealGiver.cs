using Gameplay.Weapons;

namespace Gameplay.Spaceships
{
    public interface IHealGiver
    {
        UnitBattleIdentity BattleIdentity { get; }
        float Heal { get; }
    }
}