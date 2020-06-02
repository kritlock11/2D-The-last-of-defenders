using UnityEngine;

namespace Assets.Scripts.Gameplay.UI
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private GameObject _go;
        public void SetActive(bool value) => _go.SetActive(value);
    }
}
