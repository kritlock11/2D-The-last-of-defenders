using Assets.Scripts.Gameplay.Spawners;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Text _score;
        [SerializeField] private Text _bestScore;

        [SerializeField] private Button _restart;
        [SerializeField] private Button _quite;

        private void OnEnable()
        {
            Time.timeScale = 0f;

            _score.text = GetScore();
            _bestScore.text = $"BestScore: {GetBestScore()}";
            _restart.onClick.AddListener(RestartScene);
            _quite.onClick.AddListener(Quite);
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
            _restart.onClick.RemoveListener(RestartScene);
        }

        private string GetScore() => SpawnedEntities.KilledShipList.Count.ToString();

        private string GetBestScore()
        {
            var best = PlayerPrefs.GetInt("BestScore", 0);
            var score = SpawnedEntities.KilledShipList.Count;
            
            if (score <= best) return best.ToString();
            PlayerPrefs.SetInt("BestScore", score);
            return score.ToString();
        }

        private void RestartScene()
        {
            SpawnedEntities.KilledShipList.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Quite()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
            RefreshScore();
        }

        private void RefreshScore() => PlayerPrefs.SetInt("BestScore", 0);
    }
}
