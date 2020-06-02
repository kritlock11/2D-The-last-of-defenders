using Assets.Scripts.Gameplay.Spawners;
using Gameplay.Spaceships;
using UnityEngine;

namespace Assets.Scripts.Gameplay.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        private void OnEnable()
        {
            SetScore();
            SpawnedEntities.OnKill += Enemies_OnKill;
        }

        private void OnDisable() => SpawnedEntities.OnKill -= Enemies_OnKill;
        private void OnDestroy() => SpawnedEntities.OnKill -= Enemies_OnKill;
        private void Enemies_OnKill(ISpaceship ship) => SetScore();
        private void SetScore() => UILocator.Score.Text = SpawnedEntities.KilledShipList.Count.ToString();
    }
}
