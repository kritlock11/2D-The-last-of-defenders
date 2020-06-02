using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.UI
{
    class Intro : MonoBehaviour
    {
        [SerializeField] private Button hidePanel;

        private GameControl.GameControl gameControl;

        private void OnEnable()
        {
            gameControl = FindObjectOfType<GameControl.GameControl>();
            Time.timeScale = 0f;
            hidePanel.onClick.AddListener(HidePanel_OnClick);
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
            hidePanel.onClick.RemoveListener(HidePanel_OnClick);
        }

        private void HidePanel_OnClick()
        {
            transform.gameObject.SetActive(false);
            gameControl.StartGame();
        }
    }
}
