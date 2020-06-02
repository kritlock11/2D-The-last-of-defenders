using System.Collections;
using Assets.Scripts.Gameplay.Drops;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.UI
{
    public class ResourcesAddedAnim : MonoBehaviour
    {
        [SerializeField] private Text _resText;
        [SerializeField] private Color _green;
        [SerializeField] private Color _yellow;

        public void SetText(float value) => _resText.text = "+" + value;
        public void SetColor(IDrop drop)
        {
            switch (drop.Type)
            {
                case DropType.Heal:
                    _resText.color = _green;
                    break;
                case DropType.Energy:
                    _resText.color = _yellow;
                    break;
                case DropType.None:
                    _resText.color = Color.clear;
                    break;
            }
        }

        private void Start() => StartCoroutine(Animation());

        private IEnumerator Animation()
        {
            var rectTransform = (RectTransform)transform;
            var startPosition = rectTransform.anchoredPosition;
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                var t = 1 - Mathf.Pow(1 - i, 2);
                rectTransform.anchoredPosition = startPosition + t * 70 * Vector2.down;

                yield return null;
            }
            yield return new WaitForSeconds(0.5f);

            Destroy(gameObject);
        }
    }
}
