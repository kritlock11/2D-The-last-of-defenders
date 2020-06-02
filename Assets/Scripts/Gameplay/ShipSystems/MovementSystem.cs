using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {
        [Range(0, 30)] [SerializeField] private float _lateralSpeed;
        [Range(0, 30)] [SerializeField] private float _longitudinalSpeed;
        [Range(0, 30)] [SerializeField] private float _RandomSpeed;

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralSpeed, Vector3.right);
            Dash();
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalSpeed, Vector3.up);
        }

        public void RandomMovement(float amount)
        {
            var mult = 5;
            var t = Time.time;
            Move(amount * _RandomSpeed, new Vector3(Mathf.PerlinNoise(t * mult, 0), 1, 0));
        }

        private void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);
        }

        public void Dash()
        {
            if (!Input.GetKeyDown(KeyCode.LeftShift)) return;

            var offset = 10;
            var distance = 3;

            transform.position = Vector2.MoveTowards(
                transform.position,
                Input.GetAxis("Horizontal") < 0 ?
                    new Vector2(transform.position.x - offset, transform.position.y) :
                    new Vector2(transform.position.x + offset, transform.position.y),
                distance);
        }
    }
}
