using UnityEngine;
using UnityEngine.InputSystem;

namespace JackTest
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector3 MoveVector { get; private set; }
    
        private PlayerInputActions _actions;
        private InputAction _moveAction;

        void Awake()
        {
            MoveVector = new Vector3();
            _actions = new PlayerInputActions();
        
            _moveAction = _actions.Gameplay.Move;
        }

        void Update()
        {
            Vector2 inputVector = _moveAction.ReadValue<Vector2>(); 
            if (inputVector != Vector2.zero)
            {
                MoveVector = new Vector3(inputVector.x, 0, inputVector.y);
            }
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
