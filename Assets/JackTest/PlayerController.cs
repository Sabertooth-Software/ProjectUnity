using UnityEngine;
using UnityEngine.Assertions;

namespace JackTest
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 10;
        
        private PlayerInput _input;
        private Rigidbody _rb;

        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _rb = GetComponent<Rigidbody>();

            Assert.IsNotNull(_input);
            Assert.IsNotNull(_rb);
        }

        void FixedUpdate()
        {
            Vector3 adjustedMoveVector = new Vector3(_input.MoveVector.x, 0,  _input.MoveVector.y);
            _rb.AddForce(adjustedMoveVector * speed, ForceMode.Force);
        }
    }
}
