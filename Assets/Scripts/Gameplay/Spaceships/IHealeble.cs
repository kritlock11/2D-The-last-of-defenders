using Gameplay.Weapons;

namespace Gameplay.Spaceships
{
    public interface IHealeble
    {
        UnitBattleIdentity BattleIdentity { get; }
        void ApplyHeal(IHealGiver healDealer);
    }
}