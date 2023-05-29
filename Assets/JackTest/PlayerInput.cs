using UnityEngine;
using UnityEngine.InputSystem;

namespace JackTest
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 MoveVector { get; private set; }
    
        private PlayerInputActions _actions;
        private InputAction _moveAction;

        void Awake()
        {
            _actions = new PlayerInputActions();
        
            _moveAction = _actions.Gameplay.Move;
        }

        void Update()
        {
            MoveVector = _moveAction.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
            _actions.Gameplay.Enable();
        }

        private void OnDisable()
        {
            _actions.Gameplay.Disable();
        }
    }
}
