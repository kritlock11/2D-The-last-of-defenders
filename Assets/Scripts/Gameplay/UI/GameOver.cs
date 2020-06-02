using Assets.Scripts.Gameplay.Spawners;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Text _score;

        private void OnEnable()
        {
            Time.timeScale = 0f;
            _score.text = SpawnedEntities.KilledShipList.Count.ToString();
            _restart.onClick.AddListener(RestartScene);
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
            _restart.onClick.RemoveListener(RestartScene);
        }

        private void RestartScene()
        {
            SpawnedEntities.KilledShipList.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
