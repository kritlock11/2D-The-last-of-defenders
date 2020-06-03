using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.UI
{
    class Intro : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _quite;

        private GameControl.GameControl gameControl;

        private void OnEnable()
        {
            gameControl = FindObjectOfType<GameControl.GameControl>();
            Time.timeScale = 0f;
            _start.onClick.AddListener(HidePanel_OnClick);
            _quite.onClick.AddListener(Quite);
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        private void HidePanel_OnClick()
        {
            transform.gameObject.SetActive(false);
            gameControl.StartGame();
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
