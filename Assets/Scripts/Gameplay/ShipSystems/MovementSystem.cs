using Gameplay.ShipControllers.CustomControllers;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {
        [Range(0, 30)] [SerializeField] private float _lateralSpeed;
        [Range(0, 30)] [SerializeField] private float _longitudinalSpeed;
        [Range(0, 30)] [SerializeField] private float _RandomSpeed;

        Vector3 _moVector = Vector3.zero;
        private bool flag;

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalSpeed, Vector3.up);
        }

        public void RandomMovement(float amount)
        {
            if (!flag)
            {
                GetNextPosition();
            }
            Move(amount * _RandomSpeed, _moVector);
        }

        private void GetNextPosition()
        {
            var vec = transform.position + Random.insideUnitSphere;
            vec.z = transform.position.z;
            _moVector = vec;
            flag = true;
            Invoke("GetNextPosition", 1f);
        }

        private void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);
        }

        //public void Dash()
        //{
        //    if (!Input.GetKeyDown(KeyCode.LeftShift)) return;

        //    var offset = 10;
        //    var distance = 3;

        //    transform.position = Vector2.MoveTowards(
        //        transform.position,
        //        Input.GetAxis("Horizontal") < 0 ?
        //            new Vector2(transform.position.x - offset, transform.position.y) :
        //            new Vector2(transform.position.x + offset, transform.position.y),
        //        distance);
        //}
    }
}
