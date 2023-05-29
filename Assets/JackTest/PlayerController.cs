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
            _rb.AddForce(_input.MoveVector * speed, ForceMode.Force);
        }
    }
}
