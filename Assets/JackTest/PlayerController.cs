using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace JackTest
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 10;
        public Deck Deck;
        
        private PlayerInput _input;
        private Rigidbody _rb;

        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _rb = GetComponent<Rigidbody>();
            Deck = GetComponent<Deck>();

            Assert.IsNotNull(_input);
            Assert.IsNotNull(_rb);
            Assert.IsNotNull(Deck);

            _input.playCardAction.performed += OnPlayCard;
        }

        void FixedUpdate()
        {
            _rb.AddForce(_input.MoveVector * speed, ForceMode.Force);
        }
        
        void OnPlayCard(InputAction.CallbackContext context)
        {
            Deck.Use();
        }
    }
}
