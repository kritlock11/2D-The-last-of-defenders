using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.UI
{
    public class Energy : MonoBehaviour
    {
        [SerializeField] private Text _text;
        
        public string Text
        {
            set => _text.text = $"{value}";
        }
    }
}
