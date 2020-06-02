using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public string Text
        {
            set => _text.text = $"{value}";
        }
    }
}
